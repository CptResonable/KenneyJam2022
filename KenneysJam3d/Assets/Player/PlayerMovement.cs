using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float movementSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Vector3 velocity;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float jumpHeight = 1.0f;
    private float gravityValue = -16;// -9.81f;

    private CharacterController characterController;
    private Player player;

    private Vector3 moveVector = Vector3.zero;
    
    private Vector3 lastPos = Vector3.zero;

    private void Awake() {
        lastPos = transform.position;
        characterController = GetComponent<CharacterController>();
    }

    public void Initialize(Player player) {
        this.player = player;
    }

    void Update() {

        // Set rotation
        transform.localRotation = Quaternion.Euler(0, player.input.yaw, 0);

        // Stop movement when grounded
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
        }

        // Jump!
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer) {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // Add gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Calculate move vector
        moveVector = new Vector3(characterController.velocity.x, 0, characterController.velocity.z);
        moveVector = Vector3.Lerp(moveVector, transform.TransformVector(player.input.inputVector) * movementSpeed, acceleration * Time.deltaTime); // Lerp towards target direction

        // Apply movement
        characterController.Move(playerVelocity * Time.deltaTime + moveVector * Time.deltaTime);
    }

    private void FixedUpdate() {
        velocity = (transform.position - lastPos) / Time.deltaTime;
        lastPos = transform.position;
        //Debug.Log(velocity.magnitude);
    }
}
