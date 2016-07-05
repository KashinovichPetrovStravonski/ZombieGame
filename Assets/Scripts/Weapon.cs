using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class Weapon : MonoBehaviour {

    [XmlAttribute("name")]
    public string wName;
    [XmlElement("Damage")]
    public float damage;
    [XmlElement("FireRate")]
    public float fireRate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
