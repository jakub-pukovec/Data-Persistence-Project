using System;
using System.IO;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager Instance { get; private set; }

    private BestScore _bestScore;
    public BestScore BestScore
    {
        get
        {
            if (_bestScore == null)
            {
                _bestScore = LoadBestScore();
            }
            return _bestScore;
        }
    }
    public string PlayerName { get; internal set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public string BestScoreText => $"Best Score : { BestScore.PlayerName } : { BestScore.HighScore }";
    private BestScore LoadBestScore()
    {
        var path = GetHightScorePah();
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            return JsonUtility.FromJson<BestScore>(json);
        }

        return new BestScore();
    }

    public void SaveScore(BestScore bestScore)
    {
        _bestScore = bestScore;

        var json = JsonUtility.ToJson(bestScore);
        File.WriteAllText(GetHightScorePah(), json);
    }

    private static string GetHightScorePah()
    {
        return Application.persistentDataPath + "/highScore.json";
    }
}
