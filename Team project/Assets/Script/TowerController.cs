using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private Transform target;
    private float AttackTimer;
    public GameObject bulletPrefab;
    public float AttackInterval = 3f;  // 포탑의 공격시간간격
    //오버랩사용
    public Transform n_tr;             //포탑의 위치
    public float halfSize = 1.0f;      //포탑의 공격범위
    public LayerMask n_LayerMask = -1; //포탑의 공격범위내의 공격대상지정
    //총알의 변수설정
    public float bulletSpeed = 1;          //총알이동속도
    public int attackValue = 1;            //총알공격력
    

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
