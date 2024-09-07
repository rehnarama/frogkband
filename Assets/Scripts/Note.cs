using UnityEngine;

public class Note : MonoBehaviour
{
    public float Speed = 1.0f;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(
            rb.position + Vector3.down * Speed
        );
    }
}
