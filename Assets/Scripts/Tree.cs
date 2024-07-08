using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float damage = 600f;
    [SerializeField] public float destroyTime = 3f;

    void Start()
    {
        // destroyTime 후에 오브젝트를 파괴함
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        // 특정 범위 내에서 랜덤한 위치에 나타나게 함
        Vector3 randomPosition = GetRandomPosition();
        transform.position = randomPosition;
    }


    public void UpgradeDamage(float newDamage) {
        
        if (damage >= 1000) {
            Debug.Log("나무 속성 무기 데미지 최대치로 왔음");
        } else {
            damage += newDamage;
            Debug.Log(damage);
        }
    }

    public void DecreaseTime (float time) {

        if (destroyTime == 1) {
            Debug.Log("나무 속성 무기 시간 최대치로 왔음");
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
