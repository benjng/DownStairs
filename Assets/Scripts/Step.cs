using UnityEngine;

public class Step : MonoBehaviour
{
    private float upSpeed;

    void FixedUpdate()
    {
        upSpeed = StepsSpawner.stepUpSpeed;
        transform.position += new Vector3(0, upSpeed, 0) * Time.fixedDeltaTime;
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