using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float damage = 600f;
    [SerializeField] public float destroyTime = 3f;
    private List<float> posX = new List<float>{-1.5f, 0.1f, 1.5f};

    void Start()
    {
        Vector3 startPostion = GetRandomPosition();
        transform.position = startPostion;
        // destroyTime 후에 오브젝트를 파괴함
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        // move to up..
        transform.position += Vector3.up*moveSpeed*Time.deltaTime;
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
        float x = posX[Random.Range(0, posX.Count)];
        float y = transform.position.y;
        return new Vector3(x, y, transform.position.z);
    }

}
