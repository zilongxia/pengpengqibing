using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juzhong : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        var setCam = Camera.main;
        setCam.transform.LookAt(this.transform);
    }
}
