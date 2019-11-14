﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [System.Serializable]

    public struct CountryData
    {
        public string Name;
        public Sprite Flag;
        public bool Guessed;
        public bool BeenQuestioned;
    }

    public CountryData[] EuropeanCountryDataSet;
    public CountryData[] AsiaCountryDataSet;
    public CountryData[] AfricaCountryDataSet;
    [HideInInspector]
    public CountryData[] CountrySetPerGame;
    [HideInInspector]
    public CountryData[] CountryDataSet;

    public static GameData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignArrayOfCountry()
    {
        CountryDataSet = new CountryData[EuropeanCountryDataSet.Length];
        EuropeanCountryDataSet.CopyTo(CountryDataSet, 0);

    }

}
