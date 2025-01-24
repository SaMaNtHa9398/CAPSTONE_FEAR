using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Lantern : MonoBehaviour
{
    Light m_light;
    public bool drainOverTime;
    public float maxBrightness;
    public float minBrightness;
    public float drainRate;
    public Image LightBar; 
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
            if(Input.GetKeyDown(KeyCode.Q))
            {
                m_light.enabled = !m_light.enabled; 
            }

        if(Input.GetKeyDown(KeyCode.X))
        {

            ReplaceBattey(0.4f); 
        }
    }
    public void ReplaceBattey(float amount)
    {
        // animation 
        m_light.intensity += amount; 
    }
     
  
}
