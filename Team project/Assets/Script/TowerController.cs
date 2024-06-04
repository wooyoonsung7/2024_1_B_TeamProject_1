using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private float AttackTimer;
    public GameObject bulletPrefab;
    public int index = 0;
    public float AttackInterval = 3f;  // 포탑의 공격시간간격
    //오버랩사용
    public Transform n_tr;             //포탑의 위치
    public float halfSize = 1.0f;      //포탑의 공격범위
    public LayerMask n_LayerMask = -1; //포탑의 공격범위내의 공격대상지정
    //총알의 변수설정
    public float bulletSpeed = 1;          //총알이동속도
    //public int attackValue = 1;            //총알공격력

    void Start()
    {
        AttackTimer = 0;
    }

    private void FixedUpdate()
    {
        SearchEnemy();
    }

    void Update()
    {
        AttackTimer += Time.deltaTime;
    }

    void SearchEnemy()
    {
        Collider[] _target = Physics.OverlapSphere(n_tr.position, halfSize, n_LayerMask);

        for(int i = 0; i < _target.Length; i++)
        {
            Transform _targetTf = _target[i].transform;
            if (_targetTf.tag == "Enemy")
            {
                if (AttackTimer >= AttackInterval)
                {
                    bulletPrefab.GetComponent<Bullet>().speed = bulletSpeed;
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                    //bullet.GetComponent<Bullet>().attackValue = attackValue;
                    bullet.transform.LookAt(_targetTf);
                    AttackTimer = 0;
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
