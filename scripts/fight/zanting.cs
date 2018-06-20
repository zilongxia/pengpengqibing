using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zanting : MonoBehaviour {

    public GameObject ztmain;
    public GameObject loading;
    public GameObject player;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }
    public void Zanting1()
    {
        ztmain.gameObject.SetActive(true);
    }
    public void jixu()
    {
        ztmain.gameObject.SetActive(false);
    }
    public void fanhui()
    {
        ztmain.gameObject.SetActive(true);
        Application.LoadLevel("main");
    }
    public void tuichu()
    {
        Application.Quit();
    }
    public void huidaojidi()
    {
        player.transform.position = new Vector3(882, 0, 281);
    }
    public void win()
    {
        ztmain.gameObject.SetActive(true);
        Application.LoadLevel("main");
    }
}
