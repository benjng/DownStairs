using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    private float upSpeed;

    void Start()
    {
        float randWidth = Random.Range(0.0f, 1.0f);
        transform.localPosition = Camera.main.ViewportToWorldPoint(new Vector3(randWidth, 0, 0));
    }

    void FixedUpdate()
    {
        upSpeed = FindFirstObjectByType<StepsSpawner>().upSpeed;
        transform.position += new Vector3(0, upSpeed, 0) * Time.fixedDeltaTime;
        if (transform.position.y >= 8)
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