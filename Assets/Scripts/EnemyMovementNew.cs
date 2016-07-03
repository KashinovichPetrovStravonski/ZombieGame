using UnityEngine;
using System.Collections;

public class EnemyMovementNew : MonoBehaviour {

    private CharacterController controller;
    public float runSpeed = 0.1f;
    public float shuffleSpeed = 0.05f;
    private Vector3 targetVector;
    private GameObject target;
    bool playerSeen;
    float timeSinceSeen = 0;
    public float memorySpan = 3;
    public Vector3 shuffleDest;

    void Start () {
        controller = this.GetComponent<CharacterController>();
        target = GameObject.Find("Player").gameObject;
        shuffleDest = transform.position;
    }

	void FixedUpdate () {
        if (target != null) //in case of player death
        {
            Ray lookRay = new Ray(transform.position, target.transform.position - transform.position);
            RaycastHit lookRayHit;
            Physics.Raycast(lookRay, out lookRayHit);

            if(lookRayHit.collider.gameObject == target) //Check if enemy sees player
            {
                playerSeen = true;
                timeSinceSeen = 0;
            }

            timeSinceSeen += Time.deltaTime; //Advance time

            if(timeSinceSeen > memorySpan) //Check if the time since the player was last seen exceeds the memoryspan
            {
                playerSeen = false;
            }

        
            if (playerSeen) //hunt
            {
                controller.Move((target.transform.position - transform.position) * runSpeed); //Run direction
                if (controller.velocity != new Vector3(0, 0, 0))
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(controller.velocity), 0.2f); //look direction
                }
            }
            else if(timeSinceSeen >= 1) //shuffle
            {
                print("time to do stuff!");
                if (shuffleDest == transform.position)
                {
                    print("new dest!");
                    timeSinceSeen = 0;

                    Vector3 newPos = transform.position;
                    newPos.x = transform.position.x + Random.Range(-1, 1);
                    newPos.z = transform.position.x + Random.Range(-1, 1);
                    shuffleDest = newPos;
                }
                else
                {
                    print("Moving!");
                    controller.Move((shuffleDest - transform.position) * shuffleSpeed);
                }
            }
            print(transform.position.x + ", " + transform.position.z);
            print(shuffleDest.x + ", " + shuffleDest.z);
        }
    }
}
