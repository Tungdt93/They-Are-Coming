using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHolderAnimation : ObjectAnimation, ISubcribers
{
    private PowerUpHolder powerUpHolder;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        powerUpHolder = GetComponent<PowerUpHolder>();
        SubscribeEvent();
    }

    private void OnDisable()
    {
        UnsubscribeEvent();
    }

    public void SubscribeEvent()
    {
        powerUpHolder.OnDeactivateHolder += DeactivateHolderAnim;
    }

    public void UnsubscribeEvent()
    {
        powerUpHolder.OnDeactivateHolder -= DeactivateHolderAnim;
    }

    private void DeactivateHolderAnim()
    {
        animator.SetBool("Deactivate", true);
    }
}
