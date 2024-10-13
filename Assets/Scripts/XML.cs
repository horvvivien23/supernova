using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLManager : MonoBehaviour
{
    public TextAsset xmlFile; //  XML f�jlt Unity-ben

    void Start()
    {
        LoadXML();
    }

    void LoadXML()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlFile.text); // Bet�ltj�k az XML tartalm�t

        // Beolvassuk a f� �rhaj� adatait
        XmlNode playerNode = xmlDoc.SelectSingleNode("game/player");
        string playerName = playerNode.SelectSingleNode("name").InnerText;
        int playerLives = int.Parse(playerNode.SelectSingleNode("lives").InnerText);

        Debug.Log("Player Name: " + playerName);
        Debug.Log("Player Lives: " + playerLives);

        // Beolvashatod az ellens�gek adatait is
        XmlNodeList enemyNodes = xmlDoc.SelectNodes("game/enemies/enemy");
        foreach (XmlNode enemy in enemyNodes)
        {
            string enemyName = enemy.SelectSingleNode("name").InnerText;
            Debug.Log("Enemy Name: " + enemyName);
        }

        // K�d ide az adatok alapj�n a j�t�kelemek m�dos�t�s�hoz
    }
}
