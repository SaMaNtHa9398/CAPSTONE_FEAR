using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{

    [SerializeField] private Transform interactionPoint;

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

                if (Input.GetKey(KeyCode.E)) _interactable.Interact(this);

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

    }
}



