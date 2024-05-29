using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearUIScript : MonoBehaviour
{
    public GameObject clearUI; // 클리어 UI 오브젝트
    public string TestSceneTwo; // 다음 씬 이름

   
    void Start()
    {
        clearUI.SetActive(false); // 처음에는 클리어 UI 비활성화
    }

    public void ShowClearUI()
    {
        clearUI.SetActive(true); // 클리어 UI 활성화
    }

    public void OnNextLevelButton()
    {
        SceneManager.LoadScene(TestSceneTwo); // 다음 씬 로드
    }

    public void OnRetryButton()
    {
        SceneManager.LoadScene("TestScene"); // 현재 씬 다시 로드
    }
}
