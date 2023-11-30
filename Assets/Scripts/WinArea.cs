using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WinArea : MonoBehaviour
{
    public GameObject winPanel;
    public TextMeshProUGUI winText;

    private bool isGameOver = false;

    private void Start()
    {
        // Ensure the winPanel is initially inactive
        winPanel.SetActive(false);
    }
        private void Update()
    {
        // Check for spacebar input to reload the scene
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            ReloadLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Set a flag to indicate game over
            isGameOver = true;

            // Pause the game
            Time.timeScale = 0f;

            // Activate the win panel
            winPanel.SetActive(true);

            // Set the win text using TextMeshPro
            winText.text = "You Win!";
        }
    }

    private void ReloadLevel()
    {
        // Unpause the game before reloading the level
        Time.timeScale = 1f;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}