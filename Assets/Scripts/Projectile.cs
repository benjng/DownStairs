using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileData projectile;
    private bool startShooting = false;
    private int shootDir;

    void Start(){
        shootDir = CharacterCombat.instance.CurrentFaceDir;
    }

    public void ShootStraight(){
        Debug.Log("Shooting out");
        InitPos();
        startShooting = true;
    }

    void InitPos(){
        transform.position = CharacterCombat.instance.transform.position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }
    
    void FixedUpdate(){
        if (!startShooting){
            return;
        }
        transform.position += new Vector3(projectile.speed * shootDir, StepsSpawner.stepUpSpeed, 0) * Time.fixedDeltaTime;
    }
}