using UnityEngine;
using System.Collections;

public class net : MonoBehaviour {
	private string roip="127.0.0.1";
	private int dk=10000; //端口
	private int number=15;
	private bool usenat=false;

	void OnGUI(){
		switch (Network.peerType){
		case NetworkPeerType.Disconnected:
			StartServer();//服务器还未启动，开始启动
			break;
		case NetworkPeerType.Server:
			Onserver();
			break;
		case NetworkPeerType.Connecting:
			break;

		}
	}

	void StartServer(){
		roip = GUI.TextField(new Rect(10,30,100,20),roip);
		if(GUI.Button (new Rect(10,50,100,30),"创建服务器")){
			Network.incomingPassword="unitynetwork";
			NetworkConnectionError error=Network.InitializeServer(number,dk,usenat);//启动服务器~
			Debug.Log (error);
		}
	}
	void Onserver(){
		GUILayout.Label("创建服务器成功！等待连接。。。。");
		string ip=Network.player.ipAddress;
		int port=Network.player.port;
		GUILayout.Label("IP地址："+ip+"\n端口号"+port);
		int connectlength=Network.connections.Length;
		for(int i=0;i<connectlength;i++){
			GUILayout.Label("连接的IP："+Network.connections[i].ipAddress);
			GUILayout.Label("连接的端口:"+Network.connections[i].port);
		}
		if(GUI.Button(new Rect(10,340,100,30),"断开连接")){
			Network.Disconnect (2000);
		}
	}


}
