using System;
using UnityEngine;

public class SwitchArme : MonoBehaviour
{
    private int selectWeapon;

    public void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectWeapon >= transform.childCount - 1)
                selectWeapon = 0;
            else
                selectWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectWeapon <= 0)
                selectWeapon = transform.childCount -1;
            else
                selectWeapon--;
        }
        SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}