using UnityEngine;

public class MazeCollision : MonoBehaviour
{

    public bool isEnd = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isEnd)
            {
                GameManager.Instance.UpdateGameState(GameState.Win);
            }
            else
            {
                GameManager.Instance.UpdateGameState(GameState.Loose);
            }
        }
    }
}
