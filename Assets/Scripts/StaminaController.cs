using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    /* [Header("Stamina Main Parameters")]
     public float playerStamina = 100.0f;
     [SerializeField] private float maxStamina = 100.0f;
     [SerializeField] private float jumpCost = 20;
     [HideInInspector] public bool hasRegenerated = true;
     [HideInInspector] public bool weArtSprinting = false;

     [Header("Stamina Regen Parameters")]
     [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f;
     [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;

     [Header("Stamina Speed Parameters")]
     [SerializeField] private int slowedRunSpeed = 4;
     [SerializeField] private int normalRunSpeed = 7;

     [Header("Stamina UI Elements")]
     [SerializeField] private Image staminaProgressUI = null;
     [SerializeField] private CanvasGroup sliderCanvasGroup = null;

     private PlayerMovement playerMove;


   public float MaxStamina = 100.0f;
     public float currentStamina;
    public float staminaRegRate = 0.5f;
    public float staminaDrain = 0.5f;
    private PlayerMovement playerMove;
    
    
     private void Start()
     {
         playerMove = GetComponent<PlayerMovement>(); 
     }

     private void Update()
     {
         if(!weAreSprinting)
         {
             if(playerStamina <= maxStamina -0.01)
             {
                 playerStamina += staminaRegen * Time.deltaTime;
                 UpdateStamina(1);
                 if(playerStamina >= maxStamina)
                 {
                     //set to normal speed 
                     sliderCanvasGroup.alpha = 0; 
                     hasRegenerated = true;

                 }
             }    
         }
     }

     public void Sprinting()
     {
         if(hasRegenerated)
         {
             weArtSprinting = true;
             playerStamina -= staminaDrain * Time.deltaTime;
             UpdateStamina(1); 
             if(playerStamina <= 0)
             {
                 hasRegenerated = false;
                 //slow player
                 sliderCanvasGroup.alpha = 0; 
             }
         }
     }

     public void StaminaJump()
     {
         if(playerStamina >= (maxStamina *jumpCost /maxStamina))
         {
             playerStamina -= jumpCost;
             playerMove.jumpCool
             UpdateStamina(1);
         }
     }

     void UpdateStamina (int value)
     {
         staminaProgressUI.fillAmount = playerStamina / maxStamina;
         if(value == 0)
         {
             sliderCanvasGroup.alpha = 0; 
         }
         else
         {
             sliderCanvasGroup.alpha = 1; 

         }
     }*/
}
