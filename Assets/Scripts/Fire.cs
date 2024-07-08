using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float damage = 300f;
    [SerializeField] public float destroyTime;

    void Start()
    {
        moveSpeed = 5f;
        damage = 300f;
        // 2초 후 무기를 없앤다
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

    public void UpgradeDamage(float newDamage) {
        
        if (damage >= 800) {
            Debug.Log("불 속성 무기 데미지 최대치로 왔음");
        } else {
            damage += newDamage;
            Debug.Log(damage);
        }
    }

    public void DecreaseTime (float time) {

        if (destroyTime == 1) {
            Debug.Log("불 속성 무기 시간 최대치로 왔음");
        } else {
             destroyTime -= time; 
        Debug.Log(destroyTime);
        }
    }
}
