using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{

    public Image LoadBar;

    void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Main");

        while (!asyncOperation.isDone)
        {
            LoadBar.fillAmount = asyncOperation.progress;

            yield return new WaitForEndOfFrame();
        }
    }
}
