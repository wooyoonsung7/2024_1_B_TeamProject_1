using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransform : MonoBehaviour
{
    public float MoveSpeed;

    private void Update()
    {
        this.gameObject.transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * Time.deltaTime * MoveSpeed;

        if (gameObject.transform.position.x < -720)       //x축 좌표가 -1540미만으로 내려갈 때
        {
            gameObject.transform.position += new Vector3(2880.0f, 0.0f, 0.0f);        //오른쪽으로 x축 1200만큼 이동
        }
    }
}
