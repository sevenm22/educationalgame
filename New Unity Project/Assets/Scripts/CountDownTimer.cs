﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public float timeLeft;
    private CurrentGameData m_GameData;

    public GUIStyle ClockStyle;

    private bool StartedGameOverTimer = false;

    //Game over
    public GUIStyle GameOverStyle;
    public GameObject GameOverPanel;
    public GameObject CorrectGuessedText;
    public GameObject WrongGuessedText;
    public GameObject CountryFlag;
    public GameObject CountryFlag1;
    public GameObject CountryFlag2;

    private Scores m_Scores;
    private bool EndGuiActivated; 

    // Start is called before the first frame update
    void Start()
    {
        StartedGameOverTimer = false;
        EndGuiActivated = false;
        m_GameData = GameObject.Find("GameDataObject").GetComponent<CurrentGameData>() as CurrentGameData;
        m_Scores = GameObject.Find("Main Camera").GetComponent<Scores>() as Scores;
        if (GameSettings.Instance.GetGameMode() == GameSettings.EGameMode.TIME_TRAIL_MODE)
            this.enabled = true;
        else
            this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (EndGuiActivated && StartedGameOverTimer == false)
        {
            StartedGameOverTimer = true;
            StartCoroutine(Sleep(2.0f));
        }
    }

    void OnGUI()
    {
        if (m_GameData.HasGameFinished() == false && EndGuiActivated == true)
        {
            m_GameData.SetGameOver();
        }
        if(timeLeft > 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 20, 10, 200, 100), "" + (int)timeLeft, ClockStyle);
        }
        else
        {
            if (m_GameData.HasGameFinished() == false && EndGuiActivated == true)
            {
                m_GameData.SetGameOver();
            }
            ActivateGameOverGui();
        }
    }

    IEnumerator Sleep(float sleepTime)
    {
        yield return new WaitForSeconds(sleepTime);

        

        ActivateGameOverGui();
    }

    private void ActivateGameOverGui()
    {
        CorrectGuessedText.GetComponent<Text>().text = m_Scores.GetCurrentScore().ToString();
        WrongGuessedText.GetComponent<Text>().text = m_Scores.GetCurrentWrongScore().ToString();

        GameOverPanel.SetActive(true);
        CountryFlag.SetActive(false);
        CountryFlag1.SetActive(false);
        CountryFlag2.SetActive(false);
        EndGuiActivated = true;
    }
}
