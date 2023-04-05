using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Item")]
public class ItemData : ScriptableObject
{
    new public string name = "New Item";
    public bool isCollectable;

}
