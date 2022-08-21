using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {
    public static Pot instance;
    public bool isFilled = true;

    [SerializeField] private Transform tWater;
    [SerializeField] Transform[] potPoints;

    public int pointIndex = 0;

    private void Awake() {
        instance = this;
    }

    public void Fill() {
        tWater.gameObject.SetActive(true);
    }

    public void Empty() {
        tWater.gameObject.SetActive(false);
    }

    public void MoveToNextPoint() {
        pointIndex++;
        transform.position = potPoints[pointIndex].position;
    }
}
