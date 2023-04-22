using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageUI : MonoBehaviour
{
    [SerializeField] private TMP_Text countText;
    void Start()
    {
        StepsSpawner.PrintFloor += UpdateFloor;
    }

    void Update()
    {
        
    }

    void UpdateFloor(){
        countText.text = StepsSpawner.CurrentFloor.ToString();
    }
}
