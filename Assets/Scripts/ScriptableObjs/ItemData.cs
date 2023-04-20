using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Item")]

public class ItemData : ScriptableObject, IPlayContactSound
{
    new public string name = "New Item";
    public Sprite icon;
    public bool isCollectable;
    public bool isUsable;
    public Abilities ability = Abilities.none;
    public AudioClip collectSound;
    public virtual void PlayContactSound(){
        FindObjectOfType<AudioManager>().Play(collectSound.name);
    }
}
