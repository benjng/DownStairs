using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Awake()
    {
        this.enabled = false;
    }

    void OnEnable() {
        Debug.Log("Projectile Enabled");
    }
}