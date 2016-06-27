using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public float health;

	void Start () {
    }
	
	void Update () {
        if (health <= 0) {
            Destroy(gameObject);
        }
	}

    public void setHealth(float value) {
        health = value;
    }

    public float getHealth() {
        return health;
    }
}
