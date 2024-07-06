using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform shootTransform; // 무기 발사 위치
    [SerializeField]
    private GameObject weapon; // 무기 프리팹
    [SerializeField]
    private float shootInterval = 1.0f; // 무기 발사 간격
    private float lastTimeShoot = 0f;

    void Start()
    {
    }

    void Update()
    {
        Debug.Log("update");
        Shoot();
    }

    void Shoot(){
        Debug.Log("Shoot");
        if (Time.time - lastTimeShoot > shootInterval) {
            Debug.Log("shoot 2");
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastTimeShoot = Time.time;
        }
    }
}
