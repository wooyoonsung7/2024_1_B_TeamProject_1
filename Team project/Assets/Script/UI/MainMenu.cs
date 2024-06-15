using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        SoundManager.instance.PlaySound("MainBGM");
    }

    public void OnClickStart()
    {
        SoundManager.instance.PlaySound("Click");
        if (PlayerPrefs.GetInt("IsFirstLaunch", 0) == 0)    // 처음실행일 때
        {
            // 처음이라면 Get받아올 키가 존재하지 않으므로 (선언이 안 됐으니까) 무조건 0이기 때문에 0==0으로 아래 코드가 실행됨
            // GameManager.Instance.InitializePlayerPrefs();   // 모든 PlayerPrefs 키를 초기화한다
            PlayerPrefs.SetInt("UnlockedStage", 1);     // 해금된 스테이지 초기화 (1스테이지부터)
            PlayerPrefs.SetInt("TutorialDone", 0);      // 튜토리얼 미완료로 초기화

            for (int i = 0; i < 30; i++)
            {
                PlayerPrefs.SetInt("StarCount_" + (i + 1), 0);     // 스테이지마다 별 개수 초기화 (모두 0으로)
            }

            PlayerPrefs.SetInt("IsFirstLaunch", 1);     // 처음 실행되었음을 표시 (이 함수를 호출할때 최초실행 구분을 위해)

            PlayerPrefs.Save();

            // InitializePlayerPrefs 함수가 실행되면 키를 초기화하고 IsFirstLaunch키를 1로 선언
            // 이후에 GetInt로 1을 받아오므로 1==0이 false. 따라서 초기화를 한 번 했다면 다시는 초기화가 진행되지 않는다.
        }

        SceneManager.LoadScene("StageSelection");
    }

    public void QuitGame()
    {
        SoundManager.instance.PlaySound("Click");
        Application.Quit();
    }
}
