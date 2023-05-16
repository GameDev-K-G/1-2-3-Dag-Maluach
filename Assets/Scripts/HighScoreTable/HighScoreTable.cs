using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;


    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate =entryContainer.Find("HighScoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighScoreEntry>(){
            new HighScoreEntry{ score =209, name= "Gil" },
            new HighScoreEntry{ score =209, name= "Kobi" },
            new HighScoreEntry{ score =2000, name= "Erez" },
            new HighScoreEntry{ score =1, name= "Tamar" },
            new HighScoreEntry{ score =209, name= "Doni" },
            new HighScoreEntry{ score =9, name= "Avner" },
            new HighScoreEntry{ score =209, name= "Ron" },
            new HighScoreEntry{ score =209, name= "Amir" },
             new HighScoreEntry{ score =209, name= "Ron" },
            new HighScoreEntry{ score =209, name= "Amir" }    
        };
        // Sort entry list by Score
        for(int i=0; i < highscoreEntryList.Count; i ++)
        {
            for (int j = i+1; j < highscoreEntryList.Count; j++)
            {
                if(highscoreEntryList[j].score < highscoreEntryList[i].score)
                {
                    //Swap
                    HighScoreEntry temp = highscoreEntryList[i];
                    highscoreEntryList[i] =  highscoreEntryList[j];
                    highscoreEntryList[j] = temp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer,highscoreEntryTransformList);
        }

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

        int score =  highscoreEntry.score;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);    
    }
    /*
    * Represents a single High score entry
    */
    private class HighScoreEntry 
    {
        public int score;
        public string name;
    }

}
