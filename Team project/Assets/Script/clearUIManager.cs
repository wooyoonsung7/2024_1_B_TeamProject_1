using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearUIManager : MonoBehaviour
{
    public GameObject clearPanel; // 클리어 UI 패널을 연결

    // 클리어 UI를 활성화하는 메서드
    public void ShowClearUI()
    {
        clearPanel.SetActive(true);
    }

    // 클리어 UI를 비활성화하는 메서드
    public void HideClearUI()
    {
        clearPanel.SetActive(false);
    }
}
