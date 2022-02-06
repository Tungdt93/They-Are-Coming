
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime);
    }
}
