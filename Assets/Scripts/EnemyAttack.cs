using UnityEngine;
using System;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
    public float attackDistance = 2;
    public float coolDownTime = 1;
    private float coolDown;
    public float attackDamage = 1;
    public float pushSpeed = 0.2f;
    private GameObject target;

    void Start () {
        coolDown = coolDownTime;
        target = GameObject.Find("Player");
    }
	
	void FixedUpdate () {
        if (target != null) //in case of player death
        {
            Vector3 targetVector = target.transform.position - transform.position;
            coolDown -= Time.deltaTime;
      
            if (targetVector.magnitude <= attackDistance && coolDown <= 0)
            {
                coolDown = coolDownTime;
                target.GetComponent<Health>().setHealth(target.GetComponent<Health>().getHealth() - attackDamage);
            }
        }
	}
}
