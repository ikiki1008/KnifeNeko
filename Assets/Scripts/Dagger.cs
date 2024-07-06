using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour {
    
    [SerializeField]
    private float moveSpeed = 5f;
    public float damage = 100f;

    void Start()
    {
        // 2초 후 무기를 없앤다
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

}
