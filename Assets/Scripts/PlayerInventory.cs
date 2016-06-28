using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {
    public Weapon currentWeap;
    public List<Weapon> weaponList;

	void Start () {
        currentWeap = new Weapon("pistol", 1, 0.3f);
    }
	
	void Update () {
	
	}

    public void setCurrentWeap(Weapon weapon)
    {
        currentWeap = weapon;
    }

    public Weapon getCurrentWeap()
    {
        return currentWeap;
    }

    public void AddWeapToInv(Weapon weapon)
    {
        weaponList.Add(weapon);
    }

    public void RemoveWeapFromInv(Weapon weapon)
    {
        weaponList.Remove(weapon);
    }
}
