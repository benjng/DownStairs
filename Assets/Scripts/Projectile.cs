using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileData projectile;
    private bool startShooting = false;
    public void ShootStraight(){
        Debug.Log("Shooting out");
        InitPos();
        startShooting = true;
    }

    void InitPos(){
        transform.position = CharacterCombat.instance.transform.position;
    }

    void FixedUpdate(){
        if (!startShooting){
            return;
        }
        transform.position += new Vector3(projectile.speed, StepsSpawner.stepUpSpeed, 0) * Time.fixedDeltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }
}