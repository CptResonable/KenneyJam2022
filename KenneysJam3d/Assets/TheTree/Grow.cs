using UnityEngine;

public class Grow : MonoBehaviour
{
    public bool hasGrown = false;

    private Vector3 endScale = new Vector3(10, 10, 10);
    private Vector3 startScale;
    private float duration = 5f;
    private float elapsedTime;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        GrowTree(gameObject);
    }

    private void Addbranches()
    {
        var test = Instantiate(gameObject, new Vector3(transform.position.x + 2, transform.position.y + 2, transform.position.z + 2), Quaternion.identity);
    }

    private void GrowTree(GameObject gameObject)
    {
        if (Input.GetKey(KeyCode.G) && !hasGrown)
        {
            hasGrown = true;
        }
        if (hasGrown)
        {
            elapsedTime += Time.deltaTime;
            float complete = elapsedTime / duration;

            transform.localScale = Vector3.Lerp(startScale, endScale, complete);

            if (elapsedTime > duration)
            {
                startScale = endScale;
                endScale *= 10;
                elapsedTime = 0;
                hasGrown = false;
                Addbranches();
            }
        }
    }
}