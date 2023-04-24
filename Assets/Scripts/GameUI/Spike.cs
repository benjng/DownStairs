using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour, IPlayContactSound
{
    [SerializeField] private Sprite bloodySpike;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<CharacterStatus>().TakeDamage(1);
            GetComponent<SpriteRenderer>().sprite = bloodySpike;
            DisableStepCollider();
            PlayContactSound();
        }
    }

    void DisableStepCollider(){
        Step[] allSteps = FindObjectsOfType<Step>();
        if (allSteps.Length != 0){
            foreach (Step s in allSteps){
                if (s.tag == "TouchingStep"){
                    s.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }

    public void PlayContactSound(){
        if (Random.value > 0.4){
            FindObjectOfType<AudioManager>().Play("HitSpike1");
        } else {
            FindObjectOfType<AudioManager>().Play("HitSpike2");
        }
    }
}
