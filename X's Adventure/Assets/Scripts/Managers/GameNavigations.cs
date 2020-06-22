using UnityEngine.SceneManagement;
using UnityEngine;

public class GameNavigations : MonoBehaviour
{
    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
