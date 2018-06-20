using UnityEngine;
using System.Collections;

public class PlayerCreat : MonoBehaviour {
  	//用于显示玩家ID
	public  GUIText wz_bl;
		
	//新建的目标对象
	public Transform playerPrefab;
    //新建集合，用于存储PlayerControl脚本组件
	private ArrayList list=new ArrayList();
	//服务端新建完成后运行
	void OnServerInitialized(){
		
		MovePlayer(Network.player);
		
	}
    //玩家连接后运行
	void OnPlayerConnected(NetworkPlayer player){
		
		MovePlayer(player);
		
	}
	void MovePlayer(NetworkPlayer player){
		//获取玩家id值
		int playerID=int.Parse(player.ToString());
		wz_bl.text="玩家ID:"+playerID;
		
		//初始化目标对象
        Transform playerTrans=(Transform)Network.Instantiate(playerPrefab,transform.position, transform.rotation, playerID);
		
        NetworkView playerObjNetworkview=playerTrans.GetComponent<NetworkView>();
        //添加PlayerControl组件至集合中
        list.Add(playerTrans.GetComponent("PlayerControl"));
        //调用RPC，函数名为SetPlayer
		playerObjNetworkview.RPC("SetPlayer",RPCMode.AllBuffered,player);
	}
	//玩家断开连接时调用
    void OnPlayerDisconnected(NetworkPlayer player) {
		
		//Debug.Log("Clean up after player " + player);
        //遍历集合对象上的PlayerControl组件
	foreach(PlayerControl script in list){
		if(player==script.ownerPlayer){
			Network.RemoveRPCs(script.gameObject.GetComponent<NetworkView>().viewID);
			Network.Destroy(script.gameObject);
			list.Remove(script);
			break;
		}
	}
	
	
	int playerNumber= int.Parse(player+"");
	Network.RemoveRPCs(Network.player, playerNumber);
	
	
	
	Network.RemoveRPCs(player);
	Network.DestroyPlayerObjects(player);
}
//客户端断开连接时调用
void OnDisconnectedFromServer(NetworkDisconnection info) {
	
	Application.LoadLevel(Application.loadedLevel);	
}
}
