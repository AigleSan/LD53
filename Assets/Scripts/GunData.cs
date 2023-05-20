using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Gun", menuName ="Weapon/Gun")]
public class GunData : ScriptableObject
{
    [Header("Info")]
    public new string name;

    public Sprite weaponIcon;

    [Header("Shooting")]
    public float damage;

    [Header("Reloading")]
    public int currentAmmo;
    public int magSize;
    public float bulletSpeed;
    public float fireRate;
    public float reloadTime;
    
    //[HideInInspector]
    public bool reloading;
}
