using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bianjie : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.localPosition.x > 2900|| this.transform.localPosition.x < -2900|| this.transform.localPosition.y > 2900|| this.transform.localPosition.y < -2900) {
            this.transform.localPosition = Vector3.zero;
                
                }

    }
}
