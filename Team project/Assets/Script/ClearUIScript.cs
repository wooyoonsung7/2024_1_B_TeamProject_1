using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearUIScript : MonoBehaviour
{
    public GameObject clearUI; // Ŭ���� UI ������Ʈ
    public string TestSceneTwo; // ���� �� �̸�

   
    void Start()
    {
        clearUI.SetActive(false); // ó������ Ŭ���� UI ��Ȱ��ȭ
    }

    public void ShowClearUI()
    {
        clearUI.SetActive(true); // Ŭ���� UI Ȱ��ȭ
    }

    public void OnNextLevelButton()
    {
        SceneManager.LoadScene(TestSceneTwo); // ���� �� �ε�
    }

    public void OnRetryButton()
    {
        SceneManager.LoadScene("TestScene"); // ���� �� �ٽ� �ε�
    }
}
