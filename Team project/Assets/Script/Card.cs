using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool isDrag;
    public bool isUsed;
    Rigidbody2D rigidbody2D;

    void Awake()
    {
      isUsed = false;

      rigidbody2D = GetComponent<Rigidbody2D>();
      rigidbody2D.simulated = false;
    }


    void Start()
    {
            
    }

   
    void Update()
    {
        if (isUsed) return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) Drag();
        if (Input.GetMouseButtonUp(0)) Drop();
    }

    void Drag()
    {
        isDrag = true;
        rigidbody2D.simulated = false;
    }

    void Drop()
    {
        isDrag = false;
        isUsed = true;
        rigidbody2D.simulated = true;
    }

    public void Used()
    {
        isDrag = false;                             
        isUsed = true;                         
        rigidbody2D.simulated = true;               
    }
}
