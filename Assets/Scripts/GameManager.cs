using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;
    public BallController ballController;
    public GameObject screenEndGame;
    public TextMeshProUGUI textEndGame;

    public int playerScore, enemyScore;
    public int winPoints = 5;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    private void Start() => ResetGame();

    public void ResetGame()
    {
        playerPaddle.position = new Vector3(7, 0, 0);
        enemyPaddle.position = new Vector3(-7, 0, 0);

        playerScore = enemyScore = 0;
        textPointsPlayer.text = textPointsEnemy.text = "0";

        ballController.ResetBall();
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (enemyScore >= winPoints || playerScore >= winPoints)
        {
            StartCoroutine(EndGameRoutine());
        }
    }

    
    private IEnumerator EndGameRoutine()
    {
        screenEndGame.SetActive(true);

        var save = SaveController.Instance;
        string winner = save.GetName(playerScore > enemyScore);
        textEndGame.text = $"Win! {winner}";

        save.SaveWinner(winner);

        
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu"); 
    }
}
