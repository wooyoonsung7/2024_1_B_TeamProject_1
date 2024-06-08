using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("���Ͱ� ������");
            Health health = other.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage();
            }
        }
    }
}
