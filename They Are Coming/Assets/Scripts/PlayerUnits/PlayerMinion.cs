using System;
using UnityEngine;

public class PlayerMinion : PlayerUnit
{
    private void OnEnable()
    {
        InitializeVariables();
        InitializeModel();
        playerMain.OnPickedUpNewWeapon += InitializeWeapon;
    }

    private void OnDisable()
    {
        playerMain.OnPickedUpNewWeapon -= InitializeWeapon;
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

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }
    }   
}
