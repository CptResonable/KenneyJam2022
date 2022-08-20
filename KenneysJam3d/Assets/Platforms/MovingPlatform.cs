using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stopDuration;
    [SerializeField] private Transform[] tArgetPositions;
    [SerializeField] private AnimationCurve distanceToSpeed;

    [SerializeField] private int fromIndex = 0;
    [SerializeField] private int targetIndex = 0;
    private float travelDistance;
    private float distanceTraveled;

    private Rigidbody rb;


    private void Awake() {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MoveToNextTarget());
    }

    private IEnumerator MoveToNextTarget() {
        yield return new WaitForSeconds(stopDuration);

        fromIndex = targetIndex;
        targetIndex = (fromIndex + 1) % tArgetPositions.Length;
        travelDistance = Vector3.Distance(tArgetPositions[fromIndex].position, tArgetPositions[targetIndex].position);
        distanceTraveled = 0;

        Vector3 travelVector = (tArgetPositions[targetIndex].position - tArgetPositions[fromIndex].position).normalized;

        while (travelDistance - distanceTraveled > 0.05f) {
            distanceTraveled = Vector3.Distance(tArgetPositions[fromIndex].position, transform.position);
            yield return new WaitForFixedUpdate();

            float speedMod = distanceToSpeed.Evaluate(distanceTraveled / travelDistance);
            rb.MovePosition(transform.position + travelVector * moveSpeed * speedMod * Time.deltaTime);     
        }

        TargetReached();
    }

    private void TargetReached() {
        StartCoroutine(MoveToNextTarget());
    }
}
