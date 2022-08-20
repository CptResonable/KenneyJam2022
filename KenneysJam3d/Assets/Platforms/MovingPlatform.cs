using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float stopDuration;
    [SerializeField] private Transform[] tArgetPositions;
    [SerializeField] private AnimationCurve distanceToSpeed;

    [SerializeField] private int fromIndex = 0;
    [SerializeField] private int targetIndex = 0;
    private float travelDistance;
    private float distanceTraveled;

    Rigidbody rb;


    private void Awake() {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MoveToNextTarget());
    }

    private IEnumerator MoveToNextTarget() {
        fromIndex = targetIndex;
        targetIndex = (fromIndex + 1) % tArgetPositions.Length;
        travelDistance = Vector3.Distance(tArgetPositions[fromIndex].position, tArgetPositions[targetIndex].position);
        distanceTraveled = 0;

        Vector3 travelVector = (tArgetPositions[targetIndex].position - tArgetPositions[fromIndex].position).normalized;

        while (travelDistance - distanceTraveled > 0.05f) {
            distanceTraveled = Vector3.Distance(tArgetPositions[fromIndex].position, transform.position);
            //rb.velocity = travelVector * moveSpeed;
            //transform.Translate(travelVector * moveSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
            rb.MovePosition(transform.position + travelVector * moveSpeed * Time.deltaTime);
        }

        TargetReached();
    }

    private void FixedUpdate() {
        
    }

    private void TargetReached() {
        StartCoroutine(MoveToNextTarget());
    }
}
