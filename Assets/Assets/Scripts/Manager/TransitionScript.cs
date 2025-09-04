using System;
using System.Collections;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    [SerializeField] private Animator transition;
    
    public float transitionTime = 1f;

    private void Awake()
    {
        GameManager.OnTransitionStart += TransitionStarting;
    }

    private void OnDestroy()
    {
        GameManager.OnTransitionStart -= TransitionStarting;
    }

    private void TransitionStarting(GameState obj)
    {
        StartCoroutine(Transition());
    }
    IEnumerator Transition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        GameManager.Instance.isTransitionDone = true;
    }
}
