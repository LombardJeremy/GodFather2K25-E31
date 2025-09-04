using UnityEngine;

public class EndScreenTitle : MonoBehaviour
{
    public void ReturnToMenu()
    {
        GameManager.Instance.UpdateGameState(GameState.MainMenu);
    }
}
