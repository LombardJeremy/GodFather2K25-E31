using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class BonneteauManager : MonoBehaviour
{
    
    private Vector2 mousePos;
    public bool IsClicked = false;
    [SerializeField] private LayerMask movableLayers;
    [SerializeField] UnityEvent OnClick;

    [SerializeField] private Vector3[] cupOriginPos = new Vector3[3];
    [SerializeField] private Vector3[] cupTempPos = new Vector3[3];
    
    public GameObject[] arrayOfCups;
    private bool isShuffling = true;

    private bool asWin = false;

    [SerializeField] private float timeBetweenCup;

    public GameObject shellToDisable;
    public float time = 0f;
    void Start()
    {
        for (int i = 0; i < cupOriginPos.Length; i++)
        {
            cupOriginPos[i] = arrayOfCups[i].transform.position;
        }
        StartCoroutine(StartingSequence());
    }

    private void Update()
    {
        if (!isShuffling && !asWin)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {

                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, float.PositiveInfinity, movableLayers);

                if (hit)
                {
                    IsClicked = true;
		            OnClick.Invoke();
                    Debug.Log("Win");
                    asWin = true;
                    GameManager.Instance.UpdateGameState(GameState.Win);
                    return;
                }
            }
            else
            {
                IsClicked = false;
            }
        }

        if (isShuffling)
        {
            time += Time.deltaTime;
            for (int i = 0; i < arrayOfCups.Length; i++)
            {
                arrayOfCups[i].transform.position = Vector3.Lerp(cupOriginPos[i], cupTempPos[i] , time/timeBetweenCup);
            }
        }
    }

    public void GenerateCupPosition()
    {
        for (int i = 0; i < arrayOfCups.Length; i++)
        {
            cupTempPos[i] = arrayOfCups[i].transform.position;
        }
        for (int i = 0; i < arrayOfCups.Length; i++)
        {
            GameObject tmp = arrayOfCups[i];
            int randomizeIdOfPos = Random.Range(0, arrayOfCups.Length);
            arrayOfCups[i] = arrayOfCups[randomizeIdOfPos];
            arrayOfCups[randomizeIdOfPos] = tmp;
        }
        Debug.Log("Generated");
    }

    private IEnumerator TimerForCupPosition()
    {
        int count = 0;
        while (isShuffling)
        {
            count += 1;
            time = 0;
            GenerateCupPosition();
            yield return new WaitForSeconds(timeBetweenCup);
            for (int i = 0; i < arrayOfCups.Length; i++)
            {
                cupOriginPos[i] = arrayOfCups[i].transform.position;
            }
            if (count == 5) isShuffling = false;
        }
        yield return null;
    }

    private IEnumerator StartingSequence()
    {
        if (shellToDisable)
        {
            shellToDisable.SetActive(false);
        }
        yield return new WaitForSeconds(1);
        isShuffling = true;
        if (shellToDisable)
        {
            shellToDisable.SetActive(true);
        }
        StartCoroutine(TimerForCupPosition());
    }
}
