using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private Transform[] target = new Transform[6];
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
        GameManager gameManager = GameManager.Instance;
        AttackTimer = 0;

        for (int i = 0; i < 6; i++)
        {
            target[i] = gameManager.monster[i];
        }
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
                    for (int i = 0; i < 6; i++)
                    {
                        bullet.transform.LookAt(target[i]);
                    }
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(n_tr.position, halfSize);
    }
}
