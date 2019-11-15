using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenFlag : MonoBehaviour {

    private FlagManager m_FlagManager;
    private bool LoadNewGame = false;
    private bool ButtonPressed = false;

	// Use this for initialization
	void Start () {
        m_FlagManager = GameObject.Find("Main Camera").GetComponent<FlagManager>() as FlagManager;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(LoadNewGame == true)
        {
            m_FlagManager.LoadNextGame();
            LoadNewGame = false;
        }
		
	}

    private void OnMouseDown()
    {
        //if(ButtonPressed == false)
        {
            LoadNewGame = true;
        }
    }
}
