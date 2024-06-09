using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
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

    float movetimer;

    void Start()
    {
        AttackTimer = 0;
    }

    private void FixedUpdate()
    {
        SearchEnemy();
        movetimer += Time.deltaTime;
    }

    void SearchEnemy()
    {
        AttackTimer += Time.deltaTime;

        Collider[] _target = Physics.OverlapSphere(gameObject.transform.position, halfSize, n_LayerMask);

        for (int i = 0; i < _target.Length; i++)
        {
            Transform _targetTf = _target[i].transform;

            LookEnemy(_targetTf);

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

    private void LookEnemy(Transform targetTf)
    {
        int a = 5;
        if (movetimer >= GameManager.Instance.stageWaveData.SpawnTimer + 1f)
        {
            if (transform.position.z <= targetTf.position.z && transform.position.x <= targetTf.position.x + 0.3f && transform.position.x >= targetTf.position.x - 0.3f)
                a = 0;
            if (transform.position.z > targetTf.position.z && transform.position.x <= targetTf.position.x + 0.3f && transform.position.x >= targetTf.position.x - 0.3f)
                a = 1;
            if (transform.position.x <= targetTf.position.x && transform.position.z <= targetTf.position.z + 0.3f && transform.position.z >= targetTf.position.z - 0.3f)
                a = 2;
            if (transform.position.x > targetTf.position.x && transform.position.z <= targetTf.position.z + 0.3f && transform.position.z >= targetTf.position.z - 0.3f)
                a = 3;
        }

        switch (a)
        {
            case 0:
                transform.DORotate(new Vector3(0, 0, 0), 1f); movetimer = 0;
                break;
            case 1:
                transform.DORotate(new Vector3(0, 180, 0), 1f); movetimer = 0;
                break;
            case 2:
                transform.DORotate(new Vector3(0, 90, 0), 1f); movetimer = 0;
                Debug.Log("된다");
                break;
            case 3:
                transform.DORotate(new Vector3(0, 270, 0), 1f); movetimer = 0;
                break;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(gameObject.transform.position, halfSize);
    }

}

