using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDownCanvas : MonoBehaviour
{
    public Text counterText;

    int count = 3;

    private void OnEnable()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while (count > 0) {
            counterText.text = Convert.ToString(count);
            count--;
            yield return new WaitForSecondsRealtime(1);
        }
        counterText.text = "Go";
        count = 3;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
