using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class Interactor : MonoBehaviour
{

    /* [SerializeField] private Transform interactionPoint;

     [SerializeField] private float interactionPointRadius = 0.5f;

     [SerializeField] private LayerMask interactableMask;

     [SerializeField] private InteractionPromptUI interactionPromptUI;

     private readonly Collider[] colliders = new Collider[3];

     [SerializeField] private int numfound;

     private InterfaceInteractable _interactable;

     private void Update()

     {

         numfound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

         if (numfound > 0)

         {

             _interactable = colliders[0].GetComponent<InterfaceInteractable>();

             if (_interactable != null)

             {

                 if (!interactionPromptUI.IsDisplayed) interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                 if (Input.GetKey(KeyCode.E))
                 {
                     _interactable.Interact(this);

                 }

             }

         }

         else

         {

             if (_interactable != null) _interactable = null;

             if (interactionPromptUI.IsDisplayed) interactionPromptUI.Close();

         }

     }

     private void OnDrawGizmos()

     {

         Gizmos.color = Color.red;

         Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);

     }*/

    Outline outline;
    public string message;

    public UnityEvent onInteraction;
    AudioManager audiomanager;
    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline(); 
    }
    public void Interact()
    {
        onInteraction.Invoke();
        audiomanager.PlaySfx(audiomanager.CollectTrinkets);
    }
    public void DisableOutline()
    {
        outline.enabled = false; 
    }
    public void EnableOutline()
    {
        outline.enabled = true;
    }
    public void DisableThis()
    {
        this.enabled = false;
    }

}



