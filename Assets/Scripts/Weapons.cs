using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapons : ScriptableObject
{

    public float fireRate;
    public string weaponName;
    public GameObject bulletPrefab;
}
