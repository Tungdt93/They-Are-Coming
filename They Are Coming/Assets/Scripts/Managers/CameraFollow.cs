using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Vector3 direction;

    private void OnEnable()
    {
        direction = Vector3.back;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(moveSpeed * Time.deltaTime * direction);
    }
}
