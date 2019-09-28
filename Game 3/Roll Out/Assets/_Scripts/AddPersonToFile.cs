//Levi Sutton

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AddPersonToFile : MonoBehaviour
{
    string newName;
    int newScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        newScore = PlayerPrefs.GetInt("High Score");
        newName = PlayerPrefs.GetString("Name");
    }
    public void AddPerson(string filename)
    {
        File.AppendAllText(Application.dataPath + "/" + filename, Environment.NewLine + newName + "," + newScore);
    }
}
