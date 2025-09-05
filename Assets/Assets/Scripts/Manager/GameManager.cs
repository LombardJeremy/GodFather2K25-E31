using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentState;
    public GameList CurrentGame;

    public float CurrentGameTimer;
    public float GlobalGameTimer;

    [SerializeField] private int numberOfLife = 3;
    public static event Action<GameState> OnTransitionStart;

    private List<GameList> gamesDone = new List<GameList>();

    [SerializeField] public int[] minigameTimers;

    public bool isTransitionDone = false;
    public bool isInTransitionScene = false;

    public string[] dialogueTransition;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (CurrentState == GameState.Game)
        {
            CurrentGameTimer += Time.deltaTime;
            GlobalGameTimer += Time.deltaTime;
            int currentGameTimerS = Mathf.FloorToInt(CurrentGameTimer % 60);
            if (minigameTimers[(int)CurrentGame] <= currentGameTimerS)
            {
                CurrentGameTimer = 0;
                UpdateGameState(GameState.Loose);
            }
        }

        if (isTransitionDone && isInTransitionScene)
        {
            isTransitionDone = false;
            isInTransitionScene = false;
            UpdateGameState(GameState.Game);
        }

        if (isTransitionDone && !isInTransitionScene)
        {
            RandomizeNextState();
            SceneManager.LoadSceneAsync((int)GameList.EndOfList + 3); //+3 for MainMenu & MainState & EndGame && other
            isTransitionDone = false;
            isInTransitionScene = true;
        }
    }

    public void UpdateGameState(GameState newState)
    {
        CurrentState = newState;
        switch (CurrentState)
        {
            case GameState.MainMenu:
                SceneManager.LoadSceneAsync((int)GameState.MainMenu);
                CurrentGameTimer = 0;
                GlobalGameTimer = 0;
                numberOfLife = 3;
                break;
            case GameState.MainState:
                break;
            case GameState.Game:
                //Main Game
                LoadGame();
                break;
            case GameState.Win:
                //Make Transition
                isTransitionDone = false;
                OnTransitionStart?.Invoke(newState);
                break;
            case GameState.Loose:
                numberOfLife -= 1;
                if (numberOfLife <= 0)
                {
                    UpdateGameState(GameState.EndGame);
                    return;
                }
                //Make Transition
                isTransitionDone = false;
                OnTransitionStart?.Invoke(newState);
                break;
            case GameState.EndGame:
                SceneManager.LoadSceneAsync((int)GameState.EndGame);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        Debug.Log(newState.ToString());
    }

    public void RandomizeNextState()
    {
        if (gamesDone.Count >= (int)GameList.EndOfList)
        {
            gamesDone.Clear();
        }
        while (true)
        {
            GameList newMiniGame = (GameList)Random.Range(0, (int)GameList.EndOfList);
            if (newMiniGame != CurrentGame && !gamesDone.Contains(newMiniGame))
            {
                CurrentGame = newMiniGame;
                gamesDone.Add(CurrentGame);
                break;
            }
        }
    }
    private void LoadGame()
    {
        SceneManager.LoadSceneAsync((int)CurrentGame + 3); //+3 for MainMenu & MainState & EndGame && other
    }

    public void StartGame()
    {
        UpdateGameState(GameState.Win);
    }
}

public enum GameState
{
    MainMenu,
    MainState,
    EndGame,
    Game,
    Win,
    Loose
}

public enum GameList
{
    Labyrinth,
    Rope,
    Bonneteau,
    ImageMalus,
    TargetPractice,
    EndOfList
}
