using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    float speed = 5;
    float walkAcceleration = 75;
    float airAcceleration = 25;
    float groundDeceleration = 100;
    float jumpHeight = 6;

    private BoxCollider2D boxCollider;
    private Vector2 velocity;
    private bool grounded;

    public static bool gameIsPaused = false;
    public GameObject PauseUI;
    public GameObject Canvas;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused)
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0f;
                gameIsPaused = true;
            }


            else if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused)
            {
                PauseUI.SetActive(false);
                Time.timeScale = 1f;
                gameIsPaused = false;
            }
     
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (grounded)
        {
            velocity.y = 0;

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            }
        }

        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        velocity.y += Physics2D.gravity.y * Time.deltaTime;

        transform.Translate(velocity * Time.deltaTime);

        grounded = false;

        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        foreach (Collider2D hit in hits)
        {
            if (hit == boxCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
                {
                    grounded = true;
                }
            }
        }


    }
}