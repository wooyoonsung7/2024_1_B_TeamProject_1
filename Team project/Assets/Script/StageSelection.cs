using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelection : MonoBehaviour
{
    //public string[] StageList = new string[30];
    //public Button[] buttons;
    public ButtonStar[] buttons;    // 원래는 버튼 배열이었는데 버튼만 있는게 아니라 버튼에 달려있는 별도
    // 한번에 배열로 만들기 위해 ButtonStar 스크립트를 만들고 buttons 배열을 생성함
    public Sprite fillStarSprite;
    public Sprite emptyStarSprite;
    private const string StarCountKeyPrefs = "StarCount_";  // 수정할수도 있으니 상수 선언

    /*private void Start()
    {
        AddListener();
    }

    public void AddListener()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] == null)
            {
                return;
            }
            int j = i + 1;
            buttons[i].onClick.AddListener(()=>StartStage(j));
            Debug.Log(buttons[i].name);     // 선배가 알려준대로 버튼 자동 인스펙터 할당 하려다가 실패함
        }   // 굳이 필수는 아니라서 일단 구현 안 하고 냅둠
    }*/

    private void Awake()    // 선택씬에 와서 추가로 초기화(or 변경) 될 필요(or 가능성)은 없기 때문에 Start말고 Awake에 작성
    {   // UnlockedStage 키는 GameManager 에서 SetInt 함
        int unlockedStage = PlayerPrefs.GetInt("UnlockedStage", 1);     // 해금된 스테이지 수를 불러온다 (없다면 1을 반환(처음에 1스테이지는 해금되어 있어야 하니까))
        for (int i = 0; i < buttons.Length; i++)    // 버튼 개수 만큼 반복
        {
            buttons[i].button.interactable = false;    // 일단 버튼을 다 비활성화 시키고
        }
        for (int i = 0; i < unlockedStage; i++)     // 해금된 버튼 까지만 반복
        {
            buttons[i].button.interactable = true;     // 버튼 상호작용 활성화

            int stageIndex = i + 1;     // 스테이지 번호
            // starCount에 StarCountKeyPrefs + stageIndex 키. 즉, StarCount_stageIndex 라는 키 값을 받아옴
            int starCount = PlayerPrefs.GetInt(StarCountKeyPrefs + stageIndex, 0);  // 키가 없으면 0 반환

            for (int k = 0; k < 3; k++)     // 별 3개를 빈 상태로 초기화
            {
                buttons[i].stars[k].sprite = emptyStarSprite;
            }
            for (int k = 0; k < starCount; k++)     // 받은 별 개수만큼 반복
            {
                buttons[i].stars[k].sprite = fillStarSprite;    // 각 버튼에 해당하는 스테이지에서 받은 별의 개수만큼 Fill별로 변경
            }
        }
    }

    public void OnClickBack()
    {
        SoundManager.instance.PlaySound("Click");
        SceneManager.LoadScene("MainScene");
    }

    public void LoadStage(int stageNum)
    {
        SoundManager.instance.PlaySound("Click");
        SoundManager.instance.StopSound("MainBGM");
        string stageName = "Stage " + stageNum;     // 씬 이름 바꾸면 바꿔줘야함
        SceneManager.LoadScene(stageName);
    }
}
