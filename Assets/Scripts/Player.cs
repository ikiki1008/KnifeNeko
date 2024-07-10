using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform shootTransform; // 무기 발사 위치
    [SerializeField] private GameObject weapon; // 무기 프리팹
    [SerializeField] private GameObject fireWeapon; 
    [SerializeField] private GameObject iceWeapon; 
    [SerializeField] private GameObject treeWeapon;
    [SerializeField] private GameObject thunderWeapon; 
    [SerializeField] private float shootInterval = 2.0f; // 무기 발사 간격
    [SerializeField] private float fireInterval = 2.0f; 
    [SerializeField] private float iceInterval = 2.0f; 
    [SerializeField] private float thunderInterval = 5.0f;
    [SerializeField] private float treeInterval = 5.0f;
    [SerializeField] private AudioSource backgroundMusic; // 배경 음악 AudioSource
    private float lastTimeShoot = 0f;
    private float lastTimeFireShoot = 0f;
    private float lastTimeIceShoot = 0f;
    private float lastTimeThunderShoot = 0f;
    private float lastTimeTreeShoot = 0f;
    public float playerHP = 3000f; //player HP
    private bool canShoot = false; // 무기 발사 가능 여부
    private LifeWatcher lifeWatcher;
    public string monsterTag = "monster"; // 적 태그
    private float[] arrPosX = { -1.98f, -1.11f, 0f, 1.07f, 2.04f };
    private bool hasFireWeapon = false;
    private bool hasIceWeapon = false;
    private bool hasThunderWeapon = false;
    private bool hasTreeWeapon = false;

    void Start()
    {
        if (backgroundMusic != null && PlayerPrefs.GetInt("MusicMuted", 0) == 0){
            backgroundMusic.Play();
        }

        StartCoroutine(WaitAndShoot(3.0f)); // 몬스터가 생성되고 내려오기까지 기다림..
        lifeWatcher = FindObjectOfType<LifeWatcher>();
        Debug.Log("start......");
    }

    void Update()
    {
        if (canShoot)
        {
            Shoot();
            if (hasFireWeapon) ShootFire(); //무기가 추가되면 쏘기
            if (hasIceWeapon) ShootIce();
            if (hasThunderWeapon) ShootThunder();
            if (hasTreeWeapon) ShootTree();
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

    void ShootFire(){
        if (Time.time - lastTimeFireShoot > fireInterval){
            GameObject targetMonster = FindClosestMonster();

            if (targetMonster != null){
                Vector3 direction = (targetMonster.transform.position - shootTransform.position).normalized;
                GameObject spawnedWeapon = Instantiate(fireWeapon, shootTransform.position, Quaternion.identity);
                spawnedWeapon.GetComponent<Fire>().SetDirection(direction); // 방향 설정
            }

            lastTimeFireShoot = Time.time;
        }
    }

    void ShootIce(){
        if (Time.time - lastTimeIceShoot > iceInterval){
            GameObject targetMonster = FindClosestMonster();

            if (targetMonster != null){
                Vector3 direction = (targetMonster.transform.position - shootTransform.position).normalized;
                GameObject spawnedWeapon = Instantiate(iceWeapon, shootTransform.position, Quaternion.identity);
                spawnedWeapon.GetComponent<Ice>().SetDirection(direction); // 방향 설정
            }

            lastTimeIceShoot = Time.time;
        }
    }

    void ShootThunder() {
        if (Time.time - lastTimeThunderShoot > thunderInterval){
            GameObject targetMonster = FindClosestMonster();

            if (targetMonster != null){
                Vector3 direction = (targetMonster.transform.position - shootTransform.position).normalized;
                GameObject spawnedWeapon = Instantiate(thunderWeapon, shootTransform.position, Quaternion.identity);
                spawnedWeapon.GetComponent<Thunder>().SetDirection(direction); // 방향 설정
            }

            lastTimeThunderShoot = Time.time;
        }
    }

    void ShootTree(){
        if (Time.time - lastTimeTreeShoot > treeInterval){
            GameObject targetMonster = FindClosestMonster();

            if (targetMonster != null){
                Vector3 direction = (targetMonster.transform.position - shootTransform.position).normalized;
                GameObject spawnedWeapon = Instantiate(treeWeapon, shootTransform.position, Quaternion.identity);
                Tree treeScript = spawnedWeapon.GetComponent<Tree>();
                Vector3 randomPosition = treeScript.SetTreePosition(); // 무작위 위치 설정
                spawnedWeapon.transform.position = randomPosition; // 무기 위치 설정
            }

            lastTimeTreeShoot = Time.time;
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

    public void AddNewWeapon(string newWeapon) {
        switch (newWeapon) {
            case "fire":
                hasFireWeapon = true;
                break;
            case "ice":
                hasIceWeapon = true;
                break;
            case "thunder":
                hasThunderWeapon = true;
                break;
            case "tree":
                hasTreeWeapon = true;
                break;
            default:
                break;
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
