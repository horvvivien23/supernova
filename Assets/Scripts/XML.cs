using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLManager : MonoBehaviour
{
    public TextAsset xmlFile; //  XML fájlt Unity-ben

    void Start()
    {
        LoadXML();
    }

    void LoadXML()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlFile.text); // Betöltjük az XML tartalmát

        // Beolvassuk a fõ ûrhajó adatait
        XmlNode playerNode = xmlDoc.SelectSingleNode("game/player");
        string playerName = playerNode.SelectSingleNode("name").InnerText;
        int playerLives = int.Parse(playerNode.SelectSingleNode("lives").InnerText);

        Debug.Log("Player Name: " + playerName);
        Debug.Log("Player Lives: " + playerLives);

        // Beolvashatod az ellenségek adatait is
        XmlNodeList enemyNodes = xmlDoc.SelectNodes("game/enemies/enemy");
        foreach (XmlNode enemy in enemyNodes)
        {
            string enemyName = enemy.SelectSingleNode("name").InnerText;
            Debug.Log("Enemy Name: " + enemyName);
        }

        // Kód ide az adatok alapján a játékelemek módosításához
    }
}
