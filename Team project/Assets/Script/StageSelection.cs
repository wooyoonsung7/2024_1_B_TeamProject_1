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

    // �� �Ʒ����ʹ� ����ȭ�鿡�� ���̴� �Լ���
    public void OnClickStart()
    {
        SceneManager.LoadScene("StageSelection");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
