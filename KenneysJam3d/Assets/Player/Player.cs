using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public PlayerInput input;
    public PlayerMovement playerMovement;
    public CameraController cameraController;

    private void Awake() {
        input = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        cameraController = GetComponent<CameraController>();

        playerMovement.Initialize(this);
        cameraController.Initialize(this);
    }
}
