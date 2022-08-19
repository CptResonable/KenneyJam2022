using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public Vector3 inputVector;

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
    }
}
