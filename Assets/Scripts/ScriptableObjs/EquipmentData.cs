using UnityEngine;

[CreateAssetMenu (fileName = "New Equipment", menuName = "Equipment")]

public class EquipmentData : ScriptableObject, IPlayCollectSound
{
    public enum EqType {
        none,
        MeleeWeapon,
        RangedWeapon,
        Armor
    }

    new public string name = "New Equipment";
    public Sprite icon;
    public EqType equipmentType = EqType.none;
    public GameObject projectile;
    public AudioClip collectSound;

    public void PlayCollectSound()
    {
        FindObjectOfType<AudioManager>().Play(collectSound.name);
    }
}
