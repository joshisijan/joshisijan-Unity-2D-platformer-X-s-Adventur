using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlockedCheck : MonoBehaviour
{
    public GameStats gameStats;

    MyPrefs myPrefs;
    private void Awake()
    {
        myPrefs = FindObjectOfType<MyPrefs>();

        Button b = gameObject.GetComponent<Button>();
        if (Convert.ToInt32(gameObject.transform.name) <= myPrefs.GetLevel())
        {
            b.interactable = true;
        }
        else
        {
            b.interactable = false;
        }
    }
}
