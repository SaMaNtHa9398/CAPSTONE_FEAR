using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    //public float health;

    public LayerMask whatIsGround, whatIsPlayer;
   
   
    //patroling
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;

   
    public Transform enemyAttackPoint;
    public int Damage; 

    //Attacking 
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States 
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Animator animator; 

    private WaveSpawner waveSpawner;

    //player health reference 
    //public PlayerHealthScript playerHealth; 

    private void Start()
    {
        waveSpawner = GetComponentInParent<WaveSpawner>();
    }
    private void Awake()
    {
        player = GameObject.Find("mila").transform;

        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {

        // check fpr sight and attack range 
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }
    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkpoint);

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        // calcuate random Point in range 
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkpoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        // make sure enemy doesnt move 
        agent.SetDestination(transform.position);
        playerInAttackRange = true;
        animator.SetBool("PlayerInAttackRange", true);
        transform.LookAt(player);

        if (alreadyAttacked)
        {
            if (CompareTag("MeleeEnemy"))
            {

                ///attack code melee
               
                Collider[] hitplayer = Physics.OverlapSphere(enemyAttackPoint.position, attackRange, whatIsPlayer); 

                foreach(Collider player in hitplayer)
                {
                    Debug.Log("we hit" + player.name);
                    player.GetComponent<PlayerHealthScript>().takeDamage(Damage);
                }

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks); 
            }
            else if(CompareTag("RangeEnemy"))
            {
                Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

                rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
                rb.AddForce(transform.up * 8f, ForceMode.Impulse);
                player.GetComponent<PlayerHealthScript>().takeDamage(Damage);
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks); 
            }
        }
            animator.SetBool("PlayerInAttackRange", false);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

   /* public void TakeDamage(int Damage)
    {
        health -= Damage;

        // player hurt animation


        if (health <= 0) Invoke(nameof(DestoryEnemy), 0.2f);
        

    }*/

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, sightRange);
    }

   
}
