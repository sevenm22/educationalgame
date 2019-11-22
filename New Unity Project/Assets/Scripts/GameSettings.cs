using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{

    private Dictionary<EContinentType, string> _SceneName = new Dictionary<EContinentType, string>();

    public enum EGameMode
    {
        NOTE_SET,
        TIME_TRAIL_MODE, //play until time expired
        SURVIVAL_MODE, //three lives
        SHORT_MODE, //15 questions
    }

    public enum EContinentType
    {
        E_NOT_SET = 0,
        E_EUROPE,
        E_ASIA,
        E_AFRICA,
    };

    private EGameMode _GameMode;
    private EContinentType _Continent;
    private string _ContinentName;

    public static GameSettings Instance;
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
        SetSceneNameAntType();
        _GameMode = EGameMode.NOTE_SET;
        _Continent = EContinentType.E_NOT_SET;   
    }

    private void SetSceneNameAntType()
    {
        _SceneName.Add(EContinentType.E_EUROPE, "GameScene");
        _SceneName.Add(EContinentType.E_ASIA, "GameScene");
        _SceneName.Add(EContinentType.E_AFRICA, "GameScene");
    }

    public string GetContinentSceneName()
    {
        string name;

        if(_SceneName.TryGetValue(_Continent, out name))
        {
            return name;
        }
        else
        {
            Debug.Log("ERROR: CONTINENT SCENE NOT FOUND");
           return ("ERROR: CONTINENT SCENE NOT FOUND");
        }
    }

    public void SetContinentType(EContinentType type)
    {
        _Continent = type;
    }

    public void SetGameMode(EGameMode mode)
    {
        _GameMode = mode;
    }

    public EGameMode GetGameMode()
    {
        return _GameMode;
    }
    public EContinentType GetEContinentType()
    {
        return _Continent;
    }

    public void SetContinentName(string Name)
    {
        SetContinentType(GetContinentTypeFromString(Name));
        _ContinentName = Name;
    }

    private EContinentType GetContinentTypeFromString(string type)
    {
        switch (type)
        {
            case "EUROPE": return EContinentType.E_EUROPE;
            case "ASIA": return EContinentType.E_ASIA;
            case "AFRICA": return EContinentType.E_AFRICA;
            default: return EContinentType.E_NOT_SET;
        }
    }
}
