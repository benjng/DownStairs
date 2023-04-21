using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStatus : MonoBehaviour
{
    [SerializeField] private int currentHeatlh;
    [SerializeField] private int maxHeatlh = 10;
    [SerializeField] private HealthBar healthBar;

    [SerializeField] private float currentGravity = 1.1f;
    [SerializeField] private float maxGravity = 3f;
    [SerializeField] private GravityBar gravityBar;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        InitHP();
        InitGravity();
    }

    void FixedUpdate(){
        if (!GameStarter.gameStarted) return;
        UpdateGravity(currentGravity);
    }

    void UpdateGravity(float gravity){
        rb.gravityScale = gravity;
    }

    void InitHP(){
        currentHeatlh = maxHeatlh;
        healthBar.SetMaxValue(maxHeatlh); // Init healthbar appearance to max hp
    }

    void InitGravity(){
        gravityBar.SetMaxValue(maxGravity); // Init max gravity appearance
        gravityBar.SetValue(currentGravity); // 
    }

    public void TakeDamage(int damage){
        currentHeatlh -= damage;
        healthBar.SetValue(currentHeatlh);
        if (currentHeatlh <= 0)
            SceneManager.LoadScene(3);
    }
    public void TakeHeal(int heal){
        if (currentHeatlh == maxHeatlh) return;
        currentHeatlh += heal;
        healthBar.SetValue(currentHeatlh);
    }

    public void MultiplyGravity(float multiplier){
        currentGravity *= multiplier;
        gravityBar.SetValue(currentGravity);
    }
}
