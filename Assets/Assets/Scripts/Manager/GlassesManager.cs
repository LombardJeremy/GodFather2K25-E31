using UnityEngine;

public class GlassesManager : MonoBehaviour
{
    private int currentGlass;
    [SerializeField] private float changeDuration = 5;
    private float time = 0;

    private bool GoUp = true;

    public Transform glassTransform;
    public Transform UpPosition;
    public Transform DownPosition;


    private void Start()
    {
        time = 1;
    }

    void Update()
    {
        float Ratio = 1/changeDuration;
        time += Time.deltaTime * Ratio;

        if (Input.GetMouseButtonDown(0))
        {
            GlassDown();
        }
        if (Input.GetMouseButtonUp(1))
        {
            GlassUp();
        }


        if (time > 1) time = 1;
        float t = -(Mathf.Cos(Mathf.PI * time) - 1 )/ 2;

        Vector3 endPos = glassTransform.transform.position;

        if(GoUp)
            endPos.y = Mathf.Lerp(DownPosition.transform.position.y, UpPosition.transform.position.y, t);
        else
            endPos.y = Mathf.Lerp(UpPosition.transform.position.y, DownPosition.transform.position.y, t);

        Debug.Log(endPos.y);
        glassTransform.position = endPos;
    }

    public void GlassDown()
    {
        currentGlass = Random.Range(0, 1);
        GoUp = false;
        time = 0;
    }

    public void GlassUp()
    {
        GoUp = true;
        time = 0;
    }
}
