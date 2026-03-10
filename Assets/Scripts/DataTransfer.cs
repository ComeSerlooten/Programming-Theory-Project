using System;
using System.IO;
using System.Net;
using UnityEngine;


public class DataTransfer : MonoBehaviour
{
    public string playerName;
    public int highestScore = 0;
    public string highestScorePlayer = "";
    public static DataTransfer instance;

    private void Awake()
    {
        if(instance != null) Destroy(this);
        instance = this;
        
        DontDestroyOnLoad(this);
        
        Load();
        if (playerName == "") playerName = "Player";
    }

    private void OnDestroy()
    {
        Save();
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.name = playerName;
        data.highestScore = highestScore;
        data.highestScorePlayer = highestScorePlayer;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.name;
            highestScore = data.highestScore;
            highestScorePlayer = data.highestScorePlayer;

        }
    }
    
    [Serializable]
    public class SaveData
    {
        public string name = "Player";
        public int highestScore = 0;
        public string highestScorePlayer = "None";
    }
}
