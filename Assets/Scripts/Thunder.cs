using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 3f;
    [SerializeField] public float damage = 600f;
    [SerializeField] public float destroyTime = 1.0f;
    private Vector3 direction;

    void Start()
    {
        // destroyTime 후에 오브젝트를 파괴함
        Destroy(gameObject, destroyTime);
    }

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

    public float Speed()
    {
        return moveSpeed;
    }


    public void UpgradeDamage(float newDamage) {
        
        if (damage >= 1000) {
            Debug.Log("번개 속성 무기 데미지 최대치로 왔음");
        } else {
            damage += newDamage;
            Debug.Log(damage);
        }
    }

    public void DecreaseTime (float time) {

        if (destroyTime == 1) {
            Debug.Log("번개 속성 무기 시간 최대치로 왔음");
        } else {
             destroyTime -= time; 
        Debug.Log(destroyTime);
        }
    }   

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-1.17f, 3f);
        float y = Random.Range(-2f, 4f);

        return new Vector3(x, y, transform.position.z);
    }

}
