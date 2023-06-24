using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform[] weapons;

    [Header("Keys")]
    [SerializeField]
    private KeyCode[] keys;

    [Header("Settings")]
    [SerializeField]
    private float switchTime;

    private int selectedWeapon;
    private float timeSinceLastSwitch;

    private Sprite weaponIcon;
    private string weaponAmmo;

    WeaponInfoUI weaponInfoUI;

    // Start is called before the first frame update
    void Start()
    {
        SetWeapons();
        weaponInfoUI = GameObject.Find("WeaponInfo").GetComponent<WeaponInfoUI>();
        Select(selectedWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]) && timeSinceLastSwitch >= switchTime)
            {
                selectedWeapon = i;
                //récupérer ici la valeur de l'arme équipée
            }

            if (previousSelectedWeapon != selectedWeapon)
            {
                Select(selectedWeapon);
            }
            timeSinceLastSwitch += Time.deltaTime;
        }
    }

    public void SetWeapons()
    {
        weapons = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            weapons[i] = transform.GetChild(i);
        }
        if (keys == null)
            keys = new KeyCode[weapons.Length];
    }

    public void SetWeaponOnPickUp()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            weapons[i] = transform.GetChild(i);
        }
        if (keys == null)
            keys = new KeyCode[weapons.Length];
    }

    public void Select(int weaponIndex)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == weaponIndex);
            Debug.Log(
                weapons[i].gameObject.name
                    + " a un index de "
                    + weapons[i].transform.GetSiblingIndex()
            );
        }

        weaponIcon = GetComponentInChildren<Gun>().getWeaponIcon();
        weaponAmmo = GetComponentInChildren<Gun>().getCurrentAmmo().ToString();
       // weaponMagSize = GetComponentInChildren<Gun>().getMagSize().ToString();
        weaponInfoUI.SetWeaponInfo(weaponIcon, weaponAmmo);

        timeSinceLastSwitch = 0f;
        Debug.Log("Changement d'arme");
    }

    public int getSelectedWeaponIndex()
    {
        return selectedWeapon;
    }
}
