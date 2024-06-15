using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    //public GameObject[] Tutorials;  // SetActive �� �̹��� UI�� �迭�� Inspector���� �޾ƿ�    // ���� ������Ʈ�� �޾ƿ��� �ڵ尡 �־���
    private GameObject tutorialCanvas;

    private void Awake()
    {
        tutorialCanvas = gameObject;        // tutorialCanvas ������ ���� ������Ʈ�� �Ҵ�
        tutorialCanvas.SetActive(true);

        // Ʃ�丮��ĵ������ ���� �ڽĵ��� false�� ����
        for (int i = 0; i < 12; i++)
        {
            tutorialCanvas.transform.GetChild(i).gameObject.SetActive(false);
        }
        // tutorialCanvas.transform.GetChild(0).gameObject.SetActive(false);

        // PlayerPrefs.DeleteKey("TutorialDone");      // �׽�Ʈ��. �׻� Ʃ�丮���� ó������ ���·� ����. �� ���ߵǸ� �����ؾ���
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("TutorialDone", 0) == 0)     // Ʃ�丮���� �ô��� �� �ô���. 
        {
            Debug.Log("Ʃ�丮�� ���� ȣ���");
            // Ʃ�丮���� ���� �ʾҴٸ� �Ʒ� �ڵ� ����
            TutorialStart();
            PlayerPrefs.SetInt("TutorialDone", 1);          // Ʃ�丮���� ����
        }
    }

    public void TutorialStart()     // Ʃ�丮���� �����ֱ� �����ϴ� �Լ�
    {
        tutorialCanvas.transform.GetChild(0).gameObject.SetActive(true);     // Ʃ�丮�� ù ��° �̹��� ����
        Time.timeScale = 0.0f;          // �Ͻ�����
    }


    // ��ư�� ���̴� �Լ�
    public void TutorialNextOnClick(int i)
    {
        SoundManager.instance.PlaySound("Click");
        if (0 <= i && i <= 10)
        {
            tutorialCanvas.transform.GetChild(i).gameObject.SetActive(false);       // ���� �̹����� ����
            tutorialCanvas.transform.GetChild(i + 1).gameObject.SetActive(true);      // ���� �̹����� �Ҵ�
        }
        else
        {
            //Debug.Log("�������� ����");
        }

        if (i == 11)     // ������ �̹��� ��ư�� �� �۵�
        {
            tutorialCanvas.transform.GetChild(11).gameObject.SetActive(false);        // ������ �̹��� ����
            Time.timeScale = 1.0f;
        }
    }

    public void TutorialBeforeOnClick(int i)
    {
        SoundManager.instance.PlaySound("Click");
        if (0 <= i && i <= 11)
        {
            tutorialCanvas.transform.GetChild(i).gameObject.SetActive(false);       // ���� �̹����� ����
            tutorialCanvas.transform.GetChild(i - 1).gameObject.SetActive(true);      // ���� �̹����� �Ҵ�
        }
    }
}
