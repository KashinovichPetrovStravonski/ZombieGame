using UnityEngine;
using System.Collections;

public class PlayerMovementNew : MonoBehaviour
{
    private CharacterController controller;
    public float runSpeed = 0.2f;

    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        controller.Move(new Vector3(Input.GetAxis("Horizontal"), Physics.gravity.y, Input.GetAxis("Vertical")) * runSpeed); //Movement

        /*if (controller.velocity != new Vector3(0, 0, 0))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(controller.velocity), 0.2f); //look direction
        }*/
    }
}