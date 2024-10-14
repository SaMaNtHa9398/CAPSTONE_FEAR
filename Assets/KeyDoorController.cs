using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        // public MeshRenderer meshrenderer;
        private Animator doorAnim;
        //public Collider boxCollider; 
        private bool doorOpen = false;
        [Header("Animation Names")]
        [SerializeField] private string openAnimationName = "DoorOpen";
        [SerializeField] private string closeAnimationName = "DoorClose";
        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showDoorLockUI = null;
        [SerializeField] private keyInventory _keyInventory = null;
        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;
        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
        }
        /*private void Start()
        {
            //boxCollider = GetComponent<Collider>(); 
            //meshrenderer = GetComponent<MeshRenderer>();
            // Check if the MeshRenderer component is found
            //if (meshrenderer == null)
            {
                //Debug.LogError("No MeshRenderer found on this GameObject!");
            }
        }*/
        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
            if (_keyInventory.hasDoor1Key)
            {
                OpenDoor();
            }
            else
            {
                StartCoroutine(ShowDoorLocked());
            }
        }
        public void OpenDoor()
        {
            if (!doorOpen && !pauseInteraction)
            {
                // meshrenderer.enabled = true;
                //boxCollider.enabled = true;
                doorAnim.Play(openAnimationName, 0, 0.0f);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
            }
            else if (doorOpen && !pauseInteraction)
            {
                //meshrenderer.enabled = false;
                //boxCollider.enabled = false; 
                doorAnim.Play(closeAnimationName, 0, 0.0f);
                doorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }
        IEnumerator ShowDoorLocked()
        {
            showDoorLockUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorLockUI.SetActive(false);
        }
    }
}