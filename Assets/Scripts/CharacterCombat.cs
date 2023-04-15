using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    #region Singleton
    public static CharacterCombat instance;
    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Duplicated CharacterCombat instance found.");
            return;
        }
        instance = this;
    }
    #endregion
    
    [SerializeField] EquipmentData currentEquipment;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
