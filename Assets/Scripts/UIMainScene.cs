using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainScene : MonoBehaviour
{
    public void ReturnToStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
