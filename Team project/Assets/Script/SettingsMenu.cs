using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{

    // UI 요소들을 참조하기 위한 public 변수 선언
    public Button continueButton; // 게임 계속하기 버튼
    public Button quitButton; // 나가기 버튼
    public Slider volumeSlider; // 음량 설정 슬라이더
    public GameObject settingsPanel; // 설정 메뉴 패널


    void Start()
    {
        // 슬라이더의 초기값을 저장된 값으로 설정하거나 기본값(1f)으로 설정
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 1f);

        // 리스너 추가: 버튼 클릭이나 슬라이더 값 변경 시 호출될 함수를 등록
        continueButton.onClick.AddListener(ContinueGame); // continueButton 클릭 시 ContinueGame 함수 호출
        quitButton.onClick.AddListener(QuitGame); // quitButton 클릭 시 QuitGame 함수 호출
        volumeSlider.onValueChanged.AddListener(SetVolume); // volumeSlider 값 변경 시 SetVolume 함수 호출

        // 시작 시 설정 메뉴를 비활성화
        settingsPanel.SetActive(false);
    }

  
    void Update()
    {
        // ESC 키 입력을 감지하여 설정 메뉴를 토글
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettingsMenu();
        }
    }

    public void ToggleSettingsMenu()
    {
        // 설정 패널의 활성/비활성 상태를 반전
        settingsPanel.SetActive(!settingsPanel.activeSelf);

        // 설정 메뉴가 활성화되면 게임을 일시 정지, 비활성화되면 게임을 재개
        if (settingsPanel.activeSelf)
        {
            Time.timeScale = 0f; // 게임 일시 정지
        }
        else
        {
            Time.timeScale = 1f; // 게임 재개
        }
    }

    public void ContinueGame()
    {
        // 설정 메뉴를 비활성화하고 게임을 재개
        settingsPanel.SetActive(false);
        Time.timeScale = 1f; // 게임 재개
    }

    public void QuitGame()
    {
        // 게임 종료
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        // 오디오 볼륨을 설정하고, 변경된 값을 PlayerPrefs에 저장
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume); // 설정 값을 저장
    }
}



