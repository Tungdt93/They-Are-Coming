using System.Collections;
using UnityEngine;

public class PlayerMinion : PlayerUnit
{
    private float distance;

    private void OnEnable()
    {
        InitializeVariables();
        InitializeModel();
        playerMain.OnPickedUpNewWeapon += InitializeWeapon;
        //StartCoroutine(TurnOnCharacterController());
    }

    private void OnDisable()
    {
        playerMain.OnPickedUpNewWeapon -= InitializeWeapon;
    }

    private void Update()
    {
        rb.velocity = Vector3.zero;
        
        CenterilizedInCenter();
    }

    IEnumerator TurnOnCharacterController()
    {
        yield return new WaitForSeconds(2f);

        rb.isKinematic = true;
        controller.enabled = true;
        turnOffRb = false;

    }

    private void Move()
    {
        controller.Move(playerMain.MoveSpeed * Time.deltaTime * playerMain.Direction.normalized);
    }

    private void CenterilizedInCenter() 
    {
        distance = Vector3.Distance(transform.position, spawnPoint.transform.position);
        //if (!touched)
        //{
        //    centralizeVector = spawnPoint.position - transform.position;
        //    centralizeVector.Normalize();
        //    transform.Translate(centralizeVector * Time.deltaTime * centralizeSpeed);
        //}
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
        if (collision.gameObject.CompareTag("PlayerMinion"))
        {
            touched = true;
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

        if (collision.gameObject.CompareTag("PlayerMinion"))
        {
            touched = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }
    }
}
