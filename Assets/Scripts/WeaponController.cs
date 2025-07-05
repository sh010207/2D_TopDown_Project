using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float weaponSpeed = 5.0f;

    private void Update()
    {
        RotateWeapon();
    }

    private void RotateWeapon()
    {
        transform.Rotate(Vector3.back * weaponSpeed * Time.deltaTime);
    }
}
