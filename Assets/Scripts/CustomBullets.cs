using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBullets : MonoBehaviour
{
    //Assignables 
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemy;
    //Stats 
    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;
    //damage 
    public int explosionDamage;
    public float explosionRange, explosionForce;
    //Lifetime 
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;
    int collisions;
    PhysicMaterial physics_mat;
    private void Start()
    {
        SetUp();
    }
    private void Awake()
    {
    }
    private void Update()
    {
        // when to explode 
        if (collisions > maxCollisions) Explode();
        //countdown lifetime 
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Explode();
    }
    private void Explode()
    {
        //instantiate explosion 
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
        //check for enemies 
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyHealth>().TakeDamage(explosionDamage);
            if (enemies[i].GetComponent<Rigidbody>())
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
        }
        //add a little delay, just to make sure everything works fine 
        Invoke("Delay", 0.03f);
    }
    private void Delay()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {

        //dont count collisions with other bullets 
        //if (collision.collider.CompareTag("Bullet")) return;
        //count up collisions
        collisions++;
        // explode if bullet hits an enemy directly and explodeontouch is activated 
        if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Environment") && explodeOnTouch) Explode();
    }
    private void SetUp()
    {
        //create new physic material 
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //assign material to collider 
        GetComponent<SphereCollider>().material = physics_mat;
        //SetGravity 
        rb.useGravity = useGravity;
    }
    private void OnDrawGizmosSelected()


    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explosionRange);


    }

}
