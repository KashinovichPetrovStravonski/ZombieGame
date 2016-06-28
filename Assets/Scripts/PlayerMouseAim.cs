using UnityEngine;
using System.Collections;

public class PlayerMouseAim : MonoBehaviour {
    public Transform shotPos;
    public int layerMask = 9; //Ignore the "Enemy" layer only
    private Vector3 camHitVector;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Ray from camera to cursor
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit camRayHit;
        Physics.Raycast(camRay, out camRayHit, Mathf.Infinity, (1 << layerMask));
        camHitVector = new Vector3(camRayHit.point.x, camRayHit.point.y + 1, camRayHit.point.z); //Point of hit, raise by 1

        transform.LookAt(new Vector3(camRayHit.point.x, transform.position.y, camRayHit.point.z)); //makes the player face the cursor
        shotPos.LookAt(camHitVector); //Points the aim to where the mouse clicks and raises it by 1
    }

    public Vector3 getCamHitVector()
    {
        return camHitVector;
    }
}
