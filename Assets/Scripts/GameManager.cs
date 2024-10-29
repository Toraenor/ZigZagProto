using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static private GameManager instance;
    static public GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject(nameof(GameManager));
                obj.AddComponent<GameManager>();
            }

            return instance;
        }
    }

    public static event Action<int> OnScoreChanged;
    private int score = 0;

    public int GamesPlayed { get; private set; } = 0;
    public int BestScore { get; private set; } = 0;
    public int Score { get { return score; } set 
        {
            score = value;
            OnScoreChanged?.Invoke(score);
        } 
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            transform.parent = null;
            DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            Destroy(instance);
            return;
        }
    }

    public void GameOver()
    {
        if(score > BestScore)
        {
            BestScore = score;
        }
        score = 0;
        GamesPlayed++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
