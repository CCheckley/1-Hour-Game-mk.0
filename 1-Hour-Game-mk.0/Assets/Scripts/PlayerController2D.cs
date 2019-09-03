using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;

    [SerializeField] float movementSpeed = 100.0f;
    [SerializeField] float jumpForce = 100.0f;

    [SerializeField] LayerMask floorLayer;
    [SerializeField] LayerMask killLayer;
    [SerializeField] LayerMask winLayer;

    [SerializeField] GameManager gameManager;

    [SerializeField] GameObject winScreenUI;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        gameManager.ResetLevel(this);

        winScreenUI.SetActive(false);
    }

    void Update()
    {
        if (isDead())
        {
            gameManager.ResetLevel(this);
            return;
        }

        if (isWinner())
        {
            winScreenUI.SetActive(true);
            if (Input.GetKey(KeyCode.R))
            {
                winScreenUI.SetActive(false);
                gameManager.ResetLevel(this);
            }
            return;
        }

        float xInput = (Input.GetAxisRaw("Horizontal") * movementSpeed) * Time.deltaTime;
        float yInput = (isGrounded() && Input.GetButton("Jump")) ? jumpForce : rigidbody2D.velocity.y;

        rigidbody2D.velocity = new Vector2(xInput, yInput);
    }

    bool isGrounded()
    {
        return rigidbody2D.IsTouchingLayers(floorLayer);
    }

    bool isDead()
    {
        return rigidbody2D.IsTouchingLayers(killLayer);
    }

    bool isWinner()
    {
        return rigidbody2D.IsTouchingLayers(winLayer);
    }
}
