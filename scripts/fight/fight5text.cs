using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fight5text : MonoBehaviour {
    public Transform prefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("ShowWord", 3f);
        Instantiate(prefab);

    }
}
