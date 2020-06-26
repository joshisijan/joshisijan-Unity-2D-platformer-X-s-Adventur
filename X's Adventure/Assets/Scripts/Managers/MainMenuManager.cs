using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Canvas[] canvasList;
    public Toggle soundOption;
    public Slider soundVolume;
    public Slider musicVolume;
    public Text continueButtonText;
    public Canvas progressCanvas;

    MyPrefs myPrefs;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        myPrefs = FindObjectOfType<MyPrefs>();
    }

    private void Start()
    {
        ShowCanvas("MainCanvas");

        //sound option
        if(myPrefs.GetSoundOption() == 1)
            soundOption.isOn = true;
        else if(myPrefs.GetSoundOption() == 0)
            soundOption.isOn = false;
        audioManager.isOn = soundOption.isOn;

        //sound volume
        soundVolume.value = myPrefs.GetVolume("sound");
        audioManager.SetSoundVolume(soundVolume.value);

        //music volume
        musicVolume.value = myPrefs.GetVolume("music");
        audioManager.SetMusicVolume(musicVolume.value);

        if(myPrefs.GetLevel() > 1)
        {
            continueButtonText.text = "Continue";
        }
        else
        {
            continueButtonText.text = "New Game";
        }
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

    public void ShowCanvasOnTop(string name)
    {
        foreach (Canvas canvas in canvasList)
        {
            if (canvas.name == name)
            {
                canvas.gameObject.SetActive(true);
            }
        }
    }

    public void HideCanvasOnTop(string name)
    {
        foreach (Canvas canvas in canvasList)
        {
            if (canvas.name == name)
            {
                canvas.gameObject.SetActive(false);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void SoundOption()
    {
        audioManager.isOn = soundOption.isOn;
        if (soundOption.isOn)
            myPrefs.SetSoundOption(1);
        else
            myPrefs.SetSoundOption(0);
    }

    public void SoundVolumeChange()
    {
        myPrefs.SetVolume("sound", soundVolume.value);
        audioManager.SetSoundVolume(soundVolume.value);
    }

    public void MusicVolumeChange()
    {
        myPrefs.SetVolume("music", musicVolume.value);
        audioManager.SetMusicVolume(musicVolume.value);
    }

    public void ResetProgress()
    {
        myPrefs.ResetGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelection(int n)
    {
        string levelName = "Level" + n;
        StartCoroutine(LoadLevelAsync(levelName));
    }

    public void ContinueLevel()
    {
        string levelName = "Level" + myPrefs.GetLevel();
        StartCoroutine(LoadLevelAsync(levelName));
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
}
