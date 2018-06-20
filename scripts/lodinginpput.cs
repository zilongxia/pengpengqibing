using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text;


public class lodinginpput : MonoBehaviour {
    public string _xmlpath;
    public InputField text;
    //private IEnumerable ReadFile(string path)
    //{
    //    WWW www = new WWW(path);
    //    yield return www;

    //}
    public void Change() {
        //_xmlpath = Application.dataPath + "/playdata";   
        //_xmlpath = Application.streamingAssetsPath + "/playdata";
        //_xmlpath = "jar:file://" + Application.dataPath + "!/playdata/";

        _xmlpath = Application.persistentDataPath+ "/playdata";
        //C:\Users\Administrator\AppData\LocalLow\mofashijie\shiyan1

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(_xmlpath);
        XmlNode playername=xmlDoc.SelectSingleNode("playername");//获得根节点
        XmlNodeList nodeList = xmlDoc.SelectSingleNode("playername").ChildNodes;//获得子节点
        //遍历所有子节点
        foreach (XmlElement zjd in nodeList) {
            //拿到节点中的节点
            if (zjd.GetAttribute("user_name") == "输入要创建角色") {
                //遍历属性
                zjd.SetAttribute("user_name",text.text);
                xmlDoc.Save(_xmlpath);
                Debug.Log("修改成功");

               
            }
        }

    }
}
