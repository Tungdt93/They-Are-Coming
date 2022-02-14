using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour, ISubcribers
{
    [SerializeField] private float moveSpeed;

    private GameManager gameManager;
    private Vector3 direction;
    private float defaultSpeed;
    private bool gameStarted;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    private void Start()
    {
        SubscribeEvent();
    }

    private void OnEnable()
    {
        //gameManager = GameManager.Instance;
        InitializeVariables();

        //SubscribeEvent();
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStarted -= GameStarted;
    }

    private void InitializeVariables()
    {

        defaultSpeed = 10f;
        direction = Vector3.back;
        gameStarted = false;
    }

    private void Update()
    {
        if (!gameStarted)
        {
            return;
        }
        Move();
    }

    private void Move()
    {
        transform.Translate(moveSpeed * Time.deltaTime * direction);
    }

    public void SubscribeEvent()
    {
        GameManager.Instance.OnGameStarted += GameStarted;
    }

    public void UnsubscribeEvent()
    {
        
    }

    public void GameStarted(int obj)
    {
        gameStarted = true;
    }
}
