using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;
public class XmlTools : MonoBehaviour
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello World!");
    //    }
    //}
    /// <summary>
    /// 所有的XML文件全部放在同一文件夹目录下
    /// </summary>
    public class XMLTOOL
    {
        // XML create
        public static void createXML(string root_name, string xml_name)
        {
            //新建XmlDocument对象
            XmlDocument doc = new XmlDocument();
            // 只是创建一个XML文件 应该不会不需要在创建的时候，就添加节点 
            //根节点
            XmlElement wa = doc.CreateElement(root_name);
            // sava data path(windows) 
            // 可替换为Application.persistentDataPath ，在游戏打包后这个路径不知道 是不是会变
            string path = Application.dataPath + "/player_Data/" + xml_name + ".xml";
            doc.Save(path);
        }

        /// <summary>
        /// 在原XML 文件中增加一个节点
        /// @param need_insert_node_name , inserted_node_Name,inserted_node_value(int)
        /// </summary>
        /// <param name="need_insert_node_name"></param>
        public static void AddXML(string need_insert_node_name, string inserted_node_Name, int inserted_node_value, string xml_name)
        {
            //新建XmlDocument对象
            string path = Application.dataPath + "/player_Data/" + xml_name + ".xml";
            XmlDocument doc = new XmlDocument();
            //载入文件
            try
            {
                doc.Load(path);
            }
            catch (System.Xml.XmlException)
            {
                throw new Exception("load fail");
            }
            //查找要插入数据的节点
            XmlNode newxmlnode = doc.SelectSingleNode(need_insert_node_name);
            //创建新的节点
            XmlElement new_node = doc.CreateElement(inserted_node_Name);
            // int 转化为string
            new_node.InnerText = inserted_node_value.ToString();
            newxmlnode.AppendChild(new_node);
            doc.Save(path);
        }

        public static void UpdateXML(string parent_node_name, string updated_node_name, int updated_node_value, string xml_name)
        {
            string path = Application.dataPath + "/player_Data/" + xml_name + ".xml";
            string updated_node_value_str = updated_node_value.ToString();
            XmlDocument doc = new XmlDocument();
            //载入文件
            try
            {
                doc.Load(path);
            }
            catch (System.Xml.XmlException)
            {
                throw new Exception("load fail,do not find file");
            }
            XmlNode inquired_node = doc.SelectSingleNode(parent_node_name);
            if (inquired_node == null)
            {
                throw new Exception("do not find node");
            }
            XmlNodeList charactors = inquired_node.ChildNodes;
            //charactors.SelectNodes(updated_node_name)

            for (int i = 0; i < charactors.Count; i++)
            {
                if (charactors[i].Name.Equals(updated_node_name))
                {
                    charactors[i].InnerText = updated_node_value_str;
                }
            }
            //写入文档
            doc.Save(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml_name"></param>
        static void ReadXML(string xml_name, string root_name)
        {

            XmlDocument doc = new XmlDocument();
            string path = Application.dataPath + "/player_Data/" + xml_name + ".xml";
            doc.Load(path);
            //获取根节点XmlElement表示节点（元素）
            XmlNode player = doc.SelectSingleNode(root_name);
            XmlNodeList persons_element_list = player.ChildNodes;
            // 返回值的类型为dictionary 
            Dictionary<string, int> result_dic = new Dictionary<string, int>();
            //foreach (var x in persons_element_list)
            //{
            //    result_dic.Add(x.Attribute, x.InnerText);
            //}
        }

        /// <summary>
        /// 设计的XML数据的结构 为
        /// root --
        ///         A
        ///         b
        ///         c
        ///   删除XML文件的ROOT节点下的单一节点
        /// </summary>
        /// <param name="xml_name"></param>
        /// <param name="deleted_node_name"></param>
        static void DeleteXMLNode(string xml_name, string deleted_node_name, string root_name)
        {
            XmlDocument doc = new XmlDocument();
            string path = Application.dataPath + "/player_Data/" + xml_name + ".xml";
            doc.Load(path);
            XmlNode inquired_node = doc.SelectSingleNode(root_name);
            XmlNodeList attr_list = inquired_node.ChildNodes;
            for (int i = 0; i < attr_list.Count; i++)
            {
                //if (attr_list[i].Name.Equals(deleted_node_name))
                //{
                //    attr_list.RemoveChild(i);
                //}
            }
            doc.Save(path);
        }


    }
}
