using UnityEngine;

public class Restart : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        Time.timeScale = 1.0f;
    }
}
