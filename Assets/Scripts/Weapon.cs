using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
    public string name;
    public float damage;
    public float fireRate;

    public Weapon(string name, float damage, float fireRate)
    {
        this.name = name;
        this.damage = damage;
        this.fireRate = fireRate;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
