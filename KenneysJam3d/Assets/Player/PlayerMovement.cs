using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float movementSpeed;
    [SerializeField] private float acceleration;

    private CharacterController characterController;
    private Player player;

    private Vector3 moveVector = Vector3.zero;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    public void Initialize(Player player) {
        this.player = player;
    }

    private void Update() {
        transform.localRotation = Quaternion.Euler(0, player.input.yaw, 0);
        moveVector = Vector3.Lerp(moveVector, transform.TransformVector(player.input.inputVector), acceleration * Time.deltaTime);
        characterController.Move(moveVector * movementSpeed * Time.deltaTime);
        //characterController.SimpleMove(moveVector * movementSpeed);
        //characterController.Move(moveVector * movementSpeed);
    }
}
