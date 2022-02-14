using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : ObjectAnimation, ISubcribers
{
    private Weapon weapon;
    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        weapon = GetComponent<Weapon>();
        SubscribeEvent();
    }

    private void OnDisable()
    {
        UnsubscribeEvent();
    }

    public void SubscribeEvent()
    {
        weapon.OnPickedUp += PickedUpNewWeapon;
    }


    public void UnsubscribeEvent()
    {
        weapon.OnPickedUp -= PickedUpNewWeapon;
    }

    private void PickedUpNewWeapon()
    {
        animator.SetBool("PickedUp", true);
    }
}
