using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMain : PlayerUnit
{
    public static PlayerMain Instance;

    [SerializeField] private float sideSpeed;
    [SerializeField] private float defaultSideSpeed;

    private PlayerInput inputActions;
    private bool hasTouchedRightWall;
    private bool hasTouchedLeftWall;
    private int minions;

    public GameObject SpawnPosition { get => spawnPosition; set => spawnPosition = value; }
    public int Minions { get => minions; set => minions = value; }
    public bool HasTouchedRightWall { get => hasTouchedRightWall; set => hasTouchedRightWall = value; }
    public bool HasTouchedLeftWall { get => hasTouchedLeftWall; set => hasTouchedLeftWall = value; }

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        InitializeVariables(); 
    }

    public void OnDisable()
    {
        inputActions.Disable();
    }

    private void InitializeVariables()
    {
        sideSpeed = defaultSideSpeed = unitInfo.sideSpeed;
        hasTouchedRightWall = false;
        hasTouchedLeftWall = false;
        velocity = Vector3.back;
        inputActions = new PlayerInput();
        inputActions.Enable();
        controller = GetComponent<CharacterController>();
        GenerateFirstMinion();
        minions = transform.childCount;
    }

    private void Update()
    {
        Move(); 
        MoveSideways();
    }

    public void Move()
    {
        controller.Move(unitInfo.moveSpeed * Time.deltaTime * velocity);
    }

    public void MoveSideways()
    {
        Vector2 movementInput = inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0f, 0f);
        if (move != Vector3.zero)
        {
            if (move.x > 0)
            {
                if (hasTouchedRightWall)
                {
                    sideSpeed = 0;
                    return;
                }
                sideSpeed = defaultSideSpeed;
                sideDirection = Vector3.right;
            }
            else if (move.x < 0)
            {
                if (hasTouchedLeftWall)
                {
                    sideSpeed = 0;
                    return;
                }
                sideSpeed = defaultSideSpeed;
                sideDirection = Vector3.left;
            }
        }
        else
        {
            sideDirection = Vector3.zero;
        }
        controller.Move(sideSpeed * Time.deltaTime * sideDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        #region PowerUp
        if (other.CompareTag("PowerUp"))
        {
            if (other.TryGetComponent(out PowerUp powerUp))
            {
                if (powerUp.Addition)
                {
                    int amount = powerUp.Value;
                    GenerateNewMinions(amount);
                }
                else
                {

                }
                powerUp.InvokeEvent();
            }
        }
        #endregion

        #region Weapon
        if (other.CompareTag("Weapon"))
        {
            if (other.TryGetComponent(out Weapon weapon))
            {
                
            }
        }
        #endregion

    }
}
