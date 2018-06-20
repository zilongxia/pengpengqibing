using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class loading : MonoBehaviour {

    public string _xmlpath;
    Canvas canv;
    public InputField text;
    void Start() {
        //_xmlpath = Application.dataPath + "/playdata";
        //_xmlpath = Application.streamingAssetsPath + "/playdata";
        //_xmlpath = "jar:file://"+Application.dataPath + "!/playdata/";
        _xmlpath = Application.persistentDataPath + "/playdata";//C:\Users\Administrator\AppData\LocalLow\mofashijie\shiyan1
        if (!File.Exists(_xmlpath)) {
            //新建xml实例
            XmlDocument xmlDoc = new XmlDocument();
            //创建根节点，最上层节点（总共3层）
            XmlElement root = xmlDoc.CreateElement("playername");
            xmlDoc.AppendChild(root);

            //创建用户子节点
            XmlElement user = xmlDoc.CreateElement("name");
            user.SetAttribute("user_name", "输入要创建角色");
            root.AppendChild(user);
            xmlDoc.Save(_xmlpath);
            //canv = GameObject.Find("Canvas").GetComponent<Canvas>();
            //Camera.main.transform.position = canv.transform.position;
            //Camera.main.orthographicSize = Screen.height / 2;

        }
        XmlDocument xmlDoc1 = new XmlDocument();//实例化一个xml
        xmlDoc1.Load(_xmlpath);//匹配路径
        XmlNodeList nodeList = xmlDoc1.SelectSingleNode("playername").ChildNodes;//设置xml
        foreach (XmlElement x in nodeList) {
            //开始遍历
            if(x.GetAttribute("user_name")== "输入要创建角色"){
                text.text = "输入要创建角色";
            }
            else{
                text.text = "欢迎回来，" + x.GetAttribute("user_name");
            }
        }
        _xmlpath = Application.persistentDataPath + "/jineng";
        if (!File.Exists(_xmlpath))
        {
            //新建xml实例
            XmlDocument xmlDoc = new XmlDocument();
            //创建根节点，最上层节点（总共3层）
            XmlElement root = xmlDoc.CreateElement("jineng");
            xmlDoc.AppendChild(root);

            //创建用户子节点
            XmlElement user = xmlDoc.CreateElement("jn");//技能
            user.SetAttribute("a1", "火球");
            user.SetAttribute("a2", "分裂");
            user.SetAttribute("a3", "增强");
            user.SetAttribute("a4", "连发");

            root.AppendChild(user);
            xmlDoc.Save(_xmlpath);
            

        }
        _xmlpath = Application.persistentDataPath + "/wuping";
        if (!File.Exists(_xmlpath))
        {
            //新建xml实例
            XmlDocument xmlDoc = new XmlDocument();
            //创建根节点，最上层节点（总共3层）
            XmlElement root = xmlDoc.CreateElement("wuping");
            xmlDoc.AppendChild(root);

            //创建用户子节点
            XmlElement user = xmlDoc.CreateElement("wp");//物品
            user.SetAttribute("a1", "");
            user.SetAttribute("a2", "");
            user.SetAttribute("a3", "");

            root.AppendChild(user);
            xmlDoc.Save(_xmlpath);
        }
        _xmlpath = Application.persistentDataPath + "/juanzhou";
        if (!File.Exists(_xmlpath))
        {
            //新建xml实例
            XmlDocument xmlDoc = new XmlDocument();
            //创建根节点，最上层节点（总共3层）
            XmlElement root = xmlDoc.CreateElement("juanzhou");
            xmlDoc.AppendChild(root);

            //创建用户子节点
            XmlElement user = xmlDoc.CreateElement("jz");//卷轴
            user.SetAttribute("a1", "");
            user.SetAttribute("a2", "");
            user.SetAttribute("a3", "");

            root.AppendChild(user);
            xmlDoc.Save(_xmlpath);
        }
        _xmlpath = Application.persistentDataPath + "/wanjia";
        if (!File.Exists(_xmlpath))
        {
            //新建xml实例
            XmlDocument xmlDoc = new XmlDocument();
            //创建根节点，最上层节点（总共3层）
            XmlElement root = xmlDoc.CreateElement("wanjia");
            xmlDoc.AppendChild(root);

            //创建用户子节点
            XmlElement user = xmlDoc.CreateElement("wj");//玩家出战带的装备
            user.SetAttribute("a1", "");//技能
            user.SetAttribute("a2", "");//技能
            user.SetAttribute("a3", "");//技能
            user.SetAttribute("a4", "");  //技能
            user.SetAttribute("a5", ""); //物品
            user.SetAttribute("a6", "");//物品
            user.SetAttribute("a7", "");//物品
            user.SetAttribute("a8", "");//物品
            user.SetAttribute("a9", "");//卷轴
            user.SetAttribute("a10", "");//卷轴
            user.SetAttribute("a11", "");//卷轴
            user.SetAttribute("a12", "");//卷轴
            root.AppendChild(user);
            xmlDoc.Save(_xmlpath);
        }
    }


	void Update(){
        _xmlpath = Application.persistentDataPath + "/playdata";
        XmlDocument xmlDoc1 = new XmlDocument();//实例化一个xml
        xmlDoc1.Load(_xmlpath);//匹配路径
        XmlNodeList nodeList = xmlDoc1.SelectSingleNode("playername").ChildNodes;//设置xml
        foreach (XmlElement x in nodeList)
        {
            //开始遍历
            if (x.GetAttribute("user_name") == "输入要创建角色")
            {
                break;
            }
            else
            {
                if (File.Exists(_xmlpath))
                {
                    if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
                    {
                        Application.LoadLevel("main");
                    }
                }
            }
        }
        
    }
}
