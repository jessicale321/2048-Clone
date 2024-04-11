using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

///-//////////////////////////////////////////
///
public class GameManager : MonoBehaviour
{
    public TileBoard board;
    public CanvasGroup gameOverScreen;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int score;

    ///-//////////////////////////////////////////
    ///
    private void Start()
    {
        NewGame();
    }

    ///-//////////////////////////////////////////
    ///
    public void NewGame()
    {
        SetScore(0);
        highScoreText.text = LoadHighScore().ToString();

        gameOverScreen.alpha = 0f;
        gameOverScreen.interactable = false;

        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true;
    }

    ///-//////////////////////////////////////////
    ///
    public void IncreaseScore(int points)
    {
        SetScore(score + points);
    }

    ///-//////////////////////////////////////////
    ///
    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();

        SaveHighScore();
    }

    ///-//////////////////////////////////////////
    ///
    private void SaveHighScore()
    {
        int highScore = LoadHighScore();

        if (score > highScore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    ///-//////////////////////////////////////////
    ///
    private int LoadHighScore()
    {
        return PlayerPrefs.GetInt("highscore", 0);
    }

    ///-//////////////////////////////////////////
    ///
    public void GameOver()
    {
        board.enabled = false;
        gameOverScreen.interactable = true;

        StartCoroutine(Fade(gameOverScreen, 1f, 1f));
    }

    ///-//////////////////////////////////////////
    ///
    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }
}
