using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
    public string wName;
    public float damage;
    public float coolDown;

    public Weapon(string wName, float damage, float coolDown)
    {
        this.wName = wName;
        this.damage = damage;
        this.coolDown = coolDown;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
