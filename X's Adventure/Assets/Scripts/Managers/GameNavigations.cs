using UnityEngine.SceneManagement;
using UnityEngine;

public class GameNavigations : MonoBehaviour
{
    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
