using UnityEngine;
using TMPro;

public class MatchManager : MonoBehaviour
{
    private int player1Score = 0;
    private int player2Score = 0;

    private int player1Rounds = 0;
    private int player2Rounds = 0;

    public int pointsToWinRound = 10;
    public int roundsToWinMatch = 2;

    public Bull ball;

    public TMP_Text scoreText;
    public TMP_Text roundsText;
    public TMP_Text winnerText;

    public GameObject startPanel;

    private bool gameOver = false;

    void Start()
    {
        winnerText.text = "";

        startPanel.SetActive(true);

        Time.timeScale = 0f;

        UpdateScoreText();
        UpdateRoundsText();
    }

    public void StartGame()
    {
        startPanel.SetActive(false);

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
        // Синий игрок выиграл раунд
        if (player1Score >= pointsToWinRound)
        {
            player1Rounds++;

            player1Score = 0;
            player2Score = 0;

            CheckMatchWinner();
        }

        // Красный игрок выиграл раунд
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
        }
        else if (player2Rounds >= roundsToWinMatch)
        {
            winnerText.text = "Красный игрок победил!";
            gameOver = true;
            StopBall();
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
            roundsText.text = "Раунд " + currentRound +
                              " | Раунды: " +
                              player1Rounds + " : " + player2Rounds;
        }
        else
        {
            roundsText.text = "Матч завершен | Раунды: " +
                              player1Rounds + " : " + player2Rounds;
        }
    }
}