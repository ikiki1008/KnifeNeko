using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.3f;
    [SerializeField]
    private float minimumLine = -2.5f;
    [SerializeField]
    private float respawnLine = -10;
    private float monsterHp = 100f; //monster HP

    void Start()
    {
    }

    void Update(){
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < minimumLine){
            Destroy(gameObject);
        }

        if (transform.position.y < respawnLine){
            Destroy(gameObject);
        }
    }

    public void setMoveSpeed(float speed) 
    {
        speed = moveSpeed;
    }

    // void OnTriggerEnter2D(Collider2D other){
    //     if (other.CompareTag("weapon")){
    //         Destroy(gameObject);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other) {
        //몬스터가 어떤 물체와 충돌됐을때 
        if (other.gameObject.tag == "weapon") {
            Dagger dagger = other.gameObject.GetComponent<Dagger>(); //무기 객체 가져오기
            monsterHp -= dagger.damage;

            if (monsterHp <= 0) {
                Destroy(gameObject);
            }

            Destroy(other.gameObject); //적과 무기가 닿을때 무기는 무조건 사라진다
        }
    }
}
