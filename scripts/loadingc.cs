using UnityEngine;
using System.Collections;

public class loadingc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("ShowWord",5f);
	}
	
	// Update is called once per frame
	public void ShowWord(){
		Application.LoadLevel ("loading");
	}
   
}
