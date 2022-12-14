using UnityEngine;

public class Tree : MonoBehaviour
{
    public static Tree instance;

    public Transform[] growPoints;

    [SerializeField]
    private BranchSpawner[] branchSpawners;

    public int level = 0;

    private Grow grow;

    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        grow = GetComponent<Grow>();
        grow.doneGrowing += SpawnTreeBranch;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            Growing();
    }

    public void Growing()
    {
        grow.StartGrowing();
    }

    private void SpawnTreeBranch()
    {
        if (level < branchSpawners.Length)
        {
            branchSpawners[level].SpawnBrances();
            level++;
        }
        else
        {
            Debug.LogWarning("Try to level then reached max level");
        }
    }
}