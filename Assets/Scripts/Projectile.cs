using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileData projectile;
    public void Shoot(){
        Debug.Log("Shooting out");
        
    }

    // public void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Player")) 
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}