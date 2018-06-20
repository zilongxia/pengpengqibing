using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class yaogan3d : MonoBehaviour
{
    private float speed = 0.5f;//速度
    public float Dongzuo = 1.0f;  //玩家跑步动作
    public GameObject i; //玩家
    public GameObject camera;//相机跟随
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
    

    protected Animator animator; //动作
    void Start()
    {
        //获取border对象的transform组件  
        border = GameObject.Find("border").transform;
        i = GameObject.Find("player").gameObject;//获得玩家
        camera = GameObject.Find("camera").gameObject;//获得玩家跟随的相机
        button = GameObject.Find("d-pad").gameObject;//获得摇杆
        camera.transform.rotation = i.transform.rotation;

        yaogan = GameObject.Find("d-pad").transform.position;//获得摇杆起始位置
        a = GameObject.Find("d-pad").transform.position;
        initPosition = GetComponentInParent<RectTransform>().position;
        r = Vector3.Distance(transform.position, border.position);

        animator = i.GetComponent<Animator>();//动画指定调用
        if (animator.layerCount >= 1) {    //如果动画的层数大于一
            animator.SetLayerWeight(1,1);//设置动画的权重
        }
        camera.transform.position = i.transform.position;


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
            Dongzuo = 1000.0f;

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
            Dongzuo = 1000.0f;

        }
    }
    //鼠标松开  
    public void OnDragEnd()
    {
        //松开鼠标虚拟摇杆回到原点  
        transform.position = initPosition;
        a = yaogan;
        but.sprite = but1;
        Dongzuo = 1.0f;
        animator.SetBool("Run", false);
    }
    void Update()
    {
        //获得当前动画的状态信息
        if (animator) {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        }
        //transform.position = Input.mousePosition;
        //Vector3 a = Input.mousePosition;
        if (a.y - yaogan.y < -20 && a.x - yaogan.x < 20 && a.x - yaogan.x >- 20)
        {
            
            animator.SetBool("Run",true);
            if (speed < 0)
            {

                speed = -1*speed;
            }
            Debug.Log("bbb");
            //i.transform.Rotate(0, 2, 0);
            i.transform.rotation= Quaternion.Euler(0, 180, 0); 
            i.transform.Translate(0, 0, 10 * speed * Time.deltaTime);//这个系数是根据人物的旋转方向来定的，不是世界朝向。。。

        }
        if (a.y - yaogan.y < -20 && a.x - yaogan.x > 20 )
        {

            animator.SetBool("Run", true);
            if (speed < 0)//以y轴为基准
            {

                speed = -1 * speed;
            }
            Debug.Log("bbb");
            //i.transform.Rotate(0, 2, 0);
            i.transform.rotation = Quaternion.Euler(0,135, 0);
            i.transform.Translate(0, 0, 10 * speed * Time.deltaTime);

        }
        if (a.x - yaogan.x > 20&& a.y - yaogan.y > -20&&a.y - yaogan.y < 20)
        {

            animator.SetBool("Run", true);
            if (speed < 0)//以y轴为基准
            {

                speed = -1 * speed;
            }
            Debug.Log("bbb");
            //i.transform.Rotate(0, 2, 0);
            i.transform.rotation = Quaternion.Euler(0, 90, 0);
            i.transform.Translate(0, 0, 10 * speed * Time.deltaTime);

        }
        if (a.x - yaogan.x > 20 &&  a.y - yaogan.y > 20)
        {

            animator.SetBool("Run", true);
            if (speed < 0)//以y轴为基准
            {

                speed = -1 * speed;
            }
            Debug.Log("bbb");
            //i.transform.Rotate(0, 2, 0);
            i.transform.rotation = Quaternion.Euler(0, 45, 0);
            i.transform.Translate(0, 0, 10 * speed * Time.deltaTime);

        }
        if ( a.y - yaogan.y > 20&& a.x - yaogan.x < 20 && a.x - yaogan.x >- 20)//a是变化的摇杆
        {

            animator.SetBool("Run", true);
            if (speed < 0)//以y轴为基准
            {

                speed = -1 * speed;
            }
            Debug.Log("bbb");
            //i.transform.Rotate(0, 2, 0);
            i.transform.rotation = Quaternion.Euler(0, 0, 0);
            i.transform.Translate(0, 0, 10 * speed * Time.deltaTime);

        }
        if (a.y - yaogan.y > 20  && a.x - yaogan.x < -20)//a是变化的摇杆
        {

            animator.SetBool("Run", true);
            if (speed < 0)//以y轴为基准
            {

                speed = -1 * speed;
            }
            Debug.Log("bbb");
            //i.transform.Rotate(0, 2, 0);
            i.transform.rotation = Quaternion.Euler(0, -45, 0);
            i.transform.Translate(0, 0, 10 * speed * Time.deltaTime);

        }
        if (a.x - yaogan.x < -20&& a.y - yaogan.y <20&& a.y - yaogan.y > -20)//a是变化的摇杆
        {

            animator.SetBool("Run", true);
            if (speed < 0)//以y轴为基准
            {

                speed = -1 * speed;
            }
            Debug.Log("bbb");
            //i.transform.Rotate(0, 2, 0);
            i.transform.rotation = Quaternion.Euler(0, -90, 0);
            i.transform.Translate(0, 0, 10 * speed * Time.deltaTime);

        }
        if (a.x - yaogan.x < -20 && a.y - yaogan.y < -20 )//a是变化的摇杆
        {

            animator.SetBool("Run", true);
            if (speed < 0)//以y轴为基准
            {

                speed = -1 * speed;
            }
            Debug.Log("bbb");
            //i.transform.Rotate(0, 2, 0);
            i.transform.rotation = Quaternion.Euler(0, -135, 0);
            i.transform.Translate(0, 0, 10 * speed * Time.deltaTime);

        }

        camera.transform.position = i.transform.position;


    }
}

