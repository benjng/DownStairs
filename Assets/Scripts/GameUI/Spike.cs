using UnityEngine;

public class Spike : MonoBehaviour, IPlayContactSound
{
    [SerializeField] private Sprite bloodySpike;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Character>().TouchingStep.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = bloodySpike;
            PlayContactSound();
        }
    }

    public void PlayContactSound(){
        // TODO: Playsound here
    }
}
