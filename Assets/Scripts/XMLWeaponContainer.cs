using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

[XmlRoot("WeaponCollection")]
public class XMLWeaponContainer{

    [XmlArray("Weapons"), XmlArrayItem("Weapon")]
    public List<Weapon> weaponList = new List<Weapon>();

    public static XMLWeaponContainer read(string path)
    {
        var serializer = new XmlSerializer(typeof(XMLWeaponContainer));
        var stream = new FileStream(path, FileMode.Open);
        XMLWeaponContainer container = serializer.Deserialize(stream) as XMLWeaponContainer;
        stream.Close();
        return container;
    }

    public void write(string path)
    {
        var serializer = new XmlSerializer(typeof(XMLWeaponContainer));
        var stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, this);
        stream.Close();
    }
}
