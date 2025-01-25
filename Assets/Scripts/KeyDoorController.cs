using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        public DescructibleWall wall;

     
        private bool doorOpen = false;
      
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
      
        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {

            if (_keyInventory.hasDoor1Key && _keyInventory.Door1 || _keyInventory.hasDoor2Key && _keyInventory.Door2|| _keyInventory.hasDoor3Key && _keyInventory.Door3 || _keyInventory.hasDoor4Key && _keyInventory.Door4)
            {
            
                    OpenDoor();
      
            }

            else
            {
              
            }
        }
        public void OpenDoor()
        {

            if (!doorOpen)
            {

                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
                wall.Open();

            }
            if (doorOpen)
            {

                doorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }
      
    }
}