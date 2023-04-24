using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour, IPlayContactSound
{
    [SerializeField] private Sprite bloodySpike;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<CharacterStatus>().TakeDamage(1);
            GetComponent<SpriteRenderer>().sprite = bloodySpike;

            Step[] allSteps = FindObjectsOfType<Step>();
            if (allSteps.Length != 0){
                foreach (Step s in allSteps){
                    if (s != null && s.tag == "TouchingStep"){
                        s.GetComponent<BoxCollider2D>().enabled = false;
                    }
                }
            }

            PlayContactSound();
        }
    }

    public void PlayContactSound(){
        // TODO: Playsound here
    }
}
