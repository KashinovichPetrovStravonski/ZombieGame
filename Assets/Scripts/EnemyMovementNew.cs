using UnityEngine;
using System.Collections;

public class EnemyMovementNew : MonoBehaviour {

    private CharacterController controller;
    public float runSpeed = 0.1f;
    private Vector3 targetVector;
    private Transform target;

    void Start () {
        controller = this.GetComponent<CharacterController>();
        target = GameObject.Find("Player").transform;
    }

	void FixedUpdate () {
        if (target != null) //in case of player death
        {
            controller.Move((target.position - transform.position) * runSpeed); //Run direction
            if (controller.velocity != new Vector3(0, 0, 0))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(controller.velocity), 0.2f); //look direction
            }
        }
    }
}
