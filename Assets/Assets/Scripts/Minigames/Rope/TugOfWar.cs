using UnityEngine;

public class TugOfWar : MonoBehaviour
{
    public bool IsPlaying = false;
    public float FranckoStrenght;
    public float PlayerStrenght;

    public Animator animator;

    [SerializeField] private GameObject RightPos;
    [SerializeField] private GameObject LeftPos;

    public float posAdvancement;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsPlaying = true;
        }

        if (IsPlaying)
        {
            gameObject.transform.position += Vector3.right * FranckoStrenght;

            if (Input.GetMouseButtonDown(0))
            {
                gameObject.transform.position += Vector3.left * PlayerStrenght;
            }
        }
        posAdvancement = (gameObject.transform.position.x - LeftPos.transform.position.x) / (RightPos.transform.position.x - LeftPos.transform.position.x);
        if(posAdvancement != null) animator.SetFloat("position", posAdvancement);
        if(gameObject.transform.position.x >= RightPos.transform.position.x)
        {
            Debug.Log("You WIN !!!");
            GameManager.Instance.UpdateGameState(GameState.Win);
        }
        if(gameObject.transform.position.x <= LeftPos.transform.position.x)
        {
            Debug.Log("You LOSE !!!");
            GameManager.Instance.UpdateGameState(GameState.Loose);
        }
    }
}
