using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void Quit()
    {
        
#if UNITY_EDITOR                   //�����Ϳ��� ���� ���� ��
         UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();              //����� ���ӿ��� ���� ���ϋ�
#endif
    }
}
