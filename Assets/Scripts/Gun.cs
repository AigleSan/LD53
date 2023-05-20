using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float timeSinceLastShot;

    [Header("References")]
    [SerializeField]
    GunData gunData;

    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    GameObject bulletPrefab;

    [HideInInspector]
    public int weaponCurrentAmmo;

    [HideInInspector]
    public int magSize;

    [HideInInspector]
    public Sprite weaponIcon;

    [HideInInspector]
    public PlayerRotation playerRotation;

    WeaponInfoUI weaponInfoUI;

    private void Start()
    {
        gunData.currentAmmo = gunData.magSize;
        PlayerShootScript.shootInput += Shoot;
        PlayerShootScript.reloadInput += StartReload;
        weaponInfoUI = GameObject.Find("WeaponInfo").GetComponent<WeaponInfoUI>();
        playerRotation = GameObject.Find("Player").GetComponent<PlayerRotation>();
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        Debug.DrawLine(shootPoint.position, shootPoint.forward);
        if (gunData.currentAmmo <= 0 && !gunData.reloading)
        {
            StartReload();
        }
    }

    private bool CanShoot() =>
        !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f) && CheckParent();

    public void Shoot()
    {
        Quaternion bulletHeading = playerRotation.playerRotation;

        if (gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                // Debug.Log("Shoot");
                // if (
                //     Physics.Raycast(
                //         shootPoint.position,
                //         transform.forward,
                //         out RaycastHit hitInfo,
                //         gunData.maxDistance
                //     )
                // )
                // {
                //     //Debug.Log(hitInfo.transform.name);
                //     IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                //     damageable?.TakeDamage(gunData.damage);
                // }
                GameObject bullet = Instantiate(
                    bulletPrefab,
                    shootPoint.position,
                    bulletHeading
                );
                //bullet.transform.rotation = Quaternion.identity;

                //bullet.transform.position += transform.forward * speed * Time.deltaTime;
                bullet
                    .GetComponent<Rigidbody>()
                    .AddForce(shootPoint.forward * gunData.bulletSpeed, ForceMode.Force);
                gunData.currentAmmo--;
                weaponInfoUI.SetCurrentAmmo(getCurrentAmmo().ToString());
                timeSinceLastShot = 0f;
                OnGunShot();
            }
        }
    }

    private void OnDisable()
    {
        gunData.reloading = false;
    }

    private bool CheckParent()
    {
        bool parent;

        if (transform.parent.name == "WeaponHolder")
        {
            parent = true;
            //return parent;
        }
        else
        {
            parent = false;
        }
        return parent;
    }

    public void StartReload()
    {
        if (!gunData.reloading && this.gameObject.activeSelf)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;
        yield return new WaitForSeconds(gunData.reloadTime);
        gunData.currentAmmo = gunData.magSize;
        weaponInfoUI.SetCurrentAmmo(getCurrentAmmo().ToString());
        gunData.reloading = false;
    }

    private void OnGunShot()
    {
        //throw new Not
        // Debug.Log("Effets tas capté");
    }

    public int getCurrentAmmo()
    {
        weaponCurrentAmmo = gunData.currentAmmo;
        return weaponCurrentAmmo;
    }

    public int getMagSize()
    {
        magSize = gunData.magSize;
        return magSize;
    }

    public Sprite getWeaponIcon()
    {
        weaponIcon = gunData.weaponIcon;
        return weaponIcon;
    }
}
