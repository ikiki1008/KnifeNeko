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

    public void UpgradeDamage(float newDamage)
    {
        if (damage >= 800)
        {
            Debug.Log("얼음 무기 데미지 최대치로 도달");
        }
        else
        {
            damage = Mathf.Min(damage + newDamage, 800);
            Debug.Log("얼음 무기 데미지 업그레이드! 현재 데미지: " + damage);
        }
    }

    public void UpgradeSpeed(float speedIncrement)
    {
        if (moveSpeed >= 10)
        {
            Debug.Log("얼음 무기 스피드 최대치로 도달");
        }
        else
        {
            moveSpeed = Mathf.Min(moveSpeed + speedIncrement, 10);
            Debug.Log("얼름 무기 스피드 업그레이드! 현재 스피드: " + moveSpeed);
        }
    }
}
