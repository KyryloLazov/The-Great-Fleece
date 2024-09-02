using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instace
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UI Manager is not present!");
            }
            
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void Restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
