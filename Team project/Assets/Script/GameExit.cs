using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void Quit()
    {
        
#if UNITY_EDITOR                   //에디터에서 실행 중일 떄
         UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();              //빌드된 게임에서 실행 중일떄
#endif
    }
}
