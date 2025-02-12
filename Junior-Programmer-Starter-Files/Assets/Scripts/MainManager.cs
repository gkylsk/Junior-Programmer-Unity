using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance { get; private set; } // encapsulation

    public Color TeamColor;

    private void Awake()
    {
        // singleton pattern
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    //data persistance between sessions

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data =  JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
}
