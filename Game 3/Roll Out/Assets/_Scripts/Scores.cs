//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    StreamReader sr;
    public Text scoresText;
    string fileName = "HighScores1.txt";
    string data = "ls,100" + "\n" + "es,200" + "\n" + "as,300" + "\n" + "ss,400" + "\n" + "bs,500";
    List<Person> listOfPeople = new List<Person>();
    string names;
    int scores;

    // Start is called before the first frame update
    void Start()
    {
        
        scoresText.text = "";
        LoadScores(fileName);
        ShowScores();
    }
    void LoadScores(string filename)
    {
        if (!File.Exists(filename))
        {
            File.WriteAllText(filename, data);
        }
        try
        { 
            sr = new StreamReader(Application.dataPath + "/" + filename);
            string dataline = "";
            dataline = sr.ReadLine();
            while (dataline != null)
            {
                string[] values = dataline.Split(',');
                names = values[0].Trim();
                scores = int.Parse(values[1]);
                Person person = new Person(names, scores);
                listOfPeople.Add(person);
                dataline = sr.ReadLine();
            }
        }
        catch (IOException e)
        {
            Debug.Log("Caught: " + e);
        }
        catch (System.IndexOutOfRangeException e)
        {
            Debug.Log(e.Message);
        }

        finally
        {
            if (sr != null)
                sr.Close();
        }
    }
    public void ShowScores()
    {
        int index = 1;
        for (int i = 0; i < 5; i++)
        {
            listOfPeople.Sort();
            scoresText.text += index  + ".\t" + listOfPeople[i].toString() + "\n";
            index++;
        }
    }
}
