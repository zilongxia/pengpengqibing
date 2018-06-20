using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIjoysticks : MonoBehaviour
{
    private float speed = 0.2f;//速度
    public GameObject i; //玩家
    public GameObject button;//摇杆、、、
    //虚拟方向按钮初始位置  
    public Vector3 initPosition;
    //虚拟方向按钮可移动的半径  
    public float r;
    //border对象  
    public Transform border;
    public Vector3 yaogan;
    public Vector3 a;
    public Image but;
    public Sprite but1;//变化的图片
    public Sprite but2;
    public Sprite but3;

    void Start()
    {
        //获取border对象的transform组件  
        border = GameObject.Find("border").transform;
        i = GameObject.Find("player").gameObject;//获得玩家
        button= GameObject.Find("d-pad").gameObject;//获得摇杆
     

        yaogan = GameObject.Find("d-pad").transform.position;//获得摇杆起始位置
        a = GameObject.Find("d-pad").transform.position;
        initPosition = GetComponentInParent<RectTransform>().position;
        r = Vector3.Distance(transform.position, border.position);

    }
    //鼠标拖拽  
    public void OnDragIng()
    {
        //如果鼠标到虚拟键盘原点的位置 < 半径r  
        if (Vector3.Distance(Input.mousePosition, initPosition) < r)
        {
            //虚拟键跟随鼠标  
            transform.position = Input.mousePosition;
            a = Input.mousePosition;
            but = button.GetComponent<Image>();
            but.sprite = but2;


        }
        else
        {
            //计算出鼠标和原点之间的向量  
            Vector3 dir = Input.mousePosition - initPosition;
            //a = Input.mousePosition;
            //这里dir.normalized是向量归一化的意思，实在不理解你可以理解成这就是一个方向，就是原点到鼠标的方向，乘以半径你可以理解成在原点到鼠标的方向上加上半径的距离  
            transform.position = initPosition + dir.normalized * r;
            a = Input.mousePosition;
            but.sprite = but3;

        }
    }
    //鼠标松开  
    public void OnDragEnd()
    {
        //松开鼠标虚拟摇杆回到原点  
        transform.position = initPosition;
        a = yaogan;
        but.sprite = but1;
    }
    void Update()
    {
        //transform.position = Input.mousePosition;
        //Vector3 a = Input.mousePosition;
            if (a.y - yaogan.y < -20)
            {
                Debug.Log("bbb");
                i.transform.Translate(0, 1000 * -speed * Time.deltaTime, 0);
            }
            if (a.y - yaogan.y >20)
            {
                Debug.Log("bbbb");
                i.transform.Translate(0, 1000 * speed * Time.deltaTime, 0);
            }

            if (a.x - yaogan.x > 20)
            {
                Debug.Log("aaaaa");
                i.transform.Translate(1000 * speed * Time.deltaTime, 0, 0);
            }
            //if (a.x - yaogan.x < 0)
            //{
            //    Debug.Log("aaaaa");
            //    i.transform.Translate(i.transform.position.x * -speed * Time.deltaTime, 0, 0);
            //}
            if (a.x - yaogan.x < -20)
            {
                Debug.Log("aaaaa");
                i.transform.Translate(1000 * -speed * Time.deltaTime, 0, 0);
            }

       

    }
}

