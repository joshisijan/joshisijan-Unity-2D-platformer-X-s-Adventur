using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyPrefs : MonoBehaviour
{
    public static MyPrefs instance;

    public GameStats gameStats;
 
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public int GetSoundOption()
    {
        if (!PlayerPrefs.HasKey("soundOption"))
            return 1;
        int n = PlayerPrefs.GetInt("soundOption");
        return n;
    }

    public void SetSoundOption(int n)
    {
        PlayerPrefs.SetInt("soundOption", n);
    }

    public void SetVolume(string x, float n)
    {
        PlayerPrefs.SetFloat(x + "Volume", n);
    }

    public float GetVolume(string x)
    {
        if (!PlayerPrefs.HasKey(x + "Volume"))
        {
            if (x == "sound")
                return 0.25f;
            else if (x == "music")
                return 0.25f;
            return 0.25f;
        }
            
        float n = PlayerPrefs.GetFloat(x + "Volume");
        return n;
    }


    public int GetLevel()
    {
        if (!PlayerPrefs.HasKey("currentLevel"))
            return 1;

        int n = PlayerPrefs.GetInt("currentLevel");
        return n;
    }

    public void SetLevel(int n, bool navToo = false)
    {
        bool overflown = false;
        if (n > gameStats.lastLevel)
        {
            n = gameStats.lastLevel;
            overflown = true;
        }

        PlayerPrefs.SetInt("currentLevel", n);

        if (navToo == true)
        {
            if (overflown)
            {
                StartCoroutine(LoadLevelAsync("CompletedCredits"));
                return;
            }
            string level = "Level" + n;
            StartCoroutine(LoadLevelAsync(level));
        }
    }

    IEnumerator LoadLevelAsync(string name)
    {
        GameObject progressCanvas;
        progressCanvas = GameObject.FindGameObjectWithTag("ProgressCanvas");
        Slider progressSlider = progressCanvas.GetComponentInChildren<Slider>();
        Text progressText = progressCanvas.GetComponentInChildren<Text>();
        progressCanvas.GetComponent<Canvas>().enabled = true;
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressSlider.value = progress;
            progressText.text = Convert.ToString(Convert.ToInt32(progress * 100)) + "%";
            yield return null;
        }
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteKey("currentLevel");
    }
}
