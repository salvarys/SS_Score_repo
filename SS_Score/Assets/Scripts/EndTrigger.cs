
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public delegate void levelCompleted();
    public static levelCompleted OnLevelCompleted; 

    public GameManager gameManager;

    void OnTriggerEnter()
    {
        OnLevelCompleted?.Invoke();
        gameManager.CompleteLevel();
        Invoke("LoadNextLevel", 2);
    }
    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
