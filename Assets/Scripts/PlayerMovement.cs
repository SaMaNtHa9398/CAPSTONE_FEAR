using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{



    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed; 
    public float groundDrag;
    public bool weAreSprinting = false; 

    [Header("Jump")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    /*[Header("Crouching")]
    public float crouchSpeed;
    public float crouchYscale;
    public float startYscale;*/

    [Header("keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
   // public KeyCode CrouchKey = KeyCode.LeftControl; 

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    public RaycastHit slopeHit;
    private bool exitingSlope;

    [Header("Fucking UI Shit for Stamina")]
    public Image StaminaBar;
    public float Stamina, MaxStamina;
    public float JumpCost, SprintCost, chargeRate;
    private Coroutine recharge; 

    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    
    public MovementState state; 
    public enum MovementState
    {
        walking, 
        sprinting, 
       // crouching, 
        air
    }


    private void Start()
    {
       // stamina = GetComponent<StaminaController>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
       
        readyToJump = true;

        //  HARD RESET
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        Debug.Log("Rigidbody Reset: " + rb.velocity);

        // startYscale = transform.localScale.y; 
    }


    private void Update()
    {
        Debug.Log("Player Position: " + transform.position);
        Debug.Log("Update is running...");
        // ground check 
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        
        MyInput();
        SpeedControl();
        StateHandler();

        //handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0; 
     
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate is running...");
        MovePlayer(); 
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Debug.Log("Horizontal: " + Input.GetAxisRaw("Horizontal") + " | Vertical: " + Input.GetAxisRaw("Vertical"));
        //when to jump 
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
       
        /*start crouching
        if(Input.GetKey(CrouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYscale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse); 
        }

        //stop crouching
        if (Input.GetKeyUp(CrouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYscale, transform.localScale.z);
        }*/
    }

    private void StateHandler()
    {
        
        // Mode - Sprinting
       if(grounded && Input.GetKey(sprintKey) && Stamina>0)
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
            Stamina -= SprintCost * Time.deltaTime;
            StaminaDecrease();
            weAreSprinting = true;
        }   
        
        // Mode - Walking 
        else if(grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed; 
        }

        // Mode - Air
        else
        {
            state = MovementState.air; 
        } 
           
    }
    private void MovePlayer()
    {
        //calculate movement direction 
        // moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //Vector3 force = moveDirection.normalized * moveSpeed * 10f;
        //Debug.Log("Force Applied: " + force);
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        Vector3 force = moveDirection.normalized * moveSpeed * 10f;

        Debug.Log("Applying Force: " + force);

        if (grounded)
        {
            rb.AddForce(force, ForceMode.Force);
        }





        // on slope 
        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);


            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }


        //on ground
        else if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            
        }

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        // turn gravity off while on slope
        rb.useGravity = !OnSlope(); 
    }

    private void SpeedControl()
    {
        // limiting speed on slope 
        if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > moveSpeed)
                rb.velocity = rb.velocity.normalized * moveSpeed; 
        }

        // limiting speed on ground or in air 
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            //limit velocity if needed  
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z); 
            }
        }

    }

    private void Jump()
    {
        if (Stamina >= JumpCost)
        {
            exitingSlope = true;
            // reset y velocity 
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            Stamina -= JumpCost;
            StaminaDecrease();
        }
    }

    private void ResetJump()
    {
        readyToJump = true;

        exitingSlope = false; 
    }

    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0; 
        }

        return false; 
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized; 
    }

    private void StaminaDecrease()
    {
        if (Stamina <= 0) Stamina = 0;
        StaminaBar.fillAmount = Stamina / MaxStamina;
        if (recharge != null) StopCoroutine(recharge);
        recharge = StartCoroutine(RechargingStamina());
    }

    private IEnumerator RechargingStamina()
    {
        yield return new WaitForSeconds(10f);
    

        while (Stamina < MaxStamina)
        {
            Stamina += chargeRate / 10f;
            if (Stamina > MaxStamina) Stamina = MaxStamina;
            StaminaBar.fillAmount = Stamina / MaxStamina; 
            yield return new WaitForSeconds(0.1f);
        }
        while(Stamina <= 0)
        {
            sprintSpeed = 0;
            jumpForce = 0;
            airMultiplier = 0;
        }
    }
}
