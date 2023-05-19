using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public Transform currentObjective;
    public GameObject player = new GameObject();

    public List<Transform> wayPaints = new List<Transform>();
    NavMeshAgent bot;


    private void Awake()
    {
        bot = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentObjective = wayPaints[0];
        //NavMeshAgent bot = GetComponent<NavMeshAgent>();
        bot.destination = currentObjective.position;
    }

    private void OnDrawGizmos()
    {
        if (currentObjective != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(currentObjective.position, 1.5f);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistancePlayer();
        //bot.destination = objective.position;
        if (CheckDistanceToPoint() < 1.5)
        {

            foreach (Transform position in wayPaints)
            {
                Debug.Log("Searching");
                if (position != currentObjective)
                {
                    currentObjective = position;
                    bot.destination = currentObjective.position;
                    return;
                }
            }
        }
    }

    public float CheckDistanceToPoint()
    {
        Vector3 charPoint = Vector3.zero;
        if (currentObjective != null)
        {
            charPoint = currentObjective.position - transform.position;

            Debug.DrawLine(transform.position , currentObjective.position, Color.green);
            return charPoint.magnitude;
        }

        return -1;
    }

    public float CheckDistancePlayer()
    {
        Vector3 enemyDistance = Vector3.zero;

        enemyDistance =   player.transform.position - transform.position;

        Debug.Log(enemyDistance);

        return enemyDistance.magnitude;
    }

}
