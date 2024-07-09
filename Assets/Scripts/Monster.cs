using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private static bool monstersPaused = false;
    [SerializeField]private float moveSpeed = 0.6f;
    [SerializeField]private float respawnLine = -10;
    [SerializeField]private float monsterHp = 100f; //monster HP
    private static List<Monster> allMonsters = new List<Monster>();

    void Start()
    {
        allMonsters.Add(this); // 생성된 모든 몬스터를 리스트에 추가
    }

    void Update()
    {
        if (!monstersPaused){
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;

            if (transform.position.y < respawnLine){
                Debug.Log("Monster respawnLine reached");
                Destroy(gameObject);
                allMonsters.Remove(this); // 리스트에서 제거
            }
        }
    }

    public static void PauseMonsters(){
        monstersPaused = true;
    }

    public static void ResumeMonsters(){
        monstersPaused = false;
        foreach (Monster monster in allMonsters){
            if (monster != null){
                monster.ResumeMovement();
            }
        }
    }

    private void ResumeMovement(){
        StartCoroutine(ResumeAfterDelay());
    }

    private IEnumerator ResumeAfterDelay()
    {
        yield return new WaitForSeconds(1f); // 1초 뒤에 몬스터 이동 재개
        moveSpeed = 0.6f; // 원래의 이동 속도로 설정
    }

    public void setMoveSpeed(float speed){
        moveSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("weapon")){

            Dagger playerWeapon = other.gameObject.GetComponent<Dagger>();
            Ice iceWeapon = other.gameObject.GetComponent<Ice>();
            Fire fireWeapon = other.gameObject.GetComponent<Fire>();
            Thunder thunder = other.gameObject.GetComponent<Thunder>();
            Tree tree = other.gameObject.GetComponent<Tree>();

            float damage = 0f;
            
            if (playerWeapon != null){
                damage = playerWeapon.DaggerDamage(); // 플레이어 무기에서 데미지 가져오기
            }
            else if (fireWeapon != null){
                damage = fireWeapon.Damage(); 
            }
            else if (iceWeapon != null){
                damage = iceWeapon.Damage(); 
            }
            else if (thunder != null){
                damage = thunder.Damage(); 
            }
            else if (tree != null){
                damage = tree.Damage(); 
            }

            monsterHp -= damage;
            if (monsterHp <= 0) {
                Destroy(gameObject);
                ScoreManager.instance.IncreaseScore(100);
                Debug.Log("Monster defeated");
            }

            Destroy(other.gameObject); // 무기는 무조건 사라짐
        }
        else if (other.gameObject.CompareTag("fence"))
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                Debug.Log("Player damaged");
                player.TakeDamage(100f);
                Destroy(gameObject);
            }
        }
    }
}
