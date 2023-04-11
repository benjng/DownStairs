using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string currentState = "firstFall";
    public bool isFalling = true;
    public float screenLx,screenRx;
    public Rigidbody2D Rb { get; set; }
    public Animator Animator {get; set;}

    private float moveSpeed = 10;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    [SerializeField]
    private float characterGravity = 1.1f;
    [SerializeField]
    private GameObject gameManager; 


    private bool gameStarted = false;
    
    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Rb.gravityScale = 0;
        Animator = GetComponent<Animator>();
        // Animator.SetTrigger("startFalling"); // Starts game with startfalling animation
        screenRx = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        screenLx = -screenRx;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (currentState != "firstFall")
            return;
    
        if (Rb.velocity.y > -0.01) {
            currentState = "isIdle"; 
            Animator.SetBool(currentState, true);
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
            Animator.SetTrigger("startFalling");
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
        Animator.SetBool(currentState, false);
        Animator.SetBool(newState, true);
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
        if (transform.position.x < screenLx)
        {
            transform.position = new Vector3(screenRx, transform.position.y, transform.position.z);
        } else if (transform.position.x > screenRx)
        {
            transform.position = new Vector3(screenLx, transform.position.y, transform.position.z);
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