using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    float distX;
    float distY;
    float distZ;


    void Start () {
        distX = transform.position.x - target.position.x;
        distY = transform.position.y - target.position.y;
        distZ = transform.position.z - target.position.z;
    }
	
	void Update () {
        if (target != null) //in case of player death
        {
            transform.position = new Vector3(target.position.x + distX, target.position.y + distY, target.position.z + distZ);
        }
	}
}
