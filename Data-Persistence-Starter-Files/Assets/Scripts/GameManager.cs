using System.Collections;
using System.Collections.Generic;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text bestScoreAndName;
    public string playerName;
    public string highScorePlayer;
    public int highestScore = 0;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(bestScoreAndName != null)
        {
            bestScoreAndName.text = "Best Score: " + highScorePlayer + ":" + highestScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadName(string name)
    {
        playerName = name;
    }
    public void StartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highestScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = highScorePlayer;
        data.highestScore = highestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.dataPath + "/saveFile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScorePlayer = data.playerName;
            highestScore = data.highestScore;
        }
    }
}
