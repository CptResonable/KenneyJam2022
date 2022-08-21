using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public PlayerInput input;
    public PlayerMovement playerMovement;
    public CameraController cameraController;

    //[SerializeField] private Pot pot;
    [SerializeField] private Transform tCarryPoint;
    [SerializeField] private Transform tBowBone;
    [SerializeField] private AnimationCurve bowCurve;
    private bool carryingPot = false;

    private void Awake() {
        input = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        cameraController = GetComponent<CameraController>();

        playerMovement.Initialize(this);
        cameraController.Initialize(this);
    }

    private void Update() {
        if (!carryingPot) {
            if (Vector3.Distance(transform.position, Pot.instance.transform.position) < 2) {
                if (Input.GetKeyDown(KeyCode.E)) {
                    Pot.instance.transform.parent = tCarryPoint;
                    Pot.instance.transform.localPosition = Vector3.zero;
                    carryingPot = true;
                }
            }
        }
        else if (Vector3.Distance(Tree.instance.growPoints[Tree.instance.level].position, transform.position) < 4) {
            if (Input.GetKeyDown(KeyCode.E)) {
                StartCoroutine(BowCorutine());
                carryingPot = false;
            }
        }

    }

    private IEnumerator BowCorutine() {
        float f = 0;

        while (f < 1) {
            f += Time.deltaTime;
            tBowBone.localRotation = Quaternion.Euler(0, 80 * bowCurve.Evaluate(f), 0);
            yield return null;
        }

        Pot.instance.MoveToNextPoint();
    }
}
