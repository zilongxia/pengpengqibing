using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallmap : MonoBehaviour {
    public GameObject mapxiangji;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mapxiangji.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z-40);

	}
}
