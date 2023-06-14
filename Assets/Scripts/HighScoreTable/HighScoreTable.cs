using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class HighScoreTable : MonoBehaviour
{
    public GameObject Timer;
    public TMP_Text userName;
    private Transform entryContainer;
    private Transform entryTemplate;
   // private List<HighScoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;


    private void Awake()
    {
      
        entryContainer = transform.Find("HighScoreEntryContainer");
   
        entryTemplate =entryContainer.Find("HighScoreEntryTemplate");
        
        entryTemplate.gameObject.SetActive(false);

        // highscoreEntryList = new List<HighScoreEntry>(){
        //     new HighScoreEntry{ score =209, name= "Gil" },
        //     new HighScoreEntry{ score =209, name= "Kobi" },
        //     new HighScoreEntry{ score =2000, name= "Erez" },
        //     new HighScoreEntry{ score =1, name= "Tamar" },
        //     new HighScoreEntry{ score =209, name= "Doni" },
        //     new HighScoreEntry{ score =9, name= "Avner" },
        //     new HighScoreEntry{ score =209, name= "Ron" },
        //     new HighScoreEntry{ score =209, name= "Amir" },
        //     new HighScoreEntry{ score =209, name= "Ron" },
        //     new HighScoreEntry{ score =209, name= "Amir" }    
        // };
        // Sort entry list by Score
        Text textComponent = Timer.GetComponent<Text>();

// Retrieve the text value as a string
      string textString = textComponent.text;
      string name = userName.text;
      string extractedTime = textString.Substring(textString.IndexOf(":") + 1).Trim();
    
        AddHighScoreEntry(extractedTime,name);

        string jsonString = PlayerPrefs.GetString("HighScoreTable");
        Debug.Log(PlayerPrefs.GetString("HighScoreTable" + jsonString));
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
             Debug.Log(highscores.highscoreEntryList.Count);
        for(int i=0; i < highscores.highscoreEntryList.Count; i ++)
        {
            for (int j = i+1; j <highscores.highscoreEntryList.Count; j++)
            {
                DateTime time1;
                DateTime time2;
                // if(highscores.highscoreEntryList[j].score < highscores.highscoreEntryList[i].score)
                // {
                      if (DateTime.TryParseExact(highscores.highscoreEntryList[j].score , "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out time1) &&
            DateTime.TryParseExact(highscores.highscoreEntryList[i].score, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out time2))
        {
            int comparisonResult = DateTime.Compare(time1, time2);

            if (comparisonResult < 0)
            {
           
                    //Swap
                    HighScoreEntry temp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] =  highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = temp;
                }
        }
           }
        }
             

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer,highscoreEntryTransformList);
        }

        // Highscores highscores =new Highscores{highscoreEntryList = highscoreEntryList};

        // string json = JsonUtility.ToJson(highscores);
        // PlayerPreps.SetString("highscoreTable",json);
        // PlayerPreps.save();
        // Debug.Log(PlayerPreps.GetString("highscoreTable"));

    }
    private void CreateHighscoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);//ממקם את השורה שורה מחת לשורה האחרונה
        entryTransform.gameObject.SetActive(true);

        int rank =  transformList.Count + 1;
        string rankString = rank + "";
        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;

        string score =  highscoreEntry.score;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = score;

        string name = highscoreEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);    
    }

    public void AddHighScoreEntry(string score, string name){
       //HighScoreEntry entry = new HighScoreEntry{score=score, name=name};
    
    Highscores highscores = null;
    string jsonString = PlayerPrefs.GetString("HighScoreTable");
    if (!string.IsNullOrEmpty(jsonString))
    {
        highscores = JsonUtility.FromJson<Highscores>(jsonString);
    }

    if (highscores == null)
    {
        highscores = new Highscores();
        highscores.highscoreEntryList = new List<HighScoreEntry>();
    }

    HighScoreEntry entry = new HighScoreEntry { score = score, name = name };
    highscores.highscoreEntryList.Add(entry);

    string updatedJson = JsonUtility.ToJson(highscores);
    PlayerPrefs.SetString("HighScoreTable", updatedJson);
    PlayerPrefs.Save();
}

public void ClearHighScores()
{
    PlayerPrefs.DeleteKey("HighScoreTable");
    PlayerPrefs.Save();
}


    private class Highscores {
        public List<HighScoreEntry> highscoreEntryList;
    }
    /*
    * Represents a single High score entry
    */
    [System.Serializable]
    private class HighScoreEntry 
    {
        public string score;
        public string name;
    }
   

}
