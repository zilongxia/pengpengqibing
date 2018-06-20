using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class networkclient : MonoBehaviour {

	private string roip="请输入要连接的服务器";
	private int lport=10000;
	private bool usenat=false;
	void OnGUI(){
		switch (Network.peerType){
		case NetworkPeerType.Disconnected:
			Startconnect();
			break;
		case NetworkPeerType.Client:
			Clientto();
			break;
		case NetworkPeerType.Connecting:
			Debug.Log ("连接中");
			break;
			
		}
	}
	void Startconnect(){
		//roip = GameObject.Find("Canvas").GetComponentInChildren<InputField>().Text;
		roip =GameObject.FindGameObjectWithTag("inputtext").GetComponent<InputField>().text;

	//	var go = GameObject.Find("InputField").GetComponent<InputField>();
	//	roip = go.text;
		if(GUI.Button (new Rect(10,50,100,30),"连接服务器")){
			NetworkConnectionError error=Network.Connect(roip,lport,"unitynetwork");
			Debug.Log (error);
		}
	}
	void Clientto(){
		GUILayout.Label("成功连接到服务器！");
	}

	void OnConnectedToServer(){
		foreach(GameObject go in FindObjectsOfType(typeof (GameObject))){
			go.SendMessage("OnNetworkLoaded",SendMessageOptions.DontRequireReceiver);
		}
	}
	
}
