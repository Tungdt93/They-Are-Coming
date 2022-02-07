﻿using UnityEngine;

public class PlayerMinion : PlayerUnit
{
    private PlayerMain playerMain;

    private void OnEnable()
    {
        playerMain = PlayerMain.Instance;
        rb = GetComponent<Rigidbody>();
        InstantiateModel();
    }

        public void InstantiateModel()
    {
        Instantiate(unitInfo.model, this.visual.transform);
        Instantiate(weapon.gameObject, weaponHolder.transform);
    }

    private void Update()
    {
        rb.velocity = Vector3.zero;   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RightWall"))
        {
            playerMain.HasTouchedRightWall = true;
        }

        if (collision.gameObject.CompareTag("LeftWall"))
        {
            playerMain.HasTouchedLeftWall = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("RightWall"))
        {
            playerMain.HasTouchedRightWall = true;
        }

        if (collision.gameObject.CompareTag("LeftWall"))
        {
            playerMain.HasTouchedLeftWall = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("RightWall"))
        {
            playerMain.HasTouchedRightWall = false;
        }

        if (collision.gameObject.CompareTag("LeftWall"))
        {
            playerMain.HasTouchedLeftWall = false;
        }
    }
}
