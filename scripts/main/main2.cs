using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main2 : MonoBehaviour {
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    public GameObject a4;
    public GameObject a5;
    public GameObject a11;
    public GameObject a22;
    public GameObject a33;
    public GameObject a44;
    public GameObject a55;
    public Text talk;
    public GameObject ztmain;
    private float i=1;

	// Use this for initialization
	void Start () {
		
	}
	
	
	void Update () {
		
	}
    public void left() {
        i = i + 1;
        if (i > 5) {
            i = 1;
        }
        if (i == 1) {
            a1.gameObject.SetActive(true);
            a2.gameObject.SetActive(false);
            a3.gameObject.SetActive(false);
            a4.gameObject.SetActive(false);
            a5.gameObject.SetActive(false);
            a11.GetComponent<gong1>().speed = 0.5f;
            talk.text = "弓箭手，拥有强大的远程单体输出";
        }
        if (i == 2)
        {
            a1.gameObject.SetActive(false);
            a2.gameObject.SetActive(true);
            a3.gameObject.SetActive(false);
            a4.gameObject.SetActive(false);
            a5.gameObject.SetActive(false);
            a22.GetComponent<gong1>().speed = 0.5f;
            talk.text = "工程车，对付大片敌人或者城防能发挥出奇效";
        }
        if (i == 3)
        {
            a1.gameObject.SetActive(false);
            a2.gameObject.SetActive(false);
            a3.gameObject.SetActive(true);
            a4.gameObject.SetActive(false);
            a5.gameObject.SetActive(false);
            a33.GetComponent<gong1>().speed = 0.5f;
            talk.text = "长枪兵，适合对付各种难以对付的敌人，攻击距离很长";
        }
        if (i == 4)
        {
            a1.gameObject.SetActive(false);
            a2.gameObject.SetActive(false);
            a3.gameObject.SetActive(false);
            a4.gameObject.SetActive(true);
            a5.gameObject.SetActive(false);
            a44.GetComponent<gong1>().speed = 0.5f;
            talk.text = "骑兵，人类的中坚力量，运用的好的话他们的到来可以瞬间扭转局势";
        }
        if (i == 5)
        {
            a1.gameObject.SetActive(false);
            a2.gameObject.SetActive(false);
            a3.gameObject.SetActive(false);
            a4.gameObject.SetActive(false);
            a5.gameObject.SetActive(true);
            a55.GetComponent<gong1>().speed = 0.5f;
            talk.text = "剑士，人类传统的前排，军队中不可缺少的有生力量";
        }
    }
    public void right()
    {
        i = i - 1;
        if (i < 1)
        {
            i = 5;
        }
        if (i == 1)
        {
            a1.gameObject.SetActive(true);
            a2.gameObject.SetActive(false);
            a3.gameObject.SetActive(false);
            a4.gameObject.SetActive(false);
            a5.gameObject.SetActive(false);
            a11.GetComponent<gong1>().speed = -0.5f;
            talk.text = "弓箭手，拥有强大的远程单体输出，人类中的adc";
        }
        if (i == 2)
        {
            a1.gameObject.SetActive(false);
            a2.gameObject.SetActive(true);
            a3.gameObject.SetActive(false);
            a4.gameObject.SetActive(false);
            a5.gameObject.SetActive(false);
            a22.GetComponent<gong1>().speed = -0.5f;
            talk.text = "工程车，对付大片敌人或者城防能发挥出奇效";
        }
        if (i == 3)
        {
            a1.gameObject.SetActive(false);
            a2.gameObject.SetActive(false);
            a3.gameObject.SetActive(true);
            a4.gameObject.SetActive(false);
            a5.gameObject.SetActive(false);
            a33.GetComponent<gong1>().speed = -0.5f;
            talk.text = "长枪兵，适合对付各种难以对付的敌人，攻击距离很长";
        }
        if (i == 4)
        {
            a1.gameObject.SetActive(false);
            a2.gameObject.SetActive(false);
            a3.gameObject.SetActive(false);
            a4.gameObject.SetActive(true);
            a5.gameObject.SetActive(false);
            a44.GetComponent<gong1>().speed = -0.5f;
            talk.text = "骑兵，人类的中坚力量，运用的好的话他们的到来可以瞬间扭转局势";
        }
        if (i == 5)
        {
            a1.gameObject.SetActive(false);
            a2.gameObject.SetActive(false);
            a3.gameObject.SetActive(false);
            a4.gameObject.SetActive(false);
            a5.gameObject.SetActive(true);
            a55.GetComponent<gong1>().speed = -0.5f;
            talk.text = "剑士，人类传统的前排，军队中不可缺少的有生力量";
        }
    }
    public void play1() {
        ztmain.gameObject.SetActive(true);
        Application.LoadLevel("cjtext");
    }
    public void play2()
    {
        ztmain.gameObject.SetActive(true);
        Application.LoadLevel("cjtext2");
    }
}
