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
    public ButtonStar[] buttons;    // ������ ��ư �迭�̾��µ� ��ư�� �ִ°� �ƴ϶� ��ư�� �޷��ִ� ����
    // �ѹ��� �迭�� ����� ���� ButtonStar ��ũ��Ʈ�� ����� buttons �迭�� ������
    public Sprite fillStarSprite;
    public Sprite emptyStarSprite;
    private const string StarCountKeyPrefs = "StarCount_";  // �����Ҽ��� ������ ��� ����

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
            Debug.Log(buttons[i].name);     // ���谡 �˷��ش�� ��ư �ڵ� �ν����� �Ҵ� �Ϸ��ٰ� ������
        }   // ���� �ʼ��� �ƴ϶� �ϴ� ���� �� �ϰ� ����
    }*/

    private void Awake()    // ���þ��� �ͼ� �߰��� �ʱ�ȭ(or ����) �� �ʿ�(or ���ɼ�)�� ���� ������ Start���� Awake�� �ۼ�
    {   // UnlockedStage Ű�� GameManager ���� SetInt ��
        int unlockedStage = PlayerPrefs.GetInt("UnlockedStage", 1);     // �رݵ� �������� ���� �ҷ��´� (���ٸ� 1�� ��ȯ(ó���� 1���������� �رݵǾ� �־�� �ϴϱ�))
        for (int i = 0; i < buttons.Length; i++)    // ��ư ���� ��ŭ �ݺ�
        {
            buttons[i].button.interactable = false;    // �ϴ� ��ư�� �� ��Ȱ��ȭ ��Ű��
        }
        for (int i = 0; i < unlockedStage; i++)     // �رݵ� ��ư ������ �ݺ�
        {
            buttons[i].button.interactable = true;     // ��ư ��ȣ�ۿ� Ȱ��ȭ

            int stageIndex = i + 1;     // �������� ��ȣ
            // starCount�� StarCountKeyPrefs + stageIndex Ű. ��, StarCount_stageIndex ��� Ű ���� �޾ƿ�
            int starCount = PlayerPrefs.GetInt(StarCountKeyPrefs + stageIndex, 0);  // Ű�� ������ 0 ��ȯ

            for (int k = 0; k < 3; k++)     // �� 3���� �� ���·� �ʱ�ȭ
            {
                buttons[i].stars[k].sprite = emptyStarSprite;
            }
            for (int k = 0; k < starCount; k++)     // ���� �� ������ŭ �ݺ�
            {
                buttons[i].stars[k].sprite = fillStarSprite;    // �� ��ư�� �ش��ϴ� ������������ ���� ���� ������ŭ Fill���� ����
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
        string stageName = "Stage " + stageNum;     // �� �̸� �ٲٸ� �ٲ������
        SceneManager.LoadScene(stageName);
    }
}
