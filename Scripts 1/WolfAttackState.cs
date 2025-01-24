using UnityEngine;
using UnityEngine.AI;

public class WolfAttackState : StateMachineBehaviour
{
    Transform player;
    NavMeshAgent agent;
    private EquipSystem equipSystem;


    public float stopAttackingDistance = 2.5f; // Distance to stop attacking
    public float attackRate = 1f;             // Rate of wolf attacks
    private float attackTimer;

    public int damageToInflict = 1;           // Damage dealt to the player
    public int wolfHealth = 100;              // Wolf's health

    private Transform waypointsCluster;       // Reference to the static waypoints cluster
    private Transform currentWaypoint;        // The current waypoint the wolf is moving toward
    public float waypointThreshold = 1f;      // Distance to consider a waypoint reached
    public float wanderSpeed = 3.5f;          // Speed during wandering

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        // Find the static waypoints cluster by tag
        GameObject waypointsObj = GameObject.FindGameObjectWithTag("Waypoints");
        if (waypointsObj != null)
        {
            waypointsCluster = waypointsObj.transform;
            SetRandomWaypoint(); // Set an initial random waypoint
        }

        attackTimer = 0;
        agent.speed = wanderSpeed; // Set wandering speed
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LookAtPlayer();

        // Wolf attacks if within range
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceFromPlayer <= stopAttackingDistance)
        {
            agent.isStopped = true; // Stop movement when attacking
            if (attackTimer <= 0)
            {
                Attack();
                attackTimer = 1f / attackRate;
            }
            else
            {
                attackTimer -= Time.deltaTime;
            }

            // Check if player attacks the wolf (left-click detection)
            if (Input.GetMouseButtonDown(0)) // 0 = left click
            {
                int damage = equipSystem != null && equipSystem.isAxeEquipped ? 20 : 5; // Axe deals more damage
                TakeDamage(damage);
            }
        }
        else
        {
            animator.SetBool("isAttacking", false);
            Patrol(); // Wolf patrols if out of attack range
        }
    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.position - agent.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        agent.transform.rotation = Quaternion.Lerp(agent.transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    private void Attack()
    {
        PlayerStatsManager.Instance.TakeDamage(damageToInflict);
    }

    private void TakeDamage(int damage)
    {
        wolfHealth -= damage;
        Debug.Log($"Wolf took damage! Current Health: {wolfHealth}");

        if (wolfHealth <= 0)
        {

            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Wolf has died!");
        agent.gameObject.SetActive(false); // Disable the wolf game object
        // Optionally, trigger death animations here
    }

    private void Patrol()
    {
        if (waypointsCluster == null || currentWaypoint == null) return;

        // Check if the wolf is currently moving
        if (!agent.pathPending && agent.remainingDistance <= waypointThreshold)
        {
            SetRandomWaypoint(); // Choose a new waypoint if the current one is reached
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(currentWaypoint.position); // Continue toward the current waypoint
        }
    }

    private void SetRandomWaypoint()
    {
        if (waypointsCluster.childCount > 0)
        {
            int randomIndex = Random.Range(0, waypointsCluster.childCount);
            currentWaypoint = waypointsCluster.GetChild(randomIndex); // Set a new random waypoint
            agent.SetDestination(currentWaypoint.position); // Start moving toward the new waypoint
            Debug.Log($"New waypoint selected: {currentWaypoint.name}");
        }
    }
}
