using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickStart()
    {
        if (PlayerPrefs.GetInt("IsFirstLaunch", 0) == 0)    // ó�������� ��
        {
            // ó���̶�� Get�޾ƿ� Ű�� �������� �����Ƿ� (������ �� �����ϱ�) ������ 0�̱� ������ 0==0���� �Ʒ� �ڵ尡 �����
            GameManager.Instance.InitializePlayerPrefs();   // ��� PlayerPrefs Ű�� �ʱ�ȭ�Ѵ�

            // InitializePlayerPrefs �Լ��� ����Ǹ� Ű�� �ʱ�ȭ�ϰ� IsFirstLaunchŰ�� 1�� ����
            // ���Ŀ� GetInt�� 1�� �޾ƿ��Ƿ� 1==0�� false. ���� �ʱ�ȭ�� �� �� �ߴٸ� �ٽô� �ʱ�ȭ�� ������� �ʴ´�.
        }

        SceneManager.LoadScene("StageSelection");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
