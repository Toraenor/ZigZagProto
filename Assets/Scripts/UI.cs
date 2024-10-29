using System.Collections;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text bestScoreText;
    [SerializeField] TMP_Text gamesPlayedText;
    [SerializeField] GameObject MainMenu;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    void Start()
    {
        GameManager.OnScoreChanged += UpdateScoreText;
        bestScoreText.text = "Best Score : " + GameManager.Instance.BestScore.ToString();
        gamesPlayedText.text = "Games Played : " + GameManager.Instance.GamesPlayed.ToString();
    }

    private void OnDestroy()
    {
        GameManager.OnScoreChanged -= UpdateScoreText;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && MainMenu.activeSelf) 
        {
            MainMenu.SetActive(false);
            scoreText.gameObject.SetActive(true);
            Time.timeScale = 1;
            StartCoroutine(GoRoutine());
        }
    }

    void UpdateScoreText(int score)
    {
        scoreText.text = "Score : " + score.ToString();
    }

    private IEnumerator GoRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject.FindWithTag("Player").GetComponent<Player>().go = true;
    }
}
