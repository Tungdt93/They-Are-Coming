using UnityEngine;
using UnityEngine.AI;

public class EnemyMinion : MonoBehaviour, IDamageable, ISubcribers
{
    [SerializeField] private EnemyInfomation enemyInfo;
    [SerializeField] private Transform target;
    [SerializeField] private float currentHealth;

    private Rigidbody rb;
    private CharacterController controller;
    private PlayerMain playerMain;
    private Vector3 direction;
    private float moveSpeed;
    private bool isChasing;

    private void OnEnable()
    {
        InitializeVariables();     
        InstantiateModel();
        SubscribeEvent();
    }

    private void OnDisable()
    {
        UnsubscribeEvent();
    }

    private void Update()
    {
        CheckPlayerInRange();
        Move();
    }

    public void SubscribeEvent()
    {
        playerMain.OnOutOfMinions += MinionStopMoving;
    }

    public void UnsubscribeEvent()
    {
        playerMain.OnOutOfMinions -= MinionStopMoving;
    }

    private void MinionStopMoving()
    {
        moveSpeed = 0f;
    }

    private void InitializeVariables()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        playerMain = PlayerMain.Instance;
        moveSpeed = enemyInfo.moveSpeed;
        direction = Vector3.back;
        currentHealth = enemyInfo.health;
    }

    private void InstantiateModel()
    {
        Instantiate(enemyInfo.model, this.transform);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) 
        {
            Destroy(this.gameObject);
        }
    }

    public void OnDeath()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerMinion"))
        {
            Destroy(other.gameObject);
        }
    }

    private void Move()
    {
        controller.Move(moveSpeed * Time.deltaTime * direction.normalized);
    }

    private void CheckPlayerInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, enemyInfo.radiusCheck);
        foreach (var hitCollider in hitColliders)
        {  
            if (hitCollider.gameObject.CompareTag("PlayerMinion"))
            {
                Vector3 newDirection = new Vector3(hitCollider.gameObject.transform.position.x - transform.position.x,
                0f,
                hitCollider.gameObject.transform.position.z - transform.position.z);
                direction = newDirection;      
            }
        }
    }
}