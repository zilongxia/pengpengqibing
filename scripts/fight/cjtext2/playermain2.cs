using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playermain2 : MonoBehaviour
{
    public int luxia;//行军路线
    public GameObject camera1;
    public Text jinbi;
    public Text textjianshi;
    public Text textchangqiang;
    public Text textgongjian;
    public Text textqibing;
    public Text textche;
    public Sprite left;
    public Sprite left1;
    public Sprite right;
    public Sprite right1;
    public Button leftbutton;
    public Button rightbutton;
    public Text luxiantext;
    private AudioSource music;
    public GameObject jianshicreate;
    public AudioClip bg;
    public AudioClip bg1;
    public AudioClip bg2;
    public AudioClip bg3;
    public AudioClip bg4;
    public AudioClip bg5;
    public float createtime;
    public Text timetext;
    private float timer;
    public Image timepic;
    private float timevalue;

    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    public GameObject a4;
    public GameObject a5;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
    private Vector3 shengcheng1;
    private Vector3 shengcheng2;
    private Vector3 shengcheng3;
    private Vector3 shengcheng4;
    private Vector3 shengcheng5;
    private Vector3 shengchengboss;

    // Use this for initialization
    void Start()
    {
        music = this.GetComponent<AudioSource>();
        luxia = 1;//默认路线
        jinbi.text = "10";
        textjianshi.text = "0";
        textchangqiang.text = "0";
        textgongjian.text = "0";
        textqibing.text = "0";
        textche.text = "0";
        float timer = Time.time;
        createtime = 30;
        timetext.text = createtime.ToString();
        shengcheng1 = new Vector3(875, 1, 275);
        shengcheng2 = new Vector3(875, 1, 214);
        shengcheng3 = new Vector3(875, 1, 253);
        shengcheng4 = new Vector3(875, 1, 293);
        shengcheng5 = new Vector3(875, 1, 234);
        shengchengboss = new Vector3(136, 1, 195);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timer > 1)
        {
            timer = Time.time;
            createtime = createtime - 1;
            timevalue = 1 - createtime / 30;
            //Debug.Log(timevalue);
            timepic.color = new Color(255, 255, 255, timevalue);
        }
        timetext.text = createtime.ToString();
        // Debug.Log(createtime);
        if (createtime < 1)
        {
            createtime = 30;
            jinbi.text = (int.Parse(jinbi.text) + 5).ToString(); ;
            //timepic.color = new Color(255, 255, 255, 1);
            int i = 0;
            for (i = 1; i <= int.Parse(textjianshi.text); i++)  //生成剑士
            {
                music.clip = bg1;

                //播放音乐
                music.Play();
                shengcheng1 = new Vector3(875 - i * 10, 1, 275);
                Instantiate(a1, shengcheng1, Quaternion.identity);

                shengchengboss = new Vector3(136, 1, 195 + i * 10);
                Instantiate(b1, shengchengboss, Quaternion.identity);
            }
            //textjianshi.text = "0";
            for (i = 1; i <= int.Parse(textchangqiang.text); i++)//生成长枪
            {
                music.clip = bg2;
                //if (!music.isPlaying){}

                //播放音乐
                music.Play();

                shengcheng2 = new Vector3(875 - i * 10, 1, 214);
                Instantiate(a2, shengcheng2, Quaternion.identity);

                shengchengboss = new Vector3(156, 1, 195 + i * 10);
                Instantiate(b2, shengchengboss, Quaternion.identity);
            }
            //textchangqiang.text = "0";
            for (i = 1; i <= int.Parse(textgongjian.text); i++)//生成弓箭
            {
                music.clip = bg3;
                //if (!music.isPlaying)

                //播放音乐
                music.Play();

                shengcheng3 = new Vector3(875 - i * 10, 1, 253);
                Instantiate(a3, shengcheng3, Quaternion.identity);

                shengchengboss = new Vector3(176, 1, 195 + i * 10);
                Instantiate(b3, shengchengboss, Quaternion.identity);

            }
            //textgongjian.text = "0";
            for (i = 1; i <= int.Parse(textqibing.text); i++)  //生成骑兵
            {
                music.clip = bg4;
                //if (!music.isPlaying)

                //播放音乐
                music.Play();

                shengcheng4 = new Vector3(875 - i * 10, 1, 293);
                Instantiate(a4, shengcheng4, Quaternion.identity);

                shengchengboss = new Vector3(196, 1, 195 + i * 10);
                Instantiate(b4, shengchengboss, Quaternion.identity);
            }
            //textqibing.text = "0";
            for (i = 1; i <= int.Parse(textche.text); i++)  //生成车
            {
                music.clip = bg5;
                //if (!music.isPlaying)

                //播放音乐
                music.Play();

                shengcheng5 = new Vector3(875 - i * 10, 1, 234);
                Instantiate(a5, shengcheng5, Quaternion.identity);

                shengchengboss = new Vector3(216, 1, 195 + i * 10);
                Instantiate(b5, shengchengboss, Quaternion.identity);
            }
            //textche.text = "0";
        }

    }
    public void Left()
    {
        music = this.GetComponent<AudioSource>();
        camera1.GetComponent<playermain>().luxia = 2;
        leftbutton.image.sprite = left1;
        rightbutton.image.sprite = right;
        luxiantext.text = "逆时针";
        if (!music.isPlaying)
        {
            //播放音乐
            music.Play();
        }


    }
    public void Right()
    {
        music = this.GetComponent<AudioSource>();
        camera1.GetComponent<playermain>().luxia = 1;
        leftbutton.image.sprite = left;
        rightbutton.image.sprite = right1;
        luxiantext.text = "顺时针";
        if (!music.isPlaying)
        {
            //播放音乐
            music.Play();
        }
    }

    public void Jianshicreate()
    {
        music = this.GetComponent<AudioSource>();
        if (int.Parse(jinbi.text) >= 1)
        {
            jinbi.text = (int.Parse(jinbi.text) - 1).ToString();
            textjianshi.text = (int.Parse(textjianshi.text) + 1).ToString();
            music.clip = bg1;
            music.Play();
        }
        else
        {
            music.clip = bg;

            if (!music.isPlaying)
            {
                //播放音乐
                music.Play();
            }

        }
    }
    public void Changqiangcreate()
    {
        music = this.GetComponent<AudioSource>();
        if (int.Parse(jinbi.text) >= 1)
        {
            jinbi.text = (int.Parse(jinbi.text) - 1).ToString();
            textchangqiang.text = (int.Parse(textchangqiang.text) + 1).ToString();
            music.clip = bg2;
            music.Play();
        }
        else
        {
            music.clip = bg;

            if (!music.isPlaying)
            {
                //播放音乐
                music.Play();
            }

        }
    }
    public void Gongjiancreate()
    {
        music = this.GetComponent<AudioSource>();
        if (int.Parse(jinbi.text) >= 5)
        {
            jinbi.text = (int.Parse(jinbi.text) - 5).ToString();
            textgongjian.text = (int.Parse(textgongjian.text) + 1).ToString();
            music.clip = bg3;
            music.Play();
        }
        else
        {
            music.clip = bg;

            if (!music.isPlaying)
            {
                //播放音乐
                music.Play();
            }
        }
    }
    public void Qibingcreate()
    {
        music = this.GetComponent<AudioSource>();
        if (int.Parse(jinbi.text) >= 10)
        {
            jinbi.text = (int.Parse(jinbi.text) - 10).ToString();
            textqibing.text = (int.Parse(textqibing.text) + 1).ToString();
            music.clip = bg4;
            music.Play();
        }
        else
        {
            music.clip = bg;

            if (!music.isPlaying)
            {
                //播放音乐
                music.Play();
            }
        }
    }
    public void Checreate()
    {
        music = this.GetComponent<AudioSource>();
        if (int.Parse(jinbi.text) >= 20)
        {
            jinbi.text = (int.Parse(jinbi.text) - 20).ToString();
            textche.text = (int.Parse(textche.text) + 1).ToString();
            music.clip = bg5;
            music.Play();
        }
        else
        {
            music.clip = bg;

            if (!music.isPlaying)
            {
                //播放音乐
                music.Play();
            }
        }
    }



}
