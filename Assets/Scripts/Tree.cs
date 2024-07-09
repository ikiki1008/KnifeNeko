using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 3f;
    [SerializeField] public float damage = 600f;
    [SerializeField] public float destroyTime = 4.0f;
    private List<float> posX = new List<float> { -1.5f, 0.1f, 1.5f };

    void Start()
    {
        Vector3 startPosition = SetTreePosition();
        transform.position = startPosition;
        Destroy(gameObject, destroyTime); // destroyTime 후에 오브젝트를 파괴함
    }

    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime; // 위로 이동
    }

    public float Damage()
    {
        return damage;
    }

    public float Speed()
    {
        return moveSpeed;
    }

    public void UpgradeDamage(float newDamage)
    {
        if (damage >= 1000)
        {
            Debug.Log("나무 속성 무기 데미지 최대치로 왔음");
        }
        else
        {
            damage += newDamage;
            Debug.Log(damage);
        }
    }

    public void DecreaseTime(float time)
    {
        if (destroyTime <= 1)
        {
            Debug.Log("나무 속성 무기 시간 최소치로 왔음");
        }
        else
        {
            destroyTime -= time;
            Debug.Log(destroyTime);
        }
    }

    public Vector3 SetTreePosition()
    {
        float x = posX[Random.Range(0, posX.Count)];
        float y = transform.position.y;
        return new Vector3(x, y, transform.position.z);
    }
}