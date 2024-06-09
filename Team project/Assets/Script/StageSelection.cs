using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelection : MonoBehaviour
{
    public void OnClickBack()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("StageSelection");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
