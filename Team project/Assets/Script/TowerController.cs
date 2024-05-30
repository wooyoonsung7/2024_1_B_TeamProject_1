using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private Transform target;
    private float AttackTimer;
    public GameObject bulletPrefab;
    public float AttackInterval = 3f;  // ��ž�� ���ݽð�����
    //���������
    public Transform n_tr;             //��ž�� ��ġ
    public float halfSize = 1.0f;      //��ž�� ���ݹ���
    public LayerMask n_LayerMask = -1; //��ž�� ���ݹ������� ���ݴ������
    //�Ѿ��� ��������
    public float bulletSpeed = 1;          //�Ѿ��̵��ӵ�
    public int attackValue = 1;            //�Ѿ˰��ݷ�
    

    void Start()
    {
        AttackTimer = 0;
        target = FindObjectOfType<EnemyMove>().transform;
    }

    void Update()
    {
        AttackTimer += Time.deltaTime;
        if (AttackTimer >= AttackInterval)
        {
            AttackTimer = 0;
            Collider[] cols = Physics.OverlapSphere(n_tr.position, halfSize, n_LayerMask);

            foreach (Collider col in cols)
            {
                if (col.tag == "Enemy")
                {
                    bulletPrefab.GetComponent<Bullet>().speed = bulletSpeed;
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                    bullet.transform.LookAt(target);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        if(target != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(n_tr.position, halfSize);
        }
    }
}
