using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearUIManager : MonoBehaviour
{
    public GameObject clearPanel; // Ŭ���� UI �г��� ����

    // Ŭ���� UI�� Ȱ��ȭ�ϴ� �޼���
    public void ShowClearUI()
    {
        clearPanel.SetActive(true);
    }

    // Ŭ���� UI�� ��Ȱ��ȭ�ϴ� �޼���
    public void HideClearUI()
    {
        clearPanel.SetActive(false);
    }
}
