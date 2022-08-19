using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private Transform tCameraBase;

    private Player player;

    public void Initialize(Player player) {
        this.player = player;
    }

    private void Update() {
        tCameraBase.position = Vector3.Lerp(tCameraBase.position, player.transform.position, Time.deltaTime * 8);
    }
}
