using System.IO;
using System.Xml;
using UnityEngine;

namespace MyGame
{
    public sealed class XMLDataBonuses : IData<SaveDataBonuses>
    {
        public void Save(SaveDataBonuses bonuses, string path = "")
        {
            var xmlDoc = new XmlDocument();

            XmlNode rootNode = xmlDoc.CreateElement("Player");
            xmlDoc.AppendChild(rootNode);

            

            XmlNode userNode = xmlDoc.CreateElement("Info");

            var attribute = xmlDoc.CreateAttribute("Unity");
            attribute.Value = Application.unityVersion;
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "System Language: " + Application.systemLanguage;
            rootNode.AppendChild(userNode);


            xmlDoc.Save(path);
        }
        public SaveDataBonuses Load(string path = "")
        {
            var result = new SaveDataBonuses();
            if (!File.Exists(path)) return result;
            using (var reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {
                    
                }
            }
            return result;
        }
    }
}