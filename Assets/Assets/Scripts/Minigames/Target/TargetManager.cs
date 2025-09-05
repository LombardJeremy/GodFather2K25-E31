using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;


public class TargetManager : MonoBehaviour
{
    private Vector2 mousePos;
    [SerializeField] private LayerMask clickableLayers;
    [SerializeField] private GameObject[] targets;
    [SerializeField] UnityEvent OnClick;
    private int pointCounter = 0;
    private bool asWin = false;


    private void Start()
    {
        startGame();          
    }

    void Update()
    {
        if (!asWin)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, float.PositiveInfinity, clickableLayers);

                if (hit)
                {
                    Debug.Log("toucher");
                    OnClick.Invoke();
                    hit.collider.gameObject.SetActive(false);
                    pointCounter += 1;
                }
            }

            if (pointCounter >= targets.Length)
            {
                Debug.Log("you win");
                asWin = true;
                GameManager.Instance.UpdateGameState(GameState.Win);
            }
        }
    }

    public void startGame()
    {
        pointCounter = 0;
        foreach (var target in targets)
        {
            target.gameObject.SetActive(true);
            target.transform.position = new Vector3 ( Random.Range(-6f,6f), Random.Range(-4f, 4f), 0);
        }
    }
}
