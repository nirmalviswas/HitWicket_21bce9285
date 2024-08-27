using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    public Button startGameButton;
    public Text titleText;
    public Text subTitleText;

    private void Start()
    {
        // Initialize UI elements
        startGameButton.onClick.AddListener(StartGame);
        titleText.text = "Welcome to Doofus Game!";
        subTitleText.text = "Tap to start the game!";
    }

    private void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("GameScene");
    }
}
