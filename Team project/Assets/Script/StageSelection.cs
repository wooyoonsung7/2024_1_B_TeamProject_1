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

    public void StartStage(int stageNum)
    {
        string stageName = "Stage " + stageNum;
        SceneManager.LoadScene(stageName);
    }

    // 이 아래부터는 메인화면에서 쓰이는 함수임
    public void OnClickStart()
    {
        SceneManager.LoadScene("StageSelection");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
