using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class gong : MonoBehaviour
{
    private new Animation animation;
    public GameObject camera1;
   // private float speed = 0.5f;//速度
    public int AAA = 10;  //物体攻击力
    public Transform tag1;
    public Transform tag2;
    public Transform tag3;
    public Transform tag4;
    private int dest;  //销毁记录 1为销毁
    private NavMeshAgent agent; // 寻路者
    private int zhuantai = 0;
    public int luxian ;   //1顺时针
    private int jibuqi = 1;  //人物计步器  1 tag第一站牌 2 3 4 站牌 
    // 0 站姿 WK_archer_01_idle_A      1走   WK_archer_02_walk     2跑 WK_archer_03_run
    // 3 拉弓站姿 WK_archer_05_combat_idle 4 拉弓走 WK_archer_06_combat_walk 5 攻击 WK_archer_07_attack_A
    // 6 死亡动画 WK_archer_10_death_A  WK_archer_10_death_B
    // Use this for initialization
    private Collider[] aa;
    private Transform[] bossweizhi;
    private Transform[] bossweizhi2;
    private Transform boss1;
    private int dh = 0;//动画判断
    public float cc;
    private int rand;
    private AudioSource music;
    public AudioClip bg;
    public AudioClip bg2;
    void Start()
    {
        dest = 0;
        animation = GetComponent<Animation>();
        agent = this.GetComponent<NavMeshAgent>();
        cc = 12.0f;
        rand = Random.Range(1, 10);
        luxian = 1;
        camera1 = GameObject.FindGameObjectWithTag("MainCamera");
        tag1 = GameObject.FindGameObjectWithTag("tag1").transform;
        tag2 = GameObject.FindGameObjectWithTag("tag2").transform;
        tag3 = GameObject.FindGameObjectWithTag("tag3").transform;
        tag4 = GameObject.FindGameObjectWithTag("tag4").transform;
        music = this.GetComponent<AudioSource>();
        //this.gameObject
    }

    // Update is called once per frame
    void Update()
    {
        luxian=camera1.GetComponent<playermain>().luxia;//跟换行军路线
        agent.speed = cc;//更改移动速度变为跑12  走6
        //GetComponent<NavMeshAgent>().destination = tag1.transform.position;
        // animation.Play("WK_archer_03_run");
        aa = Physics.OverlapSphere(this.gameObject.transform.position, 300);
        int b = aa.Length;
        int i = 0;
        int finda = 0;//判断是否发现敌人0为没有，1为发现
        if (dest==1)
        {
            Destroy(this.gameObject);//销毁这个物体
        }
        if (this.gameObject.GetComponent<value>().hp < 0)
        {
            
            if (rand >= 5)
            {
                animation.Play("WK_archer_10_death_A");
                music.clip = bg;
                if (!music.isPlaying)
                {
                    //播放音乐
                    music.Play();
                }
                if (animation["WK_archer_10_death_A"].normalizedTime >= 0.8)
                {
                    Destroy(this.gameObject);//销毁这个物体
                }
            }
            if (rand<5&&rand>0)
            {
                animation.Play("WK_archer_10_death_B");
                music.clip = bg2;
                if (!music.isPlaying)
                {
                    //播放音乐
                    music.Play();
                }
                if (animation["WK_archer_10_death_B"].normalizedTime >= 0.8)
                {
                    dest = 1;
                    Destroy(this.gameObject);//销毁这个物体
                }
            }
            
        }
        else
        {
            List<Transform> arr = new List<Transform>();
            for (i = 0; i < b; i++)//找到范围内的敌人
            {
                //  Debug.Log(aa[i].transform.gameObject.tag);
                if (aa[i].transform.gameObject.tag == "boss")
                {
                    //Debug.Log(aa[i].transform.name);
                    finda = 1;
                    
                    arr.Add(aa[i].transform);
                    // List<Transform> bossweizhi2 = bossweizhi.ToList(); //数组添加，转换成list表
                    //  bossweizhi2.Add(aa[i].transform);
                    bossweizhi = arr.ToArray();
                }
            }

            if (finda == 1)
            {
                boss1 = Dpdr();//判断敌人
                float jl = Pdjl(boss1.position);//计算boss和当前物体的距离的平方
                                              //Debug.Log(jl);
                if (jl > 11000)
                {
                    agent.SetDestination(boss1.position);
                    animation.Play("WK_archer_06_combat_walk");//准备战斗
                }
                else
                {
                    animation.Play("WK_archer_07_attack_A");
                    if (animation["WK_archer_07_attack_A"].normalizedTime < 0.8)
                    {
                        dh = 1;

                    }
                    //Debug.Log(animation["WK_archer_07_attack_A"].normalizedTime);
                    if (animation["WK_archer_07_attack_A"].normalizedTime >= 0.8 && dh == 1)
                    {
                        //Debug.Log("aaaaaaaaaaaaaaaaaa");
                        boss1.gameObject.GetComponent<value>().hp = boss1.gameObject.GetComponent<value>().hp - AAA;//攻击boss
                        if (!music.isPlaying)
                        {
                            //播放音乐
                            music.Play();
                        }
                        dh = 0;

                    }
                }
            }
            else
            {
                //Debug.Log(b);

                if (zhuantai == 1)
                {
                    animation.Play("WK_archer_03_run");
                }

                //Debug.Log(agent.remainingDistance);
                if (luxian == 1)
                {
                    if (jibuqi == 1)
                    {//agent != null&&
                        agent.SetDestination(tag1.position);//寻路算法


                        zhuantai = 1;
                        //if (Mathf.Abs(agent.remainingDistance) < 101 && Mathf.Abs(agent.remainingDistance) > 1 && jibuqi == 1)
                        if (this.transform.position.x < 940 && this.transform.position.x > 700 && this.transform.position.z < 305 && this.transform.position.z > 63 && jibuqi == 1)
                        {
                            jibuqi = 2;  //判断站牌2号
                                         //Debug.Log(agent.remainingDistance);
                        }
                    }
                    else if (jibuqi == 2)
                    {  //判断是否到达目的地
                        agent.SetDestination(tag2.position);//寻路算法    寻路至2号站牌
                        jibuqi = 2;
                        zhuantai = 1;
                        if (this.transform.position.x < 260 && this.transform.position.x > 55 && this.transform.position.z < 284 && this.transform.position.z > 46 && jibuqi == 2)
                        {
                            jibuqi = 3;  //判断站牌3号
                        }
                    }
                    else if (jibuqi == 3)
                    {  //判断是否到达目的地
                        agent.SetDestination(tag3.position);//寻路算法    寻路至3号站牌
                        jibuqi = 3;
                        zhuantai = 1;
                        if (this.transform.position.x < 300 && this.transform.position.x > 40 && this.transform.position.z < 938 && this.transform.position.z > 724 && jibuqi == 3)
                        {
                            jibuqi = 4;  //判断站牌4号
                                         //Debug.Log(agent.remainingDistance);
                        }
                    }
                    else if (jibuqi == 4)
                    {  //判断是否到达目的地
                        agent.SetDestination(tag4.position);//寻路算法    寻路至4号站牌
                        jibuqi = 4;
                        zhuantai = 1;
                        if (this.transform.position.x < 964 && this.transform.position.x > 703 && this.transform.position.z < 940 && this.transform.position.z > 700 && jibuqi == 4)
                        {
                            jibuqi = 1;  //判断站牌1号
                                         //Debug.Log(agent.remainingDistance);
                        }
                    }

                }
                else
                {
                    //Debug.Log(jibuqi);
                    if (jibuqi == 1)
                    {//agent != null&&
                        agent.SetDestination(tag1.position);//寻路算法


                        zhuantai = 1;
                        //if (Mathf.Abs(agent.remainingDistance) < 101 && Mathf.Abs(agent.remainingDistance) > 1 && jibuqi == 1)
                        if (this.transform.position.x < 940 && this.transform.position.x > 700 && this.transform.position.z < 305 && this.transform.position.z > 63 && jibuqi == 1)
                        {
                            jibuqi = 4;  //判断站牌4号
                                         //Debug.Log(agent.remainingDistance);
                        }
                    }
                    else if (jibuqi == 2)
                    {  //判断是否到达目的地
                        agent.SetDestination(tag2.position);//寻路算法    寻路至2号站牌
                        jibuqi = 2;
                        zhuantai = 1;
                        if (this.transform.position.x < 260 && this.transform.position.x > 55 && this.transform.position.z < 284 && this.transform.position.z > 46 && jibuqi == 2)
                        {
                            jibuqi = 1;  //判断站牌1号
                        }
                    }
                    else if (jibuqi == 3)
                    {  //判断是否到达目的地
                        agent.SetDestination(tag3.position);//寻路算法    寻路至3号站牌
                        jibuqi = 3;
                        zhuantai = 1;
                        if (this.transform.position.x < 300 && this.transform.position.x > 40 && this.transform.position.z < 938 && this.transform.position.z > 724 && jibuqi == 3)
                        {
                            jibuqi = 2;  //判断站牌2号
                                         //Debug.Log(agent.remainingDistance);
                        }
                    }
                    else if (jibuqi == 4)
                    {  //判断是否到达目的地
                        agent.SetDestination(tag4.position);//寻路算法    寻路至4号站牌
                        jibuqi = 4;
                        zhuantai = 1;
                        if (this.transform.position.x < 964 && this.transform.position.x > 703 && this.transform.position.z < 940 && this.transform.position.z > 700 && jibuqi == 4)
                        {
                            jibuqi = 3;  //判断站牌3号
                                         //Debug.Log(agent.remainingDistance);
                        }
                    }

                }
                
            }
        

        }




    }


    public Transform Dpdr()
    {// 判断敌人
        Transform bossz;
        int i = 0;
        for (i = 0; i < bossweizhi.Length - 1; i++)
        {
            float sumx = bossweizhi[i].position.x - this.transform.position.x;
            float sumz = bossweizhi[i].position.z - this.transform.position.z;
            float z = (sumx * sumx) + (sumz * sumz);
            float sumx1 = bossweizhi[i + 1].position.x - this.transform.position.x;
            float sumz1 = bossweizhi[i + 1].position.z - this.transform.position.z;
            float z1 = (sumx1 * sumx1) + (sumz1 * sumz1);
            if (z < z1)
            {//如果后面的物体大于前面的物体则替换
                bossweizhi[i + 1] = bossweizhi[i];  //不需要用替换法替换前面
            }
        }
        bossz = bossweizhi[bossweizhi.Length - 1];


        return bossz;
    }
    public float Pdjl(Vector3 bossposition)
    { //判断距离， 判断boss和当前物体的距离的平方
        float x = bossposition.x - this.transform.position.x;
        float z = bossposition.z - this.transform.position.z;
        return x * x + z * z;
    }
}

