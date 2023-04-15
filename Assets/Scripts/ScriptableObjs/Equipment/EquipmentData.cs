using UnityEngine;

[CreateAssetMenu (fileName = "New Equipment", menuName = "Equipment")]

public class EquipmentData : ScriptableObject
{
    public enum EqType {
        none,
        Weapon,
        Armor
    }

    new public string name = "New Equipment";
    public Sprite icon;
    public EqType equipmentType = EqType.none;
}
