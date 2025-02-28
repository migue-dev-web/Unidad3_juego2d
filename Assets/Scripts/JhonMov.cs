using UnityEngine;

public class JhonMov : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;

    private Animator Animator;
    private bool grounded;
    public float speed;
    public float Jumpforce;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.4f))
        {
            grounded = true;
        }
        else grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            jump();
        }
    }
    private void jump()
{
    Rigidbody2D.AddForce(Vector2.up * Jumpforce);
}
    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = new Vector2(Horizontal, Rigidbody2D.linearVelocity.y * speed); 
    }
}
