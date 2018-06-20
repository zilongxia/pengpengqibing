using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Xml;

public class windowmain : MonoBehaviour {
    public GameObject button;
    public Sprite pic1;
    public Sprite pic2;
    public GameObject button1;
    private Button but1;
    public Text[] but111 = new Text[10];
    //public Button but1_1;
    //public Button but1_2;
    //public Button but1_3;
    //public Button but1_4;
    //public Button but1_5;
    //public Button but1_6;
    //public Button but1_7;
    //public Button but1_8;
    //public Button but1_9;
    //public Button but1_10;
    public GameObject button2;
    private Button but2;
    public Text[] but222 = new Text[10];
    //public Button but2_1;
    //public Button but2_2;
    //public Button but2_3;
    //public Button but2_4;
    //public Button but2_5;
    //public Button but2_6;
    //public Button but2_7;
    //public Button but2_8;
    //public Button but2_9;
    //public Button but2_10;
    public GameObject button3;
    private Button but3;
    public Text[] but333 = new Text[10];
    //public Button but3_1;
    //public Button but3_2;
    //public Button but3_3;
    //public Button but3_4;
    //public Button but3_5;
    //public Button but3_6;
    //public Button but3_7;
    //public Button but3_8;
    //public Button but3_9;
    //public Button but3_10;
    public GameObject bu1;
    public GameObject bu2;
    public GameObject bu3;
    public Text talk;
    public string _xmlpath;
    int i = 1;
    private string select_name="";
    public void button111() {
        i = i + 1;
        //select_name = EventSystem.current.currentSelectedGameObject.name;
            but1 = button1.GetComponent<Button>();
            but2 = button2.GetComponent<Button>();
            but3 = button3.GetComponent<Button>();
            but1.GetComponent<Image>().sprite = pic1;
            but2.GetComponent<Image>().sprite = pic2;
            but3.GetComponent<Image>().sprite = pic2;
            bu1.SetActive(true);
            bu2.SetActive(false);
            bu3.SetActive(false);
        if (i % 10 == 0)
        {
            talk.text = "这里是你拥有的技能栏~准备好我们就出发吧。。。我的火球术早已饥渴难耐了";
        }
        else {
            talk.text = "这里是你拥有的技能栏~";
        }
        _xmlpath = Application.persistentDataPath + "/jineng";
        //C:\Users\Administrator\AppData\LocalLow\mofashijie\shiyan1

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(_xmlpath);
        XmlNode playername = xmlDoc.SelectSingleNode("jineng");//获得根节点
        XmlNodeList nodeList = xmlDoc.SelectSingleNode("jineng").ChildNodes;//获得子节点
        //遍历所有子节点
        int z = 1;
        for (z = 1; z < 11; z = z + 1)
        {
            foreach (XmlElement zjd in nodeList)
            {
                if (zjd.GetAttribute("a" + z.ToString()) != "")
                {
                    Debug.Log(zjd.GetAttribute("a" + z.ToString()));
                    but111[z - 1].text = zjd.GetAttribute("a"+z.ToString());
                }
                else {
                    but111[z - 1].text = "无";
                }
            }
        }
        
    }
    public void button222()
    {
        i = i + 1;
        //select_name = EventSystem.current.currentSelectedGameObject.name;
        but1 = button1.GetComponent<Button>();
        but2 = button2.GetComponent<Button>();
        but3 = button3.GetComponent<Button>();
        but1.GetComponent<Image>().sprite = pic2;
        but2.GetComponent<Image>().sprite = pic1;
        but3.GetComponent<Image>().sprite = pic2;
        bu1.SetActive(false);
        bu2.SetActive(true);
        bu3.SetActive(false);
        if (i % 10 == 0)
        {
            talk.text = "这里是你拥有的物品栏~准备好我们就出发吧。。。我感觉我们还需要更多的魔具";
        }
        else
        {
            talk.text = "这里是你拥有的物品栏~";
        }
        _xmlpath = Application.persistentDataPath + "/wuping";
        //C:\Users\Administrator\AppData\LocalLow\mofashijie\shiyan1

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(_xmlpath);
        XmlNode playername = xmlDoc.SelectSingleNode("wuping");//获得根节点
        XmlNodeList nodeList = xmlDoc.SelectSingleNode("wuping").ChildNodes;//获得子节点
        //遍历所有子节点
        int z = 1;
        for (z = 1; z < 11; z = z + 1)
        {
            foreach (XmlElement zjd in nodeList)
            {
                if (zjd.GetAttribute("a" + z.ToString()) != "")
                {
                    Debug.Log(zjd.GetAttribute("a" + z.ToString()));
                    but222[z - 1].text = zjd.GetAttribute("a" + z.ToString());
                }
                else
                {
                    but222[z - 1].text = "无";
                }
            }
        }
    }
    public void button333()
    {
        i = i + 1;
        //select_name = EventSystem.current.currentSelectedGameObject.name;
        but1 = button1.GetComponent<Button>();
        but2 = button2.GetComponent<Button>();
        but3 = button3.GetComponent<Button>();
        but1.GetComponent<Image>().sprite = pic2;
        but2.GetComponent<Image>().sprite = pic2;
        but3.GetComponent<Image>().sprite = pic1;
        bu1.SetActive(false);
        bu2.SetActive(false);
        bu3.SetActive(true);
        if (i % 10 == 0)
        {
            talk.text = "这里是你拥有的卷轴栏~。。。。卷轴很贵重哦~，不过我用卷轴就跟洒水一样ε=(´ο｀*)))哇哈哈哈哈哈";
        }
        else
        {
            talk.text = "这里是你拥有的卷轴栏~。。。。卷轴很贵重哦~";
        }
        _xmlpath = Application.persistentDataPath + "/juanzhou";
        //C:\Users\Administrator\AppData\LocalLow\mofashijie\shiyan1

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(_xmlpath);
        XmlNode playername = xmlDoc.SelectSingleNode("juanzhou");//获得根节点
        XmlNodeList nodeList = xmlDoc.SelectSingleNode("juanzhou").ChildNodes;//获得子节点
        //遍历所有子节点
        int z = 1;
        for (z = 1; z < 11; z = z + 1)
        {
            foreach (XmlElement zjd in nodeList)
            {
                if (zjd.GetAttribute("a" + z.ToString()) != "")
                {
                    Debug.Log(zjd.GetAttribute("a" + z.ToString()));
                    but333[z - 1].text = zjd.GetAttribute("a" + z.ToString());
                }
                else
                {
                    but333[z - 1].text = "无";
                }
            }
        }

    }
    public void dj()
    {
        Application.LoadLevel("fight5");
    }
    // Use this for initialization
    void Start () {
        _xmlpath = Application.persistentDataPath + "/jineng";
        //C:\Users\Administrator\AppData\LocalLow\mofashijie\shiyan1

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(_xmlpath);
        XmlNode playername = xmlDoc.SelectSingleNode("jineng");//获得根节点
        XmlNodeList nodeList = xmlDoc.SelectSingleNode("jineng").ChildNodes;//获得子节点
        //遍历所有子节点
        int z = 1;
        for (z = 1; z < 11; z = z + 1)
        {
            foreach (XmlElement zjd in nodeList)
            {
                if (zjd.GetAttribute("a" + z.ToString()) != "")
                {
                    Debug.Log(zjd.GetAttribute("a" + z.ToString()));
                    but111[z - 1].text = zjd.GetAttribute("a" + z.ToString());
                }
                else
                {
                    but111[z - 1].text = "无";
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
