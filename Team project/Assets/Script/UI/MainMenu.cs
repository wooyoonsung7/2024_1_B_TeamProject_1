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
        if (PlayerPrefs.GetInt("IsFirstLaunch", 0) == 0)    // ó�������� ��
        {
            // ó���̶�� Get�޾ƿ� Ű�� �������� �����Ƿ� (������ �� �����ϱ�) ������ 0�̱� ������ 0==0���� �Ʒ� �ڵ尡 �����
            // GameManager.Instance.InitializePlayerPrefs();   // ��� PlayerPrefs Ű�� �ʱ�ȭ�Ѵ�
            PlayerPrefs.SetInt("UnlockedStage", 1);     // �رݵ� �������� �ʱ�ȭ (1������������)
            PlayerPrefs.SetInt("TutorialDone", 0);      // Ʃ�丮�� �̿Ϸ�� �ʱ�ȭ

            for (int i = 0; i < 30; i++)
            {
                PlayerPrefs.SetInt("StarCount_" + (i + 1), 0);     // ������������ �� ���� �ʱ�ȭ (��� 0����)
            }

            PlayerPrefs.SetInt("IsFirstLaunch", 1);     // ó�� ����Ǿ����� ǥ�� (�� �Լ��� ȣ���Ҷ� ���ʽ��� ������ ����)

            PlayerPrefs.Save();

            // InitializePlayerPrefs �Լ��� ����Ǹ� Ű�� �ʱ�ȭ�ϰ� IsFirstLaunchŰ�� 1�� ����
            // ���Ŀ� GetInt�� 1�� �޾ƿ��Ƿ� 1==0�� false. ���� �ʱ�ȭ�� �� �� �ߴٸ� �ٽô� �ʱ�ȭ�� ������� �ʴ´�.
        }

        SceneManager.LoadScene("StageSelection");
    }

    public void QuitGame()
    {
        SoundManager.instance.PlaySound("Click");
        Application.Quit();
    }
}
