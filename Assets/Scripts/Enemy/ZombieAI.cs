using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    public Transform[] waypoints;
    public float chaseDistance = 10f;
    public float stopChaseDistance = 15f;
    public float waitTimeAtWaypoint = 3f;

    private NavMeshAgent agent;
    private int currentWaypointIndex;
    private bool waypointSet;
    private bool isWaiting;
    private Animator animator;

    private enum State { Walking, Chasing, Waiting }
    private State currentState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        currentState = State.Walking;
        SelectRandomWaypoint();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case State.Walking:
                WalkToWaypoint();

                if (distanceToPlayer <= chaseDistance)
                {
                    currentState = State.Chasing;
                }
                break;

            case State.Chasing:
                ChasePlayer();

                if (distanceToPlayer > stopChaseDistance)
                {
                    currentState = State.Walking;
                    SelectRandomWaypoint();
                }
                break;

            case State.Waiting:
                // Do nothing
                break;
        }

        UpdateAnimation();
    }

    void WalkToWaypoint()
    {
        if (!waypointSet) SelectRandomWaypoint();

        if (waypointSet)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);

            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 1f)
            {
                waypointSet = false;
                currentState = State.Waiting;
                StartCoroutine(WaitAtWaypoint());
            }
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        agent.isStopped = true;
        yield return new WaitForSeconds(waitTimeAtWaypoint);
        agent.isStopped = false;
        isWaiting = false;
        currentState = State.Walking;
        SelectRandomWaypoint();
    }

    void SelectRandomWaypoint()
    {
        if (waypoints.Length > 0)
        {
            currentWaypointIndex = Random.Range(0, waypoints.Length);
            waypointSet = true;
        }
        else
        {
            Debug.LogWarning("No waypoints assigned!");
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void UpdateAnimation()
    {
        if (animator != null)
        {
            bool isRunning = (currentState == State.Chasing) || (currentState == State.Walking && !isWaiting);
            animator.SetBool("isRunning", isRunning);
        }
    }
}