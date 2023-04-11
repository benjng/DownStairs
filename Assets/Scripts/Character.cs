using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float characterGravity = 1.1f;
    [SerializeField] private GameObject gameManager; 

    private bool isFalling = true;
    private float moveSpeed = 10;
    private string currentState = "firstFall";
    private Animator animator;
    private bool gameStarted = false;
    
    public float ScreenLx { get; set; }
    public float ScreenRx { get; set; }
    public Rigidbody2D Rb { get; set; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public string CurrentState { get => currentState; set => currentState = value; }
    public bool IsFalling { get => isFalling; set => isFalling = value; }

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Rb.gravityScale = 0;
        animator = GetComponent<Animator>();
        // Animator.SetTrigger("startFalling"); // Starts game with startfalling animation
        ScreenRx = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        ScreenLx = -ScreenRx;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (currentState != "firstFall")
            return;
    
        if (Rb.velocity.y > -0.01) {
            currentState = "isIdle"; 
            animator.SetBool(currentState, true);
        }
    }
    
    public virtual void AnimationStateController(int xInput)
    {
        if (currentState == "firstFall"){
            return;
        }
        if (Rb.velocity.y < -0.5)
        {
            if (isFalling) // Return if already isFalling
                return;
            animator.SetTrigger("startFalling");
            isFalling = true;
            return;
        }

        // Not falling
        isFalling = false;
        string newState;

        if (xInput < 0) {
            newState = "isWalkingLeft";
        } else if (xInput > 0) {
            newState = "isWalkingRight";
        } else {
            newState = "isIdle";
        }

        // Return if new is current
        if (newState == currentState) {
            return;
        }

        // Disable current and Enable new. Set new to current
        animator.SetBool(currentState, false);
        animator.SetBool(newState, true);
        currentState = newState;
    }

    public int Control()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2)
            {
                return 1;
            }
            return -1;
        }
        return 0;
    }

    public void Movement(int xInput)
    {
        float currentMovement = xInput * moveSpeed * Time.fixedDeltaTime;
        transform.position += new Vector3(currentMovement, 0, 0);
        
        // Character Warpping
        if (transform.position.x < ScreenLx)
        {
            transform.position = new Vector3(ScreenRx, transform.position.y, transform.position.z);
        } else if (transform.position.x > ScreenRx)
        {
            transform.position = new Vector3(ScreenLx, transform.position.y, transform.position.z);
        }
    }

    public void InitCharGravity(float gravity){
        // Character Gravity Init
        if (Rb.gravityScale == 0)
        {
            Rb.gravityScale = gravity;
        }
    }

    public void CheckCharSurvive(){
        // When character touching bottom
        if (transform.position.y <= -Camera.main.orthographicSize)
        {
            //SceneManager.LoadScene(2);
        }
    }
    
    void FixedUpdate()
    {
        // Check if game has started by UI counter
        if (!gameStarted)
        {
            gameStarted = GameManager.gameStarted;
            return;
        }

        InitCharGravity(characterGravity);
        int xInput = Control();
        AnimationStateController(xInput);
        Movement(xInput);
        CheckCharSurvive();
    }

    public class CharacterStub : Character 
    {
        public override void AnimationStateController(int xInput)
        {
            if (currentState == "firstFall"){
                return;
            }
            if (Rb.velocity.y < -0.5)
            {
                if (isFalling) // Return if already isFalling
                    return;
                isFalling = true;
                return;
            }

            // Not falling
            isFalling = false;
            string newState;

            if (xInput < 0) {
                newState = "isWalkingLeft";
            } else if (xInput > 0) {
                newState = "isWalkingRight";
            } else {
                newState = "isIdle";
            }

            // Return if new is current
            if (newState == currentState) {
                return;
            }
            currentState = newState;
        }
    }
}