using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Text gameOverText;
    public Text scoreText;
    public Button restartButton;
    public Button quitButton;

    private void Start()
    {
        // Initialize UI elements
        gameOverText.text = "Game Over!";
        scoreText.text = "Your score: " + GameManager.instance.score;
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void RestartGame()
    {
        // Restart the game
        SceneManager.LoadScene("GameScene");
    }

    private void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }
}