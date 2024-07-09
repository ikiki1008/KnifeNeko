using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
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

    void Update()
    {
        Debug.Log("얼음 날라가신다.....");
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
        
        if (damage >= 800) {
            Debug.Log("얼음 속성 무기 데미지 최대치로 왔음");
        } else {
            damage += newDamage;
            Debug.Log(damage);
        }
    }

    public void DecreaseTime (float time) {

        if (destroyTime == 1) {
            Debug.Log("속성 무기 시간 최대치로 왔음");
        } else {
             destroyTime -= time; 
        Debug.Log(destroyTime);
        }
    }
}
