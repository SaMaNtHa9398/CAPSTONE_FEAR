using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        public DescructibleWall wall; 
       
        private Animator doorAnim;
        private bool doorOpen = false;
       // [Header("Animation Names")]
       // [SerializeField] private string openAnimationName = "DoorOpen";
       //[SerializeField] public GameObject door;
        //public Collider boxCollider; 
        // public MeshRenderer meshrenderer;
        //[SerializeField] private string closeAnimationName = "DoorClose";
        [SerializeField] private int timeToShowUI = 1;
         
        [SerializeField] private GameObject showDoorLockUI = null;
        [SerializeField] private KeyInventory _keyInventory = null;
        

        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;

        private void Start()
        {
            wall = GetComponentInChildren<DescructibleWall>(); 
        }
        private void Update()
        {
            PlayAnimation(); 
        }
        private void Awake()
        {
           // doorAnim = gameObject.GetComponent<Animator>();
            //door.SetActive(true);
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
            
           else if (_keyInventory.hasDoor2Key)
            {
                OpenDoor();
            }
            else if (_keyInventory.hasDoor3Key)
            {
                OpenDoor();
            }
            else if (_keyInventory.hasDoor4Key)
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
               
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
                wall.Open(); 
               
            }
            else if (doorOpen && !pauseInteraction)
            {
      
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