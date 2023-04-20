using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour, IPlayContactSound
{
    [SerializeField] private Sprite bloodySpike;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<CharacterCombat>().TakeDamage(1);
            GetComponent<SpriteRenderer>().sprite = bloodySpike;

            // TODO: Fix step bug/ old ts not removed bug
            List<GameObject> touchingSteps = FindObjectOfType<Character>().TouchingSteps;
            if (touchingSteps.Count != 0){
                foreach (GameObject ts in touchingSteps){
                    if (ts != null){
                        ts.GetComponent<BoxCollider2D>().enabled = false;
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
