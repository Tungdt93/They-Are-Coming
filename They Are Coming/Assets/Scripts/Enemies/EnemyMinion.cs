using UnityEngine;
using UnityEngine.AI;

public class EnemyMinion : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyInfomation enemyInfo;

    private CharacterController controller;
    private NavMeshAgent agent;
    private Vector3 direction;

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
        controller = GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();
        direction = Vector3.back;
    }

    private void InstantiateModel()
    {
        Instantiate(enemyInfo.model, this.transform);
    }

    public void TakeDamage(int damage)
    {
        enemyInfo.health -= damage;
    }

    public void OnDeath()
    {

    }

    private void Move()
    {
        controller.Move(enemyInfo.moveSpeed * Time.deltaTime * direction);
    }

    private void CheckPlayerInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, enemyInfo.radiusCheck);
        foreach (var hitCollider in hitColliders)
        {
           
            if (hitCollider.gameObject.CompareTag("PlayerMinion"))
            {              
                agent.speed = enemyInfo.chaseSpeed;
                agent.SetDestination(hitCollider.gameObject.transform.position);
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, enemyInfo.radiusCheck);
    }
}