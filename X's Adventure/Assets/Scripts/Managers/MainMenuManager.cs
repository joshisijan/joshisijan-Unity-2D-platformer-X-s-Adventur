using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Canvas[] canvasList;

    private void Start()
    {
        ShowCanvas("MainCanvas");
    }

    public void ShowCanvas(string name)
    {
        foreach(Canvas canvas in canvasList)
        {
            if(canvas.name == name)
            {
                canvas.gameObject.SetActive(true);
            }
            else
            {
                canvas.gameObject.SetActive(false);
            }
        }
    }

    public void BackButton()
    {
        ShowCanvas("MainCanvas");
    }

    public void LevelSelection(int n)
    {
        string levelName = "Level" + n;
        SceneManager.LoadScene(levelName);
    }
}
