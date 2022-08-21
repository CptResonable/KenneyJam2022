using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {
    public static Pot instance;
    public bool isFilled = true;

    [SerializeField] private Transform tWater;

    private void Awake() {
        instance = this;
    }

    public void Fill() {
        tWater.gameObject.SetActive(true);
    }

    public void Empty() {
        tWater.gameObject.SetActive(false);
    }
}
