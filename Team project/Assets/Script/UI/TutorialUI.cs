using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    //public GameObject[] Tutorials;  // SetActive 할 이미지 UI를 배열로 Inspector에서 받아옴    // 하위 오브젝트를 받아오는 코드가 있었음
    private GameObject tutorialCanvas;
    /*private GameObject GameGoal;
    private GameObject ClearOverCriteria;
    private GameObject KeyDescription;
    private GameObject UIDescription;
    private GameObject PlayRules;
    private GameObject CardStat;*/

    private void Awake()
    {
        tutorialCanvas = gameObject;        // tutorialCanvas 변수에 현재 오브젝트를 할당
        tutorialCanvas.SetActive(true);

        // 튜토리얼캔버스의 하위 자식들을 false로 만듦
        for (int i = 0; i < 12; i++)
        {
            tutorialCanvas.transform.GetChild(i).gameObject.SetActive(false);
        }
        // tutorialCanvas.transform.GetChild(0).gameObject.SetActive(false);

        PlayerPrefs.DeleteKey("TutorialDone");      // 테스트용. 항상 튜토리얼을 처음보는 상태로 만듦. 다 개발되면 삭제해야함

        /*// 튜토리얼캔버스의 하위 자식들을 받아옴
        GameGoal = tutorialCanvas.transform.GetChild(0).gameObject;
        ClearOverCriteria = tutorialCanvas.transform.GetChild(1).gameObject;
        KeyDescription = tutorialCanvas.transform.GetChild(2).gameObject;
        UIDescription = tutorialCanvas.transform.GetChild(3).gameObject;
        PlayRules = tutorialCanvas.transform.GetChild(4).gameObject;
        CardStat = tutorialCanvas.transform.GetChild(5).gameObject;
        
        // 첫 번째 튜토리얼 이미지를 제외하고는 false로 초기 설정
        GameGoal.SetActive(true);
        ClearOverCriteria.SetActive(false);
        KeyDescription.SetActive(false);
        UIDescription.SetActive(false);
        PlayRules.SetActive(false);
        CardStat.SetActive(false);*/
    }

    // Start is called before the first frame update
    /*void Start()
    {
        if (PlayerPrefs.GetInt("TutorialDone", 0) == 0)     // 튜토리얼을 봤는지 안 봤는지. 
        {
            // 튜토리얼을 보지 않았다면 아래 코드 실행
            TutorialStart();
            PlayerPrefs.SetInt("TutorialDone", 1);          // 투토리얼을 봤음
        }
    }*/

    private void Update()
    {
        if (PlayerPrefs.GetInt("TutorialDone", 0) == 0)     // 튜토리얼을 봤는지 안 봤는지. 
        {
            Debug.Log("튜토리얼 시작 호출됨");
            // 튜토리얼을 보지 않았다면 아래 코드 실행
            TutorialStart();
            PlayerPrefs.SetInt("TutorialDone", 1);          // 튜토리얼을 봤음
        }
    }

    public void TutorialStart()     // 튜토리얼을 보여주기 시작하는 함수
    {
        tutorialCanvas.transform.GetChild(0).gameObject.SetActive(true);     // 튜토리얼 첫 번째 이미지 켜짐
        Time.timeScale = 0.0f;          // 일시정지
    }


    // 버튼에 붙이는 함수
    public void TutorialNextOnClick(int i)
    {
        if (0 <= i && i <= 10)
        {
            tutorialCanvas.transform.GetChild(i).gameObject.SetActive(false);       // 현재 이미지를 끄고
            tutorialCanvas.transform.GetChild(i + 1).gameObject.SetActive(true);      // 다음 이미지를 켠다
        }
        else
        {
            //Debug.Log("존재하지 않음");
        }

        if (i == 11)     // 마지막 이미지 버튼일 때 작동
        {
            tutorialCanvas.transform.GetChild(11).gameObject.SetActive(false);        // 마지막 이미지 끄기
            Time.timeScale = 1.0f;
        }
    }
}
