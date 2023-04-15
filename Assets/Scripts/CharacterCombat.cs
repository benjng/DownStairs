using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] Button atkBtn;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
