using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnInstance;
    public void Spawn()
    {
        var branch = Instantiate(spawnInstance, transform.position, transform.rotation);
        branch.transform.parent= gameObject.transform;
        branch.GetComponent<Grow>().StartGrowing();
    }
}
