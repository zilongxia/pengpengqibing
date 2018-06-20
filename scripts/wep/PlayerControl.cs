using UnityEngine;
using System.Collections;

public class PlayerControl: MonoBehaviour {
	//玩家对象
    public NetworkPlayer ownerPlayer;
	//保存水平方向控制
    private float clientHInput=0;
	//保存垂直方向控制
    private float clientVInput=0;
	//服务端水平方向控制
	private float serverHInput=0;
    //服务端垂直方向控制
	private float serverVInput=0;
	//游戏对象向前移动
    private int Player_Up=0;
	//游戏对象向右移动
	private int Player_Right=1;
	//游戏对象向后移动（相对于前）
    private int Player_Down=2;
	//游戏对象向左移动
	private int Player_Left=3;
	//游戏对象的旋转值
    private int playerRotate;
	//游戏对象的位置
	private Vector3 playerTransform;
	//游戏对象的当前状态
	private int playerState=0;
	private float currentHInput=0;
	private float currentVInput=0;
	
	
	private bool playAni=true;
	void Awake(){
		//是否运行于服务端
		playerTransform=new Vector3();
		if(Network.isClient){
		   
            enabled=false;	 	
		}	
		
	}
	
	void Update () {
	if(ownerPlayer!=null & Network.player==ownerPlayer){
			//获取水平控制
			currentHInput=Input.GetAxis("Horizontal");
            //获取垂直控制
			currentVInput=Input.GetAxis("Vertical");
            
			if(clientHInput!=currentHInput || clientVInput!=currentVInput ){
			//存储客户端的输入
            clientHInput = currentHInput;
			clientVInput = currentVInput;		
			
			if(Network.isServer){
				
				SendMovementInput(currentHInput, currentVInput);
			}else if(Network.isClient){
                //调用服务端的SendMovementInput函数
				GetComponent<NetworkView>().RPC("SendMovementInput", RPCMode.Server, currentHInput, currentVInput);
			}
			
		}
			
		}
        
		if(Network.isServer)

		{ //输入状态
			if(serverVInput==1){
				setState(Player_Up);
			}
			else if(serverVInput==-1){
				setState(Player_Down);	
			}
			if(serverHInput==1){
				setState(Player_Right);
				
			}else if(serverHInput==-1){
				
				setState(Player_Left);
				
			}
			if(serverHInput==0 && serverVInput==0){
				//没有按下方向键时，播放默认动画
				GetComponent<Animation>().Play();
				GetComponent<NetworkView>().RPC("PlayState",RPCMode.OthersBuffered,"idle");
				playAni=false;
			}
      	
 		}
		
	}
	void setState(int state){
		playerRotate=(state-playerState)*90;
		//当按下方向键，播放walk动画
		
		GetComponent<Animation>().Play("walk");
		GetComponent<NetworkView>().RPC("PlayState",RPCMode.OthersBuffered,"walk");
		playAni=true;
		switch(state){
			case 0:
                //向前移动
				playerTransform=Vector3.forward*Time.deltaTime;
				break;
			case 1:
                //向右移动
				playerTransform=Vector3.right*Time.deltaTime;
				break;
			case 2:
                //向后移动
				playerTransform=Vector3.back*Time.deltaTime;
				break;
			case 3:
                //向左移动
				playerTransform=Vector3.left*Time.deltaTime;
				break;
			
		}
        //移动游戏对象
		transform.Translate(playerTransform*5,Space.World);
        //旋转游戏对象
		transform.Rotate(Vector3.up,playerRotate);
        //存储游戏状态
		playerState=state;
		
	}
	[RPC]
	void PlayState(string state){
		
		GetComponent<Animation>().Play(state);
	}
	
	[RPC]
    //调用客户端（这里包括服务端）的SetPlayer函数
	void SetPlayer(NetworkPlayer player){
		
		ownerPlayer=player;
		if(player==Network.player){
		
			enabled=true;
		}
	}
	[RPC]
    //调用服务端的SendMovementInput，把输入状态传给服务端
	void SendMovementInput(float currentHInput,float currentVInput){
		
		serverHInput=currentHInput;
		serverVInput=currentVInput;

	}

	void OnSerializeNetworkView(BitStream stream,NetworkMessageInfo info){
		
		//发送状态数据
		bool play=playAni;
        if (stream.isWriting){
		
			 Vector3 pos = GetComponent<Rigidbody>().position;

             Quaternion rot = GetComponent<Rigidbody>().rotation;

             Vector3 velocity = GetComponent<Rigidbody>().velocity;

             Vector3 angularVelocity = GetComponent<Rigidbody>().angularVelocity;

 			

             stream.Serialize(ref pos);

             stream.Serialize(ref velocity);

             stream.Serialize(ref rot);

             stream.Serialize(ref angularVelocity);
			
			 stream.Serialize(ref play);


		}else{
		
		//读取状态数据
			 Vector3 pos = Vector3.zero; 

             Vector3 velocity = Vector3.zero; 

             Quaternion rot = Quaternion.identity;

             Vector3 angularVelocity = Vector3.zero;
				
			 
			 bool b=false;
			
             stream.Serialize(ref pos);

             stream.Serialize(ref velocity);

             stream.Serialize(ref rot);

             stream.Serialize(ref angularVelocity);
			 
			 stream.Serialize(ref b);
			
			

            }


			
		}	
	
}
