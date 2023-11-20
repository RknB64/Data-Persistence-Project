using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public int bestScore;
    public string maxScorer;
    public string currentPlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBest();

    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string maxScorer;
    }
    
    public void SaveBest()
    {
        SaveData data = new SaveData();
        data.maxScorer = maxScorer;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

    public void LoadBest()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maxScorer = data.maxScorer;
            bestScore = data.bestScore;
        }
    }

    private void OnApplicationQuit()
    {
        SaveBest();
    }
}
