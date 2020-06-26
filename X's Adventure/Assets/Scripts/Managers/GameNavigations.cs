using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameNavigations : MonoBehaviour
{

    public Canvas progressCanvas;

    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        Time.timeScale = 1;
        StartCoroutine(LoadLevelAsync(currentSceneName));
    }

    public void LoadScene(string name)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadLevelAsync(name));
    }

    IEnumerator LoadLevelAsync(string name)
    {
        Slider progressSlider = progressCanvas.GetComponentInChildren<Slider>();
        Text progressText = progressCanvas.GetComponentInChildren<Text>();
        progressCanvas.gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressSlider.value = progress;
            progressText.text = Convert.ToString(Convert.ToInt32(progress * 100)) + "%";
            yield return null;
        }
    }



    public void WatchAd()
    {
        Debug.Log("watching ad");
    }
}
