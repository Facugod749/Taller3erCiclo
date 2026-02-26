using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config Movement")]
    public float SpeedMovement = 5f;

    [Header("Config Jump")]
    public float JumpForce = 4.5f;
    public Transform groundCheck;
    public float RadioGround = 0.2f;
    public LayerMask LayerPiso;

    private Rigidbody2D rb;
    private float horizontalMovement;
    private bool EsPiso;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        EsPiso = Physics2D.OverlapCircle(groundCheck.position, RadioGround, LayerPiso);
        if (EsPiso && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
        
    }
    private void FixedUpdate()
    {
        // Usar linearVelocity en lugar de velocity (obsoleto)
        rb.linearVelocity = new Vector2(horizontalMovement * SpeedMovement, rb.linearVelocity.y);
    }
}
