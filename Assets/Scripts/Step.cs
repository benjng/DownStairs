using UnityEngine;

public class Step : MonoBehaviour
{
    private float upSpeed;
    public delegate void SpawnStepEventHandler();
    public static event SpawnStepEventHandler SpawnStepEvent;
    private bool invokedSpawn = false;

    void FixedUpdate()
    {
        upSpeed = StepsSpawner.stepUpSpeed;
        transform.position += new Vector3(0, upSpeed, 0) * Time.fixedDeltaTime;
        if (tag == "Step" && !invokedSpawn && Camera.main.WorldToViewportPoint(transform.position).y > StepsSpawner.VPSpawnPosY){
            // Debug.Log(transform.position.y);
            SpawnStepEvent?.Invoke(); // Invoke step spawn if a typical step reaches spawn y position
            invokedSpawn = true;
        }
        if (transform.position.y >= Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y)
        {
            Destroy(gameObject);
        }
    }

    public void GenerateItem(GameObject item)
    {
        GameObject thisItem = Instantiate(item, transform);
        thisItem.transform.localPosition = new Vector3(0, 0.2f, 0);
    }
}