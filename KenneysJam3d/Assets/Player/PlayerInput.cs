using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public Vector3 inputVector;

    public float yaw;
    public float pitch;

    private void Update() {
        Vector3 newInputVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            newInputVector.z += 1;
        if (Input.GetKey(KeyCode.S))
            newInputVector.z -= 1;
        if (Input.GetKey(KeyCode.A))
            newInputVector.x -= 1;
        if (Input.GetKey(KeyCode.D))
            newInputVector.x += 1;

        newInputVector.Normalize();
        inputVector = newInputVector;

        yaw += Input.GetAxis("Mouse X") * Settings.mouseSenstivity;
        pitch -= Input.GetAxis("Mouse Y") * Settings.mouseSenstivity;
        pitch = Mathf.Clamp(pitch, -89f, 89f);
    }
}
