using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float movementSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private LayerMask platformLayerMask;

    private Vector3 playerVelocity;
    private float jumpHeight = 1.0f;
    private float gravityValue = -16;// -9.81f;

    private CharacterController characterController;
    private Player player;

    private Vector3 moveVector = Vector3.zero;
    
    private Vector3 lastPos = Vector3.zero;

    private Rigidbody groundRb;
    private bool onRb  = false;

    private void Awake() {
        lastPos = transform.position;
        characterController = GetComponent<CharacterController>();
    }

    public void Initialize(Player player) {
        this.player = player;
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit) {
    //    if (hit.rigidbody != null) {
    //        groundRb = hit.rigidbody;
    //        onRb = true;
    //    }
    //}

    void Update() {
        isGrounded = characterController.isGrounded;

        RaycastHit hit;
        if (Physics.SphereCast(transform.position + Vector3.up, 0.25f, Vector3.down, out hit, platformLayerMask) && hit.rigidbody != null) {
            groundRb = hit.rigidbody;
            onRb = true;
        }
        else {
            groundRb = null;
            onRb = false;
        }

        // Set rotation
        transform.localRotation = Quaternion.Euler(0, player.input.yaw, 0);

        // Stop movement when grounded
        if (isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
        }

        // Jump!
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // Add gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Calculate move vector
        moveVector = new Vector3(characterController.velocity.x, 0, characterController.velocity.z);
        moveVector = Vector3.Lerp(moveVector, transform.TransformVector(player.input.inputVector) * movementSpeed, acceleration * Time.deltaTime); // Lerp towards target direction
        //moveVector = Vector3.zero;

        // Apply movement
        characterController.Move(playerVelocity * Time.deltaTime + moveVector * Time.deltaTime);

        isGrounded = characterController.isGrounded;

        // Move with platform
        if (onRb && isGrounded)
            transform.Translate(groundRb.velocity * Time.deltaTime, Space.World);       
    }

    //void Update() {

    //    groundedPlayer = characterController.isGrounded;

    //    // Set rotation
    //    transform.localRotation = Quaternion.Euler(0, player.input.yaw, 0);

    //    // Stop movement when grounded
    //    if (groundedPlayer && playerVelocity.y < 0) {
    //        playerVelocity.y = 0f;
    //    }

    //    // Jump!
    //    if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer) {
    //        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    //    }

    //    // Add gravity
    //    playerVelocity.y += gravityValue * Time.deltaTime;

    //    // Calculate move vector
    //    moveVector = new Vector3(characterController.velocity.x, 0, characterController.velocity.z);
    //    moveVector = Vector3.Lerp(moveVector, transform.TransformVector(player.input.inputVector) * movementSpeed, acceleration * Time.deltaTime); // Lerp towards target direction

    //    Debug.Log(onRb);
    //    Vector3 platformMovement = Vector3.zero;
    //    if (onRb) {
    //        platformMovement = groundRb.velocity;
    //        Debug.Log(groundRb.velocity.magnitude);
    //    }

    //    // Apply movement
    //    characterController.SimpleMove(playerVelocity + moveVector + (platformMovement * 0.035f));
    //}

}
