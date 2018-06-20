using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
public class gongtext : MonoBehaviour {
    private new Animation animation;
    private float speed = 0.5f;//速度
    public Transform tag1;
    public Transform tag2;
    public Transform tag3;
    public Transform tag4;
    private NavMeshAgent agent; // 寻路者
    private int zhuantai = 0;
    public int luxian = 1;   //1顺时针
    private int jibuqi = 1;  //人物计步器  1 tag第一站牌 2 3 4 站牌 
    // 0 站姿 WK_archer_01_idle_A      1走   WK_archer_02_walk     2跑 WK_archer_03_run
    // 3 拉弓站姿 WK_archer_05_combat_idle 4 拉弓走 WK_archer_06_combat_walk 5 攻击 WK_archer_07_attack_A
    // 6 死亡动画 WK_archer_10_death_A  WK_archer_10_death_B
    // Use this for initialization
    private Collider[] aa;
    private Transform[] bossweizhi;
    private Transform[] bossweizhi2;
    private Transform boss1;
    public float cc;
    // Use this for initialization
    void Start()
    {
        animation = GetComponent<Animation>();
        agent = this.GetComponent<NavMeshAgent>();
        cc = 12;
        //this.gameObject
    }

    // Update is called once per frame
    void Update () {
        aa = Physics.OverlapSphere(this.gameObject.transform.position, 150);
        int b = aa.Length;
        int i = 0;
        int finda = 0;//判断是否发现敌人0为没有，1为发现
        for (i = 0; i < b; i++)//找到范围内的敌人
        {
            //  Debug.Log(aa[i].transform.gameObject.tag);
            if (aa[i].transform.gameObject.tag == "boss")
            {
                Debug.Log(aa[i].transform.name);
                finda = 1;
                List<Transform> arr = new List<Transform>();
                arr.Add(aa[i].transform);
               // List<Transform> bossweizhi2 = bossweizhi.ToList(); //数组添加，转换成list表
              //  bossweizhi2.Add(aa[i].transform);
                bossweizhi = arr.ToArray();
            }
        }
        agent.speed = cc;//更改移动速度变为跑12  走6
        //Debug.Log(b);

        if (zhuantai == 1)
        {
            animation.Play("WK_archer_03_run");
        }

        //Debug.Log(agent.remainingDistance);
        if (jibuqi == 1)
        {//agent != null&&
            agent.SetDestination(tag1.position);//寻路算法


            zhuantai = 1;
            //if (Mathf.Abs(agent.remainingDistance) < 101 && Mathf.Abs(agent.remainingDistance) > 1 && jibuqi == 1)
            if (this.transform.position.x < 1800 && this.transform.position.x > 1400 && this.transform.position.z < 460 && this.transform.position.z > 200 && jibuqi == 1)
            {
                jibuqi = 2;  //判断站牌2号
                Debug.Log(agent.remainingDistance);
            }
        }
        else if (jibuqi == 2)
        {  //判断是否到达目的地
            agent.SetDestination(tag2.position);//寻路算法    寻路至2号站牌
            jibuqi = 2;
            zhuantai = 1;
            if (this.transform.position.x < 420 && this.transform.position.x > 153 && this.transform.position.z < 560 && this.transform.position.z > 110 && jibuqi == 2)
            {
                jibuqi = 3;  //判断站牌3号
            }
        }
        else if (jibuqi == 3)
        {  //判断是否到达目的地
            agent.SetDestination(tag3.position);//寻路算法    寻路至3号站牌
            jibuqi = 3;
            zhuantai = 1;
            if (this.transform.position.x < 520 && this.transform.position.x > 115 && this.transform.position.z < 1800 && this.transform.position.z > 1600 && jibuqi == 3)
            {
                jibuqi = 4;  //判断站牌4号
                Debug.Log(agent.remainingDistance);
            }
        }
        else if (jibuqi == 4)
        {  //判断是否到达目的地
            agent.SetDestination(tag4.position);//寻路算法    寻路至4号站牌
            jibuqi = 4;
            zhuantai = 1;
            if (this.transform.position.x < 1900 && this.transform.position.x > 1600 && this.transform.position.z < 1800 && this.transform.position.z > 1600 && jibuqi == 4)
            {
                jibuqi = 1;  //判断站牌1号
                Debug.Log(agent.remainingDistance);
            }
        }

    }
}
