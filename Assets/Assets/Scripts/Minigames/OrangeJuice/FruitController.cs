using UnityEngine;

public class FruitController : MonoBehaviour
{
    private Vector2 mousePos;
    public bool IsDraged = false;
    [SerializeField] private LayerMask movableLayers;

    private void Start()
    {
        gameObject.transform.position = Vector3.left;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, float.PositiveInfinity, movableLayers);

            if (hit)
            {
                IsDraged = true;
            }
            else
            {
                IsDraged = false;
            }

            if (IsDraged)
            {
                hit.transform.position = mousePos;
                hit.rigidbody.linearVelocity = Vector2.zero;
            }

        }
        else
        {
            IsDraged = false;
        }
    }
}

