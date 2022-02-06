﻿using System.Collections;
using UnityEngine;

public class PlayerMinion : PlayerUnit
{
    private PlayerMain playerMain;

    private void OnEnable()
    {
        playerMain = PlayerMain.Instance;
        rb = GetComponent<Rigidbody>();
        InstantiateModel();
    }

    private void Update()
    {
        rb.velocity = Vector3.zero;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyMinion"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 10f);
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
