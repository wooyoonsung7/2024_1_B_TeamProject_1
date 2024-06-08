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
    public float AttackInterval = 3f;  // 포탑의 공격시간간격
    //오버랩사용
    public float halfSize = 1.0f;      //포탑의 공격범위
    public LayerMask n_LayerMask = -1; //포탑의 공격범위내의 공격대상지정
    //총알의 변수설정
    public float bulletSpeed = 1;          //총알이동속도
    public int attackValue = 1;            //총알공격력

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

            Vector3 Direction = (transform.position - _targetTf.position).normalized;
            if (Direction.y < 180 && Direction.y > 0)
                transform.DORotate(new Vector3(0, 180, 0), 1f);        

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

