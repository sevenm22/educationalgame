using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text ScoreText;

    private CurrentGameData m_GameData;
    private int m_FlagNumber;

    private int m_Scroes;
    private int m_WrongScores;
    private bool Initialized = false;


    // Start is called before the first frame update
    void Start()
    {
        m_GameData = GameObject.Find("GameDataObject").GetComponent<CurrentGameData>() as CurrentGameData;
        m_Scroes = 0;
        m_WrongScores = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Initialized)
        {
            if (GameSettings.Instance.GetGameMode() == GameSettings.EGameMode.SHORT_MODE)
                m_FlagNumber = 13;
            else
                m_FlagNumber = m_GameData.GetFlagNumber();

            DisplayScores();
            Initialized = true;
        }
    }

    public int GetCurrentScore() { return m_Scroes; }
    public int GetCurrentWrongScore() { return m_WrongScores; }
    public int GetQuestionsNumber() { return m_FlagNumber; }

    public void AddScores()
    {
        if (m_Scroes < m_FlagNumber)
            m_Scroes += 1;
        DisplayScores();
    }
    
    public void RemoveScore()
    {
        if(m_Scroes > 0)
        
            m_Scroes -= 1;
            DisplayScores();
    }


    public void AddWrongScore()
    {
        if (m_WrongScores < m_FlagNumber)
            m_WrongScores += 1;
    }

    void DisplayScores()
    {
        string DisplayString = "Scores : " + m_Scroes + "/" + m_FlagNumber;
        ScoreText.text = DisplayString;
    }
}
