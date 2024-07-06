using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.3f;
    [SerializeField]
    private float minimumLine = -2.5f;
    [SerializeField]
    private float respawnLine = -10;

    void Start()
    {
    }

    void Update(){
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < minimumLine){
            Destroy(gameObject);
        }

        if (transform.position.y < respawnLine){
            Destroy(gameObject);
        }
    }

    public void setMoveSpeed(float speed) 
    {
        speed = moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("weapon")){
            Destroy(gameObject);
        }
    }
}
