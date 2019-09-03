using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ElevatingPlatforms : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;

    [SerializeField] float movementSpeed = 1.0f;

    [SerializeField] float minHeight = -1.0f;
    [SerializeField] float maxHeight = 1.0f;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
}
