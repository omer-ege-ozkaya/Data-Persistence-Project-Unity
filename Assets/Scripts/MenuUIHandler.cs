using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI nameInput;
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        SingletonManager.instance.LoadBestScore();
        string bestScoreUsername = SingletonManager.instance.bestScoreUsername;
        int bestScore = SingletonManager.instance.bestScore;
        bestScoreText.text = $"Best Score : {bestScoreUsername} : {bestScore}";
    }

    public void StartNewGame()
    {
        SingletonManager.instance.username = nameInput.text;
        if (SingletonManager.instance.bestScore == 0)
        {
            SingletonManager.instance.bestScoreUsername = SingletonManager.instance.username;
        }
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
