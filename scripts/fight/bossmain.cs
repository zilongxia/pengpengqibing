using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmain : MonoBehaviour {
    private Collider[] aa;
    // Use this for initialization
    private Transform[] bossweizhi;
    private Transform[] bossweizhi2;
    private Transform boss1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        aa = Physics.OverlapSphere(this.gameObject.transform.position, 300);
        int b = aa.Length;
        int i = 0;
        int finda = 0;//判断是否发现敌人0为没有，1为发现
        for (i = 0; i < b; i++)//找到范围内的敌人
        {
            //  Debug.Log(aa[i].transform.gameObject.tag);
            List<Transform> arr = new List<Transform>();
            if (aa[i].transform.gameObject.tag == "human")
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
            float jl = Pdjl(boss1.position);
            if (jl < 20000)
            {
                boss1.gameObject.GetComponent<value>().hp = boss1.gameObject.GetComponent<value>().hp - 100;
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
            float sumy = bossweizhi[i].position.y - this.transform.position.y;
            float z = (sumx * sumx) + (sumy * sumy);
            float sumx1 = bossweizhi[i + 1].position.x - this.transform.position.x;
            float sumy1 = bossweizhi[i + 1].position.y - this.transform.position.y;
            float z1 = (sumx1 * sumx1) + (sumy1 * sumy1);
            if (z < z1)
            {//如果后面的物体小于前面的物体则替换
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
