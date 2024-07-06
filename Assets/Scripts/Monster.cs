using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.3f;
    // [SerializeField]
    // private float minimumLine = -3.5f;
    [SerializeField]
    private float respawnLine = -10;
    [SerializeField]
    private float monsterHp = 100f; //monster HP

    void Start()
    {
    }

    void Update(){
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < respawnLine){
            Debug.Log("wtf is this....");
            Destroy(gameObject);
        }
    }

    public void setMoveSpeed(float speed) 
    {
        speed = moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //몬스터가 어떤 물체와 충돌됐을때 
        if (other.gameObject.tag == "weapon") {
            Dagger dagger = other.gameObject.GetComponent<Dagger>(); //무기 객체 가져오기
            Level level = FindObjectOfType<Level>(); // Level 컴포넌트 가져오기

            monsterHp -= dagger.damage;

            if (monsterHp <= 0) {
                Destroy(gameObject);
                if (level != null) {
                    level.AddScore(100); //몬스터 처치 시 100씩 증가
                    Debug.Log("monster got destroyed");
                }
            }
            Destroy(other.gameObject); //적과 무기가 닿을때 무기는 무조건 사라진다
        } 
        else if (other.gameObject.tag == "fence") {
            Player player = FindObjectOfType<Player>();
            if (player != null) {
                Debug.Log("player got damaged");  
                player.TakeDamage(100f);
                Destroy(gameObject);
            }
        }
    }
}
