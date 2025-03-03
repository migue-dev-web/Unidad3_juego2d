using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float speed;

    private Vector2 direction;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = direction*speed;
    }

    public void SetDirection(Vector2 direccion)
    {
        direction = direccion;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
