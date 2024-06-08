using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private float AttackTimer;
    public GameObject bulletPrefab;
    public int coinValue = 0;
    public float AttackInterval = 3f;  // ��ž�� ���ݽð�����
    //���������
    public float halfSize = 1.0f;      //��ž�� ���ݹ���
    public LayerMask n_LayerMask = -1; //��ž�� ���ݹ������� ���ݴ������
    //�Ѿ��� ��������
    public float bulletSpeed = 1;          //�Ѿ��̵��ӵ�
    public int attackValue = 1;            //�Ѿ˰��ݷ�

    void Start()
    {
        AttackTimer = 0;
    }

    private void FixedUpdate()
    {
        SearchEnemy();
    }

    void SearchEnemy()
    {
        AttackTimer += Time.deltaTime;

        Collider[] _target = Physics.OverlapSphere(gameObject.transform.position, halfSize, n_LayerMask);

        for (int i = 0; i < _target.Length; i++)
        {
            Transform _targetTf = _target[i].transform;
            if (_targetTf.tag == "Enemy")
            {
                if (AttackTimer >= AttackInterval)
                {
                    GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
                    bullet.GetComponent<Bullet>().speed = bulletSpeed;
                    bullet.GetComponent<Bullet>().attackValue = attackValue;
                    bullet.transform.LookAt(_targetTf);
                    AttackTimer = 0;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(gameObject.transform.position, halfSize);
    }
}
