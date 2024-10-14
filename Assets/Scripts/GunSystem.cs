using UnityEngine;
using TMPro;
using System.Collections; 


public class GunSystem : MonoBehaviour
{
    /* // bullet 
     public GameObject bullet;

     //bullet force 
     public float shootForce, upwardForce;

     // Gun Stats 
     public int damage;
     public float timeBetweenShooting, spread, range, timeBetweenShots;
     public int magazineSize, bulletsPerTap;
     public bool allowButtonHold;
     int bulletsLeft, bulletsShot;

     // bools 
     bool shooting, readyToShoot, reloading;

     //RELOAD
     public int maxAmmo = 10;
     private int currentAmmo;
     public float reloadTime = 1f; 

     //reference 
     public Camera fpsCam;
     public Transform attackPoint;
     public RaycastHit rayHit;
     public LayerMask whatIsEnemy;

     // graphics 
     public GameObject muzzleFlash, bulletHoleGraphic;
     public CameraShake camShake;
     public float camShakeMagnitude, camShakeDuration;
     public TextMeshProUGUI ammo;

     public bool allowInvoke = true;

     private void Start()
     {
         currentAmmo = maxAmmo; 
     }
     private void Awake()
     {
         bulletsLeft = magazineSize;
         readyToShoot = true;
     }
     private void Update()
     {
         MyInput();


         //set text variable

         if (currentAmmo <= 0)
         {
             reloading = true; 
             Reload();
             if (ammo != null) { ammo.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap); }
             return;
         }
     }
     private void MyInput()
     {
         if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
         else shooting = Input.GetKeyDown(KeyCode.Mouse0);

         //reloading
         if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        // reloading automatically when trying to shoot without ammo 
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

         //shoot
         if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
         {
             bulletsShot = 0;
             Shoot();
         }
     }

     void Reload()
     {
         Debug.Log("Reloading");
         currentAmmo = maxAmmo; 
     }
     private void Shoot()
     {
         readyToShoot = false;

         // calculate direction with spread 
         Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
         RaycastHit hit;

         Vector3 targetPoint;
         //raycast 
         if (Physics.Raycast(ray, out hit))
         {
             targetPoint = hit.point;
         }
         else
             targetPoint = ray.GetPoint(75);

         //calculating direction 
         Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

         //calculate spread 
         float x = Random.Range(-spread, spread);
         float y = Random.Range(-spread, spread);

         // calculate new direction with spread 
         Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);


         //shake camera 
         camShake.Shake(camShakeDuration, camShakeMagnitude);


         // instantiate bullet/projectile 
         GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
         // rotate bullet  to shoot direction 
         currentBullet.transform.forward = directionWithSpread.normalized;

         //add forces to bullets 
         currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
         currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

         //Instantiate muzzle flash, if you have one 
         if (muzzleFlash != null)
             Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

         Destroy(currentBullet, 5f);


         bulletsLeft--;
         bulletsShot++;



         if (allowInvoke)
         {
             Invoke("ResetShot", timeBetweenShooting);
             allowInvoke = false;
         }
         if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
             Invoke("Shoot", timeBetweenShots);
     }

     private void ResetShot()
     {
         readyToShoot = true;
         allowInvoke = true;
     }
     /*private void Reload()
     {
         reloading = true;
         Invoke("reloadFinished", reloadTime);
     }

     private void ReloadFinished()
     {
         bulletsLeft = magazineSize;
         reloading = false;
     }*/


    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 14f; 
    public float impactForce = 30f;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadtime = 2f; 
    private bool isReloading = false; 


    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public float nextTimeTofire = 0f;

    private void Start()
    {
        currentAmmo = maxAmmo; 
    }
    private void Update()
    {
        if (isReloading)
            return; 

        if(currentAmmo <= 0 || Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Reload());
            return; 
        }
        if(Input.GetButton("Fire1")&& Time.time >= nextTimeTofire)
        {
            nextTimeTofire = Time.time + 1f / fireRate; 
           Shoot(); 
        }
    }

    IEnumerator Reload()
    {
        isReloading = true; 
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadtime); 

        currentAmmo = maxAmmo;
        isReloading = false;
    }


    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--; 
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>(); 
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); 
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactEffect, 1f);
        }

    }

}