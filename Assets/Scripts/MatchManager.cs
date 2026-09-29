using UnityEngine;
using TMPro;

public class MatchManager : MonoBehaviour
{
    private int player1Score = 0;
    private int player2Score = 0;

    private int player1Rounds = 0;
    private int player2Rounds = 0;

    public int pointsToWinRound = 5;
    public int roundsToWinMatch = 2;

    public Bull ball;

    public TMP_Text scoreText;
    public TMP_Text roundsText;
    public TMP_Text winnerText;

    public GameObject startPanel;

    public GameObject restartButton;
    public GameObject exitButton;

    private bool gameOver = false;

    void Start()
    {
        player1Score = 0;
        player2Score = 0;
        player1Rounds = 0;
        player2Rounds = 0;

        gameOver = false;

        winnerText.text = "";

        restartButton.SetActive(false);
        exitButton.SetActive(false);

        startPanel.SetActive(true);

        Time.timeScale = 0f;

        StopBall();

        UpdateScoreText();
        UpdateRoundsText();
    }

    public void StartGame()
    {
        startPanel.SetActive(false);

        player1Score = 0;
        player2Score = 0;
        player1Rounds = 0;
        player2Rounds = 0;

        gameOver = false;

        winnerText.text = "";

        restartButton.SetActive(false);
        exitButton.SetActive(false);

        UpdateScoreText();
        UpdateRoundsText();

        Time.timeScale = 1f;

        ball.ResetBall();
    }

    public void Player1Scored()
    {
        if (gameOver)
            return;

        player1Score++;

        CheckRoundWinner();
    }

    public void Player2Scored()
    {
        if (gameOver)
            return;

        player2Score++;

        CheckRoundWinner();
    }

    void CheckRoundWinner()
    {
        if (player1Score >= pointsToWinRound)
        {
            player1Rounds++;

            player1Score = 0;
            player2Score = 0;

            CheckMatchWinner();
        }
        else if (player2Score >= pointsToWinRound)
        {
            player2Rounds++;

            player1Score = 0;
            player2Score = 0;

            CheckMatchWinner();
        }

        UpdateScoreText();
        UpdateRoundsText();

        if (!gameOver)
        {
            ball.ResetBall();
        }
    }

    void CheckMatchWinner()
    {
        if (player1Rounds >= roundsToWinMatch)
        {
            winnerText.text = "Синий игрок победил!";
            gameOver = true;

            StopBall();

            restartButton.SetActive(true);
            exitButton.SetActive(true);
        }
        else if (player2Rounds >= roundsToWinMatch)
        {
            winnerText.text = "Красный игрок победил!";
            gameOver = true;

            StopBall();

            restartButton.SetActive(true);
            exitButton.SetActive(true);
        }
    }

    void StopBall()
    {
        ball.rb.linearVelocity = Vector2.zero;
        ball.transform.position = Vector2.zero;
    }

    void UpdateScoreText()
    {
        scoreText.text = player1Score + " : " + player2Score;
    }

    void UpdateRoundsText()
    {
        int currentRound = player1Rounds + player2Rounds + 1;

        if (!gameOver)
        {
            roundsText.text =
                "Раунд " + currentRound +
                " | Раунды: " +
                player1Rounds + " : " + player2Rounds;
        }
        else
        {
            roundsText.text =
                "Матч завершен | Раунды: " +
                player1Rounds + " : " + player2Rounds;
        }
    }

    public void RestartGame()
    {
        player1Score = 0;
        player2Score = 0;

        player1Rounds = 0;
        player2Rounds = 0;

        gameOver = false;

        winnerText.text = "";

        restartButton.SetActive(false);
        exitButton.SetActive(false);

        UpdateScoreText();
        UpdateRoundsText();

        Time.timeScale = 1f;

        ball.ResetBall();
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}