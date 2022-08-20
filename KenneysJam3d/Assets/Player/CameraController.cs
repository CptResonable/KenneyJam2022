using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private Transform tCameraBase;
    [SerializeField] private Transform tCamera;
    [SerializeField] private float cameraDistance;
    [SerializeField] LayerMask layerMask;

    private Player player;

    public void Initialize(Player player) {
        this.player = player;
    }

    private void Update() {
        tCameraBase.position = Vector3.Lerp(tCameraBase.position, player.transform.position, Time.deltaTime * 8);
        tCameraBase.localRotation = Quaternion.Euler(player.input.pitch, player.input.yaw, 0);

        RaycastHit hit;
        if (Physics.Raycast(tCameraBase.position, -tCameraBase.forward, out hit, cameraDistance, layerMask))
            tCamera.localPosition = new Vector3(0, 0, -hit.distance);
        else
            tCamera.localPosition = new Vector3(0, 0, -cameraDistance);
    }
}
