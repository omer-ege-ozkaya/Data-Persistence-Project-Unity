using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    public static SingletonManager instance;

    public string username;
    public int bestScore;
    public string bestScoreUsername;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

        LoadBestScore();
    }

    [Serializable]
    class BestScoreStats
    {
        public int score;
        public string username;
    }

    public void SaveBestScore()
    {
        BestScoreStats bestScoreStats = new BestScoreStats();
        bestScoreStats.score = bestScore;
        bestScoreStats.username = bestScoreUsername;

        string json = JsonUtility.ToJson(bestScoreStats);

        File.WriteAllText(Application.persistentDataPath + "/savepoint.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savepoint.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScoreStats bestScoreStats = JsonUtility.FromJson<BestScoreStats>(json);
            bestScore = bestScoreStats.score;
            bestScoreUsername = bestScoreStats.username;
        }
    }
}
