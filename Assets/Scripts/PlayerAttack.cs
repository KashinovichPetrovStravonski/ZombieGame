using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {
    public float coolDownTime;
    private float coolDown;
    public float shotDamage;
    private LineRenderer aim;
    private Transform shotPos;
    private Vector3 camHitVector;

    void Start () {
        coolDown = coolDownTime;
        aim = this.GetComponent<LineRenderer>();
    }
	
	void Update () {
        shotPos = this.GetComponent<PlayerMouseAim>().shotPos;
        camHitVector = this.GetComponent<PlayerMouseAim>().getCamHitVector();

        //Ray from character to cursor
        Ray shotRay = new Ray(shotPos.position, shotPos.forward);
        RaycastHit shotRayHit;
        bool shotHitBool = Physics.Raycast(shotRay, out shotRayHit);

        //Draw aim line
        aim.SetPosition(0, shotPos.position);
        if (shotHitBool && Vector3.Distance(shotPos.position, shotRayHit.point) <= Vector3.Distance(shotPos.position, camHitVector))
        {
            aim.SetPosition(1, shotRayHit.point); //If the aim is blocked, stop at the obstruction
        }
        else
        {
            aim.SetPosition(1, camHitVector); //If not, draw to cursor
        }
        coolDown -= Time.deltaTime;

        if (Input.GetButton("Fire1") && coolDown <= 0) {
            if (shotHitBool)
            {
                if (shotRayHit.collider.gameObject.layer == 8 && shotRayHit.collider.gameObject != gameObject)
                {
                    shotRayHit.collider.gameObject.GetComponent<Health>().setHealth(shotRayHit.collider.gameObject.GetComponent<Health>().getHealth() - shotDamage);
                }
            }
            coolDown = coolDownTime;
        }
    }
}
