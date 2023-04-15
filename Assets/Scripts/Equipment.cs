using UnityEngine;

public class Equipment : MonoBehaviour, ICollectable
{
    [SerializeField] private EquipmentData equipment;
    private CharacterCombat characterCombat;

    void Start(){
        characterCombat = CharacterCombat.instance;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Equip/Replace equipment to the equipment layout
            characterCombat.UpdateEquipment(equipment);
            Destroy(gameObject);
        }
    }
}
