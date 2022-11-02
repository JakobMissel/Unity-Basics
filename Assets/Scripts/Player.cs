using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Doesn't expose it to other classes by using "[SerializeField] private"
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float playerSpeedMultiplier = 1f;

    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    private int superJumpsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame - Only inputs in "Update"
    void Update()
    {
        // Check if space key is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");

    }

    // FixedUpdate is called once every physic update (100 times per second) - Applying physics
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput*playerSpeedMultiplier, rigidbodyComponent.velocity.y, 0);


       if (Physics.OverlapSphere(groundCheckTransform.position, 0.05f, playerMask).Length == 0)
        {
            return;
        }


        if (jumpKeyWasPressed)
        {
            float jumpPower = 5f;
            if (superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                superJumpsRemaining--;
            }

            rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
    }

}
