using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {
    private float coolDown;
    private LineRenderer aim;
    public Light muzzleFlash; 

    void Start () {
        aim = this.GetComponent<LineRenderer>();
    }
	
	void Update () {
        //Info from other classes
        Weapon weapon = gameObject.GetComponent<PlayerInventory>().getCurrentWeap(); //Get the weapon the player is using
        Transform shotPos = this.GetComponent<PlayerMouseAim>().shotPos;
        Vector3 camHitVector = this.GetComponent<PlayerMouseAim>().getCamHitVector();


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

        if (Input.GetButton("Fire1") && coolDown <= 0) { //FIRE!
            StartCoroutine(muzzleFlashIni(0.01f));
            if (shotHitBool)
            {
                if (shotRayHit.collider.gameObject.layer == 8 && shotRayHit.collider.gameObject != gameObject)
                {
                    shotRayHit.collider.gameObject.GetComponent<Health>().setHealth(shotRayHit.collider.gameObject.GetComponent<Health>().getHealth() - weapon.damage);
                }
            }
            coolDown = weapon.coolDown;
            print("pew!");
        }
    }

    IEnumerator muzzleFlashIni(float seconds) //Muzzleflash turn on for x seconds
    {
        muzzleFlash.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        muzzleFlash.gameObject.SetActive(false);
    }
}
