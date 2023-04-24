using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Item")]

public class ItemData : ScriptableObject, IPlayContactSound
{
    new public string name = "New Item";
    public Sprite icon;
    public bool isCollectable;
    public bool isAutoConsume;
    public bool isUsable;
    public Abilities ability = Abilities.none;
    public AudioClip collectSound;
    public AudioClip useSound;
    public virtual void PlayContactSound(){
        AudioManager.instance.Play(collectSound.name);
    }
    public void PlayUseSound(){
        if (useSound == null) return;
        AudioManager.instance.Play(useSound.name);
    }
}
