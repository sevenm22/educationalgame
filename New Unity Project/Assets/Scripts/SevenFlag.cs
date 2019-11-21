using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenFlag : MonoBehaviour {

    private FlagManager m_FlagManager;

    private bool LoadNewGame = false;
    private bool ButtonPressed = false;


    private Checkbox m_Checkbox;
    private CurrentGameData m_GameData;
    [HideInInspector]
    public int FlagIndex = 0;

    private SurvivalLives m_SurvivalLifes;

    [HideInInspector]
	// Use this for initialization
	void Start () {
        m_FlagManager = GameObject.Find("Main Camera").GetComponent<FlagManager>() as FlagManager;
        m_Checkbox = GameObject.Find("Checkbox").GetComponent<Checkbox>() as Checkbox;
        m_GameData = GameObject.Find("GameDataObject").GetComponent<CurrentGameData>() as CurrentGameData;
        m_SurvivalLifes = GameObject.Find("Main Camera").GetComponent<SurvivalLives>() as SurvivalLives;
    }
	
	// Update is called once per frame
	void Update () {

        if(LoadNewGame == true && ButtonPressed == false)
        {
            if (m_Checkbox.AnimationCompleted())
            {
                m_FlagManager.LoadNextGame();
                LoadNewGame = false;
                m_Checkbox.Clear();
            }
        }
		
	}

    private void OnMouseDown()
    {
        if(ButtonPressed == false && m_GameData.HasGameFinished() == false)
        {
            if (FlagIndex == m_GameData.GetFinalFlagIndex())
            {
                m_Checkbox.Correct();
            }
            else
            {

                if(GameSettings.Instance.GetGameMode() == GameSettings.EGameMode.SURVIVAL_MODE)
                {
                    m_SurvivalLifes.RemoveLife();
                }
                m_Checkbox.Wrong();
            }
            LoadNewGame = true;
        }

        StartCoroutine(Sleep());
    }

    public void SetFlagIndex(int index)
    {
        FlagIndex = index;
    }

    IEnumerator Sleep()
    {
        ButtonPressed = true;
        yield return new WaitForSeconds(0.5f);
        ButtonPressed = false;
    }
}
