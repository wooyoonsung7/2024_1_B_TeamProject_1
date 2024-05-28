using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                     //UI 사용하기 위해추가
using UnityEngine.SceneManagement;                        //UI 씬 매니팅을 하기위해 추가


public class MainScene : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("TestScene");

    }
}
