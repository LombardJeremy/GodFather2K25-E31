using UnityEngine;

public class FruitController : MonoBehaviour
{
    private Vector2 mousePos;
    public bool IsDraged = false;
    private RaycastHit2D lastFruitsPickup;
    [SerializeField] private LayerMask movableLayers;

    private void Start()
    {
        gameObject.transform.position = Vector3.left;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (IsDraged)
        {
            if (lastFruitsPickup.transform) lastFruitsPickup.transform.position = mousePos;
            //lastFruitsPickup.rigidbody.linearVelocity = Vector2.zero;
        }

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, float.PositiveInfinity, movableLayers);

            if (hit)
            {
                IsDraged = true;
                lastFruitsPickup = hit;
            }
            else
            {
                IsDraged = false;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            IsDraged = false;
        }
    }
}

