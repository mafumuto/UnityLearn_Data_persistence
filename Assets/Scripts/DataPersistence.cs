using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistence : MonoBehaviour
{

    public static DataPersistence Instance;
    public string userName;
    public string _userName;
    public int bestscore = 0;
    public Dictionary<string, int> userData;

    public string path;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        path= Application.persistentDataPath + "/savefile.json";


    }

    private void Start()
    {

    }

    [System.Serializable]
    public class SaveDate
    {
        public int _bestScore;
        public string _userName;
    }

    public void SaveDataToJson()
    {
        SaveDate data = new SaveDate();
        data._bestScore = bestscore;
        data._userName = _userName;
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);

    }

    public void LoadDataToJson()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDate data = JsonUtility.FromJson<SaveDate>(json);
            bestscore = data._bestScore;
            userName = data._userName;
        }
    }
}

