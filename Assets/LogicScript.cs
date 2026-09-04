using UnityEngine;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
}
