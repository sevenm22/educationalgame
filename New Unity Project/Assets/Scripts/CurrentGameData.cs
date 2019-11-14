using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentGameData : MonoBehaviour
{
    [HideInInspector]
    public int FirstFlagIndex = 0;
    public int SecondFlagIndex;
    public int FinalFlagIndex;

    private int PrevFinalFlagIndex;
    private int CountriesPergame = 60; //How many countries should be in one game.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickCountriesForGame()
    {
        int PickedCountryNumber = 0;
    }

}

