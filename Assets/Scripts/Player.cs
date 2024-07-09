using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform shootTransform; // 무기 발사 위치
    [SerializeField]private GameObject weapon; // 무기 프리팹
    [SerializeField]private GameObject fireWeapon; // 무기 프리팹
    [SerializeField]private GameObject iceWeapon; // 무기 프리팹
    [SerializeField]private GameObject treeWeapon; // 무기 프리팹
    [SerializeField]private GameObject thunderWeapon; // 무기 프리팹
    [SerializeField] private float shootInterval = 3.0f; // 무기 발사 간격
    private float lastTimeShoot = 0f;
    public float playerHP = 3000f; //player HP
    private bool canShoot = false; // 무기 발사 가능 여부
    private LifeWatcher lifeWatcher;
    public string monsterTag = "monster"; // 적 태그
    private float[] arrPosX = { -1.98f, -1.11f, 0f, 1.07f, 2.04f };

    void Start()
    {
        StartCoroutine(WaitAndShoot(5.0f)); // 몬스터가 생성되고 내려오기까지 기다림..
        lifeWatcher = FindObjectOfType<LifeWatcher>();
        Debug.Log("start......");
    }

    void Update()
    {
        if (canShoot)
        {
            Shoot();
        }

        CheckGameOver();
    }

    void Shoot()
    {
        if (Time.time - lastTimeShoot > shootInterval)
        {
            GameObject targetMonster = FindClosestMonster();

            if (targetMonster != null)
            {
                Vector3 direction = (targetMonster.transform.position - shootTransform.position).normalized;
                GameObject spawnedWeapon = Instantiate(weapon, shootTransform.position, Quaternion.identity);
                spawnedWeapon.GetComponent<Dagger>().SetDirection(direction); // 방향 설정
            }

            lastTimeShoot = Time.time;
        }
    }

    GameObject FindClosestMonster()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag(monsterTag);
        GameObject closestMonster = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject monster in monsters)
        {
            float distance = Vector3.Distance(transform.position, monster.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestMonster = monster;
            }
        }

        return closestMonster;
    }

    public void TakeDamage(float damage)
    {
        playerHP -= damage;
        Debug.Log("Player HP: " + playerHP);
        lifeWatcher.RemoveLife(playerHP);
    }

    public void Stop(bool stop)
    {
        if (stop)
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
            Update();
        }
    }

    public void RestartShooting(bool restart)
    {
        if (restart)
        {
            canShoot = true;
        }
    }

    public void AddNewWeapon(string newWeapon) {
        if (newWeapon == "fire") {

        } else if (newWeapon == "ice") {

        } else if (newWeapon == "thunder") {
            
        } else {

        }
    }

    private void CheckGameOver()
    {
        if (playerHP <= 0)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }

    private IEnumerator WaitAndShoot(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }
}
