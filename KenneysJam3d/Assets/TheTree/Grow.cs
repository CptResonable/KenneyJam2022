using UnityEngine;

public class Grow : MonoBehaviour
{
    [SerializeField]
    public bool isGrowing = false;
    [SerializeField]
    private Vector3 startScale = new Vector3(0, 0, 0);
    [SerializeField]
    private Vector3 endScale = new Vector3(10, 10, 10);

    //Används för att medela trädet att växtfasen
    //är klar och trädet kan spawna grenarna
    public delegate void DoneGrowing();
    public DoneGrowing doneGrowing;

    private float duration = 2f;
    private float elapsedTime;

    private void Update()
    {
        Growing();
    }

    public void StartGrowing()
    {
        isGrowing = true;
    }

    private void Growing()
    {
        if (isGrowing)
        {
            float complete = elapsedTime / duration;
            elapsedTime += Time.deltaTime;

            transform.localScale = Vector3.Lerp(startScale, endScale, complete);

            if (elapsedTime > duration)
            {
                startScale = endScale;
                endScale *= 10;
                elapsedTime = 0;
                isGrowing = false;

                doneGrowing?.Invoke();
            }
        }
    }
}