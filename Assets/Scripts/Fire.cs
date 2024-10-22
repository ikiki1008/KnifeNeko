using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float damage = 100f;
    [SerializeField] public float destroyTime = 1.0f;
    private Vector3 direction;

    void Start()
    {
        // 2초 후 무기를 없앤다
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    } 
    
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    public float Damage()
    {
        return damage;
    }

    public float Speed(){
        return moveSpeed;
    }


    public void UpgradeDamage(float newDamage) {
        
        if (damage >= 800) {
            Debug.Log("불 속성 무기 데미지 최대치로 왔음");
        } else {
            damage += newDamage;
            Debug.Log(damage);
        }
    }

    public void UpgradeSpeed (float speed) {

        if (moveSpeed == 10) {
            Debug.Log("불 무기 스피드 최대치로 왔음");
        } else {
            moveSpeed += speed; 
            Debug.Log(moveSpeed);
        }
    }
}
