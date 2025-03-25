using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    /* [Header("Movement")]
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

     [Header("keybinds")]
     public KeyCode jumpKey = KeyCode.Space;
     public KeyCode sprintKey = KeyCode.LeftShift;

     [Header("Ground Check")]
     public float playerHeight;
     public LayerMask whatIsGround;
     bool grounded;

     [Header("Slope Handling")]
     public float maxSlopeAngle;
     public RaycastHit slopeHit;
     private bool exitingSlope;

      [Header(" Stamina")]
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
         air
      }

     private void Start()
      {
         rb = GetComponent<Rigidbody>();
         rb.freezeRotation = true;

         readyToJump = true;
      }


     private void Update()
      {
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

        MovePlayer(); 
      }
     private void MyInput()
      {
         horizontalInput = Input.GetAxisRaw("Horizontal");
         verticalInput = Input.GetAxisRaw("Vertical");

          //when to jump  
         if (Input.GetKey(jumpKey) && readyToJump && grounded)
          {
             readyToJump = false;
             Jump();
             Invoke(nameof(ResetJump), jumpCooldown);
          }


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
          moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;



         // on slope  
         if (OnSlope() && !exitingSlope) 
          {
             rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

              if (rb.velocity.y > 0)
                  rb.AddForce(Vector3.down * 80f, ForceMode.Force);
          }
          // on ground  

          if (grounded)  
             rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

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
      }*/












    /* [Header("Movement")]
     public float moveSpeed;

     public float groundDrag;

     public float jumpForce;
     public float jumpCooldown;
     public float airMultipler;
     bool readyToJump;

     [Header("keybinds")]
     public KeyCode jumpKey = KeyCode.Space;

     [Header("Ground Check")]
     public float playerHeight;
     public LayerMask WhatIsGround;
     bool grounded; 

     public Transform orientation;

     float horizontalInput;
     float verticalInput;

     Vector3 moveDirection;

     Rigidbody rb;
     private void Start()
     {
         rb = GetComponent<Rigidbody>();
         rb.freezeRotation = true;
         readyToJump = true;
     }
     private void Update()
     {
         // ground check 
         grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, WhatIsGround); 

         MyInput();
         SpeedControl(); 

         //handle drag
         if (grounded)
             rb.drag = groundDrag;
         else
             rb.drag = 0; 
     }
     private void FixedUpdate()
     {
         MovePlayer(); 
     }

     private void MyInput()
     {
         horizontalInput = Input.GetAxisRaw("Horizontal");
         verticalInput = Input.GetAxisRaw("Vertical");

         //when to jump 
         if (Input.GetKey(jumpKey) && readyToJump && grounded)
         {
             readyToJump = false;
             Jump();
             Invoke(nameof(ResetJump), jumpCooldown);
         }
     }

     private void MovePlayer()
     {
         //calculate movement direction 
         moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
         if(grounded)
             rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
         else if(!grounded)
             rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultipler, ForceMode.Force);
     }

     private void SpeedControl()
     {
         Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z); 

         // limit velocity if needed 
         if(flatVel.magnitude > moveSpeed)
         {
             Vector3 limitedVel = flatVel.normalized * moveSpeed;
             rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
         }
     }

     private void Jump()
     {
         //reset y velocity 
         rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
         rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); 

     }
     private void ResetJump()
     {
         readyToJump = true; 

     }*/

    public CharacterController controller;
    public float speed = 4f;
    public float gravity = -9.81f;
    public float sprintSpeed = 10f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundmask;
    Vector3 velocity;
    bool isGrounded;

    [Header(" Stamina")]
    public Image StaminaBar;
    public float Stamina, MaxStamina;
    public float JumpCost, SprintCost, chargeRate;
    private Coroutine recharge;
    AudioManager audiomanager;
    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        Stamina = MaxStamina; 
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        //audiomanager.PlaySfx(audiomanager.Walk);

        if (Input.GetKey(KeyCode.LeftShift) && Stamina > 0)
        {
            controller.Move(move * sprintSpeed * Time.deltaTime); Stamina -= SprintCost * Time.deltaTime;
            StaminaDecrease();
            //audiomanager.PlaySfx(audiomanager.Running);
        }
        else
        {

            controller.Move(move * speed * Time.deltaTime);
        }

    

        if (Input.GetKey(KeyCode.Space) && isGrounded && Stamina >= JumpCost)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Stamina -= JumpCost;
            StaminaDecrease();
        }
      
            velocity.y += gravity * Time.deltaTime; // Apply gravity when not jumping
       

        controller.Move(velocity * Time.deltaTime);
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
            Stamina += chargeRate / 5f;
            if (Stamina > MaxStamina) Stamina = MaxStamina;
            StaminaBar.fillAmount = Stamina / MaxStamina;
            yield return new WaitForSeconds(0.1f);
        }
        while (Stamina <= 0)
        {
            sprintSpeed = 0;
            jumpHeight = 0;
           // yield return null;

        }

    }
}
