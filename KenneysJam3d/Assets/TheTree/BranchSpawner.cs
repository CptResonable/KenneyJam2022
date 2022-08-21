using UnityEngine;

public class BranchSpawner : MonoBehaviour
{
    private Branch[] branches;
    private bool hasSpawnedBranches;

    // Start is called before the first frame update
    private void Start()
    {
        branches = GetComponentsInChildren<Branch>();
    }

    public void SpawnBrances()
    {
        if (!hasSpawnedBranches)
            foreach (Branch branch in branches)
                branch.Spawn();
    }
}