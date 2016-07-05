using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class PlayerInventory : MonoBehaviour {
    public Weapon currentWeap;
    public List<Weapon> weaponList;

	void Start () {
        var weaponContainer = XMLWeaponContainer.read(Path.Combine(Application.dataPath, "WeaponCollection.xml"));
        print("Load!");
        print(weaponContainer.weaponList.Count);
        print(weaponContainer.weaponList.ToString());
      //  currentWeap = weaponContainer.weaponList.Find(); //Get weapon from XML
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
/*
    public void AddWeapToInv(Weapon weapon)
    {
        weaponList.Add(weapon);
    }

    public void RemoveWeapFromInv(Weapon weapon)
    {
        weaponList.Remove(weapon);
    }*/
}
