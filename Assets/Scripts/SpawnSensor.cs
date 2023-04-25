using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSensor : Step
{
    public delegate void SpawnStepEventHandler();
    public static event SpawnStepEventHandler SpawnStepEvent;

    public new void FixedUpdate(){
        base.FixedUpdate();
        CheckIfSpawnNext();
    }
    
    void CheckIfSpawnNext(){
        if (Camera.main.WorldToViewportPoint(transform.position).y > StepsSpawner.VPSpawnPosY){
            SpawnStepEvent?.Invoke(); // Invoke step spawn if a typical step reaches spawn y position
            Destroy(gameObject);
        } 
    }

    public override void GenerateItem(GameObject item){}
}
