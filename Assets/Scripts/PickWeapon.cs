using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickWeapon : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject selectedWeapon,
        weaponToPick,
        weaponHolder;

    private bool pickUpPossible;

    WeaponHandler weaponHandler;

    void Start()
    {
        weaponHolder = GameObject.Find("WeaponHolder");
        weaponHandler = GetComponent<WeaponHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        selectedWeapon = weaponHolder.transform
            .GetChild(weaponHandler.getSelectedWeaponIndex())
            .gameObject;
    }

    void PickWeaponUp()
    {
        selectedWeapon = gameObject.GetComponentInChildren<Gun>().gameObject;
        //selectedWeapon.GetComponent<Gun>().enabled = false;
        selectedWeapon.transform.parent = weaponToPick.transform.parent;
        selectedWeapon.transform.position = weaponToPick.transform.position;
        selectedWeapon.transform.rotation = weaponToPick.transform.rotation;
        //weaponHandler.Select(weaponHandler.getSelectedWeaponIndex());

        //weaponToPick.transform.parent = gameObject.;
        Debug.Log(
            selectedWeapon.gameObject.name + " a été remplacée par " + weaponToPick.gameObject.name
        );
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Rentré en contact avec " + other.gameObject.name);
        if (other.gameObject.tag == "PickUp" && Input.GetKeyDown(KeyCode.E))
        {
            weaponToPick = other.transform.GetChild(0).gameObject;
            PickWeaponUp();
            //weaponToPick = other.gameObject.transform.GetChild(0).gameObject;
            //weaponToPick.GetComponent<Gun>().enabled = true;
            weaponToPick.transform.parent = weaponHolder.transform;

            weaponToPick.transform.position = weaponHolder.transform.position;
            weaponToPick.transform.rotation = weaponHolder.transform.rotation;
            weaponToPick.transform.SetSiblingIndex(weaponHandler.getSelectedWeaponIndex());
            weaponHandler.SetWeaponOnPickUp();
            weaponHandler.Select(weaponHandler.getSelectedWeaponIndex());
        }
    }
}
