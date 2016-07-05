using UnityEngine;
using System.Collections;

public class EnemyMovementNewNew : MonoBehaviour {
    public float runSpeed;
    public float walkSpeed;
    public Vector3 resetLastPlayerSighting = new Vector3(0,10,0);
    
    private GameObject target;
    private NavMeshAgent nav;
    private Vector3 lastPlayerSighting;


    // Use this for initialization
    void Start () {
        target = GameObject.Find("Player");
        nav = GetComponent<NavMeshAgent>();
        lastPlayerSighting = resetLastPlayerSighting;
    }
	
	// Update is called once per frame
	void Update () {
        Ray lookRay = new Ray(transform.position, target.transform.position - transform.position);
        RaycastHit lookRayHit;
        Physics.Raycast(lookRay, out lookRayHit);

        if (lookRayHit.collider.gameObject == target) //Player is seen
        {
            lastPlayerSighting = target.transform.position; //New last sighting
        }
        if (lastPlayerSighting != resetLastPlayerSighting) //Go to last sighting
        {
            if (nav.remainingDistance <= 0.1 && nav.remainingDistance != 0)
            {
                lastPlayerSighting = resetLastPlayerSighting;
            }
            else
            {
                Search();
            }
        }
        else //Idle
        {
            Idle();
        }

	}

    void Search()
    {
        nav.speed = runSpeed;
        nav.destination = lastPlayerSighting;
    }

    void Idle()
    {
        nav.speed = walkSpeed;
        if (nav.remainingDistance <= 0.1) {
            Vector3 newPos = transform.position;
            newPos.x = transform.position.x + Random.Range(-2, 2);
            newPos.z = transform.position.z + Random.Range(-2, 2);
            nav.destination = newPos;
        }
    }
}
