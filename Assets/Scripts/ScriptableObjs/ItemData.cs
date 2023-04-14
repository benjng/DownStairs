using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Item")]

public class ItemData : ScriptableObject
{
    public enum Abilities {
        none,
        MultiplyCharRunSpeed_110Per,
        MultiplyStepSpeed_110Per,
        InstantSpawn_1Step
    }

    new public string name = "New Item";
    public Sprite icon;
    public bool isCollectable;
    public bool isUsable;
    public bool isEquippable;
    public Abilities ability = Abilities.none;
    // public virtual void Use(){
    //     Debug.Log("Use this item");
    // }
}
