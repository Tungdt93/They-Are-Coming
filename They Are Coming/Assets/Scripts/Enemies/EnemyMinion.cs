using UnityEngine;
using UnityEngine.AI;

public class EnemyMinion : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyInfomation enemyInfo;
    [SerializeField] private Transform target;
    [SerializeField] private float currentHealth;

    private Rigidbody rb;
    private CharacterController controller;
    private Vector3 direction;

    private bool isChasing;

    private void OnEnable()
    {
        InitializeVariables();     
        InstantiateModel();
    }

    private void Update()
    {
        CheckPlayerInRange();
        Move();
    }

    private void InitializeVariables()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
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
            other.gameObject.SetActive(false);
        }
    }

    private void Move()
    {
        controller.Move(enemyInfo.moveSpeed * Time.deltaTime * direction.normalized);
        //MovePosition(transform.position + enemyInfo.moveSpeed * Time.deltaTime * direction);
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