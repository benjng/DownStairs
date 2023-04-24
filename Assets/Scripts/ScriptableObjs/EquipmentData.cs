using UnityEngine;

[CreateAssetMenu (fileName = "New Equipment", menuName = "Equipment")]

public class EquipmentData : ScriptableObject, IPlayContactSound
{
    new public string name = "New Equipment";
    public Sprite icon;
    public EqType equipmentType = EqType.none;
    public GameObject projectile;
    public AudioClip collectSound;

    public void PlayContactSound()
    {
        AudioManager.instance.Play(collectSound.name);
    }
}
