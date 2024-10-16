using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class AmmoText : MonoBehaviour
{
    public GunSystem gun;
    public TextMeshProUGUI text; 
    // Start is called before the first frame update
    void Start()
    {
        UpdateAmmoText(); 
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        text.text = $"{gun.currentAmmo} / {gun.maxAmmoClip} ||  {gun.currentAmmoClip}  / {gun.MaxAmmoSize}"; 
    }
}
