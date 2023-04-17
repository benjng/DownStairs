using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Item")]

public class ItemData : ScriptableObject, IPlayCollectSound
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
    public Abilities ability = Abilities.none;
    public AudioClip collectSound;
    public virtual void PlayCollectSound(){
        FindObjectOfType<AudioManager>().Play(collectSound.name);
    }
}
