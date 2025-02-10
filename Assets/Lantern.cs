using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Lantern : MonoBehaviour
{
    Light m_light;
    public bool drainOverTime;
    public bool isRecharging = false; 
    public float maxBrightness;
    public float minBrightness;
    public float drainRate;
    public Image LightBar;
    public float batteryhealth;
    private bool canRecharge = false;
    // Start is called before the first frame update
    void Start()
    {
        m_light = GetComponent<Light>(); 
    }

    // Update is called once per frame
    void Update()
    {
   
           m_light.intensity = Mathf.Clamp(m_light.intensity, minBrightness, maxBrightness);
            if (drainOverTime == true && m_light.enabled == true)
            {
                if (m_light.intensity > minBrightness)
                {
                    m_light.intensity -= Time.deltaTime * (drainRate / 500);
                    LightBar.fillAmount = m_light.intensity / maxBrightness;
                }
            }
         
         if(m_light.intensity <= minBrightness)
        {
            canRecharge = true; 
        }
        else
        {
            canRecharge = false;
        } 
       
       
        
        
        if (Input.GetKeyDown(KeyCode.X) && canRecharge)
        {
                     //ReplaceBattey(0.1f);
            float randomChance = Random.Range(0f, 1f); // Generate a number between 0 and 1

            if (randomChance <= 0.2f) // 20% chance to fully recharge
            {
                m_light.intensity = maxBrightness; // Instantly full
                Debug.Log("Lucky! Full recharge!");
            }
            else // 80% chance to recharge a small amount
            {
                float randomBatteryBoost = Random.Range(0.1f, 0.3f); // Small recharge between 0.1 - 0.3
                m_light.intensity = Mathf.Clamp(m_light.intensity + randomBatteryBoost, minBrightness, maxBrightness);
                Debug.Log("Partial recharge: " + randomBatteryBoost);
            }

        }


        if (Input.GetKeyDown(KeyCode.Q) )
            {
                m_light.enabled = !m_light.enabled; 
            }
    
    }
    public void ReplaceBattey(float amount)
    {
        // animation 
            m_light.intensity += batteryhealth;
        LightBar.fillAmount = m_light.intensity / maxBrightness;
    }
     
  
}
