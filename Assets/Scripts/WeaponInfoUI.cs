using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponInfoUI : MonoBehaviour
{
    // Start is called before the first frame update

    public Image weaponIcon;
    public TMP_Text currentAmmo, magSize;

    //public Gun gun;


    void Start()
    {
        //gun = GetComponent<Gun>();
        //SetWeaponInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWeaponInfo(Sprite icon, string currentAmmo, string magSize){
        //gun = GameObject.Find("Player").GetComponentInChildren<Gun>(true);
        
        this.weaponIcon.sprite = icon;
        this.currentAmmo.text = currentAmmo;
        this.magSize.text = magSize;


    }

    public void SetCurrentAmmo(string currentAmmo){
        this.currentAmmo.text = currentAmmo;

    }
}
