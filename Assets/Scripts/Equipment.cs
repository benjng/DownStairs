using UnityEngine;

public class Equipment : MonoBehaviour, ICollectable
{
    public EquipmentData equipment;
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Equip/Replace equipment to the equipment layout
            Destroy(gameObject);
        }
    }
}
