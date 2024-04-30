using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string SceneName;

    public void LoadScene()
    {
        Initiate.Fade(SceneName, Color.black, 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
