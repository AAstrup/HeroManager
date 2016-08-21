using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CardSaveLoader
{
    string path = Application.dataPath.ToString() + @"/Resources/";
    string fileName = "JsonBaseCards.txt";

    public void Save(CardBase data)
    {
        string file = path + fileName;

        BaseCardsSaveContainer baseCardsSaveContainer;
        if (File.Exists(file))
        {
            baseCardsSaveContainer = LoadBaseCards();
        }
        else
        {
            baseCardsSaveContainer = new BaseCardsSaveContainer();
        }
        baseCardsSaveContainer.AddCard(data);
        string json = JsonUtility.ToJson(baseCardsSaveContainer);

        //write string to file
        File.WriteAllText(@"" + path + fileName, json);
    }

    public BaseCardsSaveContainer LoadBaseCards()
    {
        string baseCardJson = Resources.Load<TextAsset>("JsonBaseCards").text;
        return JsonUtility.FromJson<BaseCardsSaveContainer>(baseCardJson);
    }
}