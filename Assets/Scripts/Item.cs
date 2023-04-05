using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && item.isCollectable)
        {
            if (item.isCollectable)
                Destroy(gameObject);
            // React to the item/ Add ability to player
        }
    }
}
