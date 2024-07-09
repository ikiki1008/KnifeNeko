using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    public float damage = 100f;
    [SerializeField] public float destroyTime = 3.0f;
    private Vector3 direction;

    void Start()
    {
        // 일정 시간 후 무기를 없앤다
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

    public float DaggerDamage()
    {
        return damage;
    }

    public float DaggerSpeed()
    {
        return moveSpeed;
    }
}
