using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {
    public Weapon currentWeap;
    public Weapon[] weapons;

	void Start () {
	
	}
	
	void Update () {
	
	}

    void setCurrentWeap(Weapon weapon)
    {
        currentWeap = weapon;
    }
}
