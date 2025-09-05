using System.Collections;
using UnityEngine;

public class TransitionSceneManager : MonoBehaviour
{
    public float timeForTransition;
    void Start()
    {
        StartCoroutine(TimerForNextGame());
    }

    IEnumerator TimerForNextGame()
    {
        //Animation for number of life
        yield return new WaitForSeconds(timeForTransition);
        GameManager.Instance.UpdateGameState(GameState.Win);
    }
}
