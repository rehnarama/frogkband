using UnityEngine;

public class Note : MonoBehaviour
{
    public float Speed;
    public float Time;
    public Vector3 TargetPosition;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void UpdateTime(float Elapsed)
    {
        float delta = Time - Elapsed;
        float y = delta * Speed + TargetPosition.y;

        rb.MovePosition(
            new Vector3(TargetPosition.x, y, TargetPosition.z)
        );
    }
}
