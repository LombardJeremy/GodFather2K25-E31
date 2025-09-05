using System.Collections;
using UnityEngine;

public class TransitionSceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TimerForNextGame());
    }

    IEnumerator TimerForNextGame()
    {
        //Animation for number of life
        yield return new WaitForSeconds(5);
        GameManager.Instance.UpdateGameState(GameState.Win);
    }
}
