using UnityEngine;
using System.Collections;

public class NetworkServer : MonoBehaviour {

	
	private string ip="192.168.70.129";
	private int port=10001;
	
void OnGUI(){
		
	switch(Network.peerType){
		
		case NetworkPeerType.Disconnected:
			StartCreat();
			break;
		case NetworkPeerType.Server:
			OnServer();
			break;
		case NetworkPeerType.Client:
			OnClient();
			break;
		case NetworkPeerType.Connecting:
			GUILayout.Label("连接中");
			break;
		}
		
	}
	void StartCreat(){
		
			GUILayout.BeginVertical();
			if(GUILayout.Button("新建服务器")){
				
				NetworkConnectionError error=Network.InitializeServer(30,port,true);
				Debug.Log (error);
				
			}
			
			if(GUILayout.Button("连接服务器")){
				

				NetworkConnectionError error=Network.Connect(ip,port);
				Debug.Log(error);
				
			}
			GUILayout.Label("请输入要连接服务器的IP：");
			ip=GUILayout.TextField(ip);
		
			GUILayout.EndVertical();
		
		
		}
	void OnServer(){
		GUILayout.Label(" 新建服务器成功！等待客户端连接中...");
        int length=Network.connections.Length;
		string exip=Network.player.externalIP;
		string ipe=Network.player.ipAddress;
		GUILayout.Label("外网ip:"+exip);
		GUILayout.Label("内网ip:"+ipe);
		for(int i=0;i<length;i++){
			
			GUILayout.Label("连接客户端的IP:"+Network.connections[i].ipAddress);
            GUILayout.Label("连接客户端的端口:"+Network.connections[i].port);
			
		}
				
		if(GUILayout.Button("  断开（'关闭服务器'）")){
			
			
			Network.Disconnect();
				
		}
		
	}
	void OnClient(){
		
		GUILayout.Label("连接服务器成功！");
		if(GUILayout.Button("断开")){
		
			Network.Disconnect();
			
		
		}
		
		
	}
	
	
}
