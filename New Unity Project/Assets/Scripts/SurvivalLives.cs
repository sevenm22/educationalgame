﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalLives : MonoBehaviour
{

    public List<GameObject> Hearts;
    public GameObject GameOverPanel;
    public GameObject CorrectGuessedText;
    public GameObject WrongGuessedText;

    private Scores m_Scores;

    private int LifeNumber = 3;

    private CurrentGameData m_GameData;
    // Start is called before the first frame update
    void Start()
    {
        LifeNumber = 3;
        if (GameSettings.Instance.GetGameMode() == GameSettings.EGameMode.SURVIVAL_MODE)
        {
            this.enabled = true;
            foreach (GameObject g in Hearts)
            {
                g.SetActive(true);
            }
        }
        else
            this.enabled = false;

        m_GameData = GameObject.Find("GameDataObject").GetComponent<CurrentGameData>() as CurrentGameData;
        m_Scores = GameObject.Find("Main Camera").GetComponent<Scores>() as Scores;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLife()
    {
        if(LifeNumber > 0)
        {
            LifeNumber--;
            Hearts[LifeNumber].SetActive(false);
        }
        if(LifeNumber == 0)
        {

            CorrectGuessedText.GetComponent<Text>().text = m_Scores.GetCurrentScore().ToString();
            WrongGuessedText.GetComponent<Text>().text = m_Scores.GetCurrentWrongScore().ToString();
            GameOverPanel.SetActive(true);
            m_GameData.SetGameOver();
        }
    }
}
