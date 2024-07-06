using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform shootTransform; // 무기 발사 위치
    [SerializeField]
    private GameObject weapon; // 무기 프리팹
    [SerializeField]
    private float shootInterval = 0.5f; // 무기 발사 간격
    private float lastTimeShoot = 0f;
    public float playerHP = 3000f; //player HP
    private bool canShoot = false; // 무기 발사 가능 여부
    private LifeWatcher lifeWatcher;

    void Start(){
        StartCoroutine(WaitAndShoot(5.0f)); // 몬스터가 생성되고 내려오기까지 기다림..
        lifeWatcher = FindObjectOfType<LifeWatcher>();
    }

    void Update(){
        if (canShoot){
            Shoot();
        }
        CheckGameOver();
    }

    void Shoot(){
        if (Time.time - lastTimeShoot > shootInterval){
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastTimeShoot = Time.time;
        }
    }
    public void TakeDamage(float damage){
        playerHP -= damage;
        Debug.Log("Player HP: " + playerHP);
        lifeWatcher.RemoveLife(playerHP);
    }

    private void CheckGameOver()
    {
        if (playerHP <= 0){
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }

    private IEnumerator WaitAndShoot(float waitTime){
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }
}
