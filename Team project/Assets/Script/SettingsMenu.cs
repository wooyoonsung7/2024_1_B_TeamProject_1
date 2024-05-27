using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{

    // UI ��ҵ��� �����ϱ� ���� public ���� ����
    public Button continueButton; // ���� ����ϱ� ��ư
    public Button quitButton; // ������ ��ư
    public Slider volumeSlider; // ���� ���� �����̴�
    public GameObject settingsPanel; // ���� �޴� �г�


    void Start()
    {
        // �����̴��� �ʱⰪ�� ����� ������ �����ϰų� �⺻��(1f)���� ����
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 1f);

        // ������ �߰�: ��ư Ŭ���̳� �����̴� �� ���� �� ȣ��� �Լ��� ���
        continueButton.onClick.AddListener(ContinueGame); // continueButton Ŭ�� �� ContinueGame �Լ� ȣ��
        quitButton.onClick.AddListener(QuitGame); // quitButton Ŭ�� �� QuitGame �Լ� ȣ��
        volumeSlider.onValueChanged.AddListener(SetVolume); // volumeSlider �� ���� �� SetVolume �Լ� ȣ��

        // ���� �� ���� �޴��� ��Ȱ��ȭ
        settingsPanel.SetActive(false);
    }

  
    void Update()
    {
        // ESC Ű �Է��� �����Ͽ� ���� �޴��� ���
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettingsMenu();
        }
    }

    public void ToggleSettingsMenu()
    {
        // ���� �г��� Ȱ��/��Ȱ�� ���¸� ����
        settingsPanel.SetActive(!settingsPanel.activeSelf);

        // ���� �޴��� Ȱ��ȭ�Ǹ� ������ �Ͻ� ����, ��Ȱ��ȭ�Ǹ� ������ �簳
        if (settingsPanel.activeSelf)
        {
            Time.timeScale = 0f; // ���� �Ͻ� ����
        }
        else
        {
            Time.timeScale = 1f; // ���� �簳
        }
    }

    public void ContinueGame()
    {
        // ���� �޴��� ��Ȱ��ȭ�ϰ� ������ �簳
        settingsPanel.SetActive(false);
        Time.timeScale = 1f; // ���� �簳
    }

    public void QuitGame()
    {
        // ���� ����
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        // ����� ������ �����ϰ�, ����� ���� PlayerPrefs�� ����
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume); // ���� ���� ����
    }
}



