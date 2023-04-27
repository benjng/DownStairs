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

    [SerializeField] private float currentMoveSpeed = 6f; // Include init speed
    [SerializeField] private float minMoveSpeed = 1f;
    [SerializeField] private float maxMoveSpeed = 20f;
    [SerializeField] private SpeedBar speedBar;
    [SerializeField] private float speedDecayInterval = 1.0f;
    [SerializeField] private float speedDecayAmount = 0.1f;


    public float MoveSpeed { get => currentMoveSpeed; set => currentMoveSpeed = value; }

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        InitHP();
        InitGravity();
        InitMoveSpeed();
        StartCoroutine(DecayingCharSpeed());
    }

    void FixedUpdate(){
        if (!GameCounter.GameStarted) return;
        UpdateCharGravity(currentGravity);
    }

    void UpdateCharGravity(float gravity){
        rb.gravityScale = gravity;
    }

    #region Init Status/Status bar
        void InitHP(){
            currentHeatlh = maxHeatlh;
            healthBar.SetMaxValue(maxHeatlh);
            healthBar.SetValue(currentHeatlh);
        }

        void InitGravity(){
            rb.gravityScale = 0;
            gravityBar.SetMaxValue(maxGravity);
            gravityBar.SetValue(currentGravity);
        }

        void InitMoveSpeed(){
            speedBar.SetMaxValue(maxMoveSpeed);
            speedBar.SetValue(currentMoveSpeed);
        }
    #endregion

    #region Modify Status bar/ Losing condition
        public void TakeDamage(int damage){
            if (currentHeatlh < 1) return;
            currentHeatlh -= damage;
            healthBar.SetValue(currentHeatlh);
            if (currentHeatlh <= 0)
                LevelLoader.instance.OnPlayerDeath();
        }
        public void TakeHeal(int heal){
            if (currentHeatlh >= maxHeatlh) return;
            currentHeatlh += heal;
            healthBar.SetValue(currentHeatlh);
        }

        public void MultiplyGravity(float multiplier){
            currentGravity *= multiplier;
            gravityBar.SetValue(currentGravity);
        }

        public void MultiplyMoveSpeed(float multiplier){
            currentMoveSpeed *= multiplier;
            speedBar.SetValue(currentMoveSpeed);
        }

        public void AddMoveSpeed(float amount){
            currentMoveSpeed += amount;
            speedBar.SetValue(currentMoveSpeed);
        }

        IEnumerator DecayingCharSpeed(){
            while (true){
                while (currentMoveSpeed > minMoveSpeed){
                    currentMoveSpeed -= speedDecayAmount;
                    speedBar.SetValue(currentMoveSpeed);
                    yield return new WaitForSeconds(speedDecayInterval);
                }
                yield return new WaitForSeconds(0.1f);
                // yield return new WaitUntil(() => currentMoveSpeed > minMoveSpeed);
            }  
        }
    #endregion
}
