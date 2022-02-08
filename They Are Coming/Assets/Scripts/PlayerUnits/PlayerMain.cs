using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerMain : MonoBehaviour
{
    public static PlayerMain Instance;
    [SerializeField] private GameObject minionPrefab;
    [SerializeField] private GameObject spawnPosition;
    [SerializeField] private Weapon weapon;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sideSpeed;

    private CharacterController controller;
    private PlayerInput inputActions;
    private Vector3 velocity;
    private Vector3 sideDirection;
    private bool hasTouchedRightWall;
    private bool hasTouchedLeftWall;
    private int minions;

    public GameObject SpawnPosition { get => spawnPosition; set => spawnPosition = value; }
    public int Minions { get => minions; set => minions = value; }
    public bool HasTouchedRightWall { get => hasTouchedRightWall; set => hasTouchedRightWall = value; }
    public bool HasTouchedLeftWall { get => hasTouchedLeftWall; set => hasTouchedLeftWall = value; }
    public Weapon Weapon { get => weapon; set => weapon = value; }

    private void Start()
    {
        InitializeSingleton();
        InitializeVariables(); 
    }
    public void OnDisable()
    {
        inputActions.Disable();
    }

    private void InitializeSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void InitializeVariables()
    {
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
    private void GenerateFirstMinion()
    {
        Instantiate(minionPrefab, spawnPosition.transform.position, Quaternion.identity, transform);
    }

    private void Move()
    {
        controller.Move(moveSpeed * Time.deltaTime * velocity);
    }

    public void GenerateNewMinions(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector2 randomRange = Random.insideUnitCircle;
            Vector3 randomPosition = new Vector3(spawnPosition.transform.position.x + randomRange.x,
                spawnPosition.transform.position.y,
                spawnPosition.transform.position.z + randomRange.y);
            Instantiate(minionPrefab, randomPosition, Quaternion.identity, transform);
        }
    }

    public Vector3 RandomPosition(Vector3 center, float radius)
    {
        Vector3 position;
        position.x = center.x + Random.Range(-radius, radius);
        position.y = center.y;
        position.z = center.z + Random.Range(-radius, radius);
        return position;
    }

    private void MoveSideways()
    {
        Vector2 movementInput = inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0f, 0f);
        if (move != Vector3.zero)
        {
            if (move.x > 0)
            {
                if (hasTouchedRightWall)
                {
                    return;
                }
                sideDirection = Vector3.right;
            }
            else if (move.x < 0)
            {
                if (hasTouchedLeftWall)
                {
                    return;
                }
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
