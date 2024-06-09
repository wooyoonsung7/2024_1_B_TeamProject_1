using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public static Bullet _instance;
    public float speed = 1;
    Rigidbody rb;
    public int attackValue;


    private void Awake()
    {
        if(_instance!= null)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 3f);

    }

    public void Bulletcheking()
    {
        Destroy(gameObject);
    }


}
