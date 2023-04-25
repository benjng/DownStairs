using UnityEngine;

public class Step : MonoBehaviour
{
    private float upSpeed;

    public void FixedUpdate()
    {
        upSpeed = StepsSpawner.StepUpSpeed;
        transform.position += new Vector3(0, upSpeed, 0) * Time.fixedDeltaTime;
        // CheckIfSpawnNext();
        CheckIfDestroySelf();
    }

    void CheckIfDestroySelf(){
        if (transform.position.y >= Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y)
        {
            Destroy(gameObject);
        }
    }

    public virtual void GenerateItem(GameObject item)
    {
        GameObject thisItem = Instantiate(item, transform);
        thisItem.transform.localPosition = new Vector3(0, 0.2f, 0);
    }
}