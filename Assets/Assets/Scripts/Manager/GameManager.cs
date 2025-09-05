using System;using System.Collections;
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
    public static event Action<GameState> OnGameStateChanged;

    [SerializeField] public int[] minigameTimers;
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
    }

    public void UpdateGameState(GameState newState)
    {
        CurrentState = newState;
        switch (CurrentState)
        {
            case GameState.MainMenu:
                break;
            case GameState.MainState:
                break;
            case GameState.Game:
                //Main Game
                LoadGame();
                break;
            case GameState.Win:
                //Make Transition
                RandomizeNextState();
                break;
            case GameState.Loose:
                numberOfLife -= 1;
                if (numberOfLife == 0)
                {
                    UpdateGameState(GameState.EndGame);
                    return;
                }
                //Make Transition
                RandomizeNextState();
                break;
            case GameState.EndGame:
                //SceneManager.LoadSceneAsync();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        OnGameStateChanged?.Invoke(newState);
        Debug.Log(newState.ToString());
    }

    public void RandomizeNextState()
    {
        while (true)
        {
            GameList newMiniGame = (GameList)Random.Range(0, (int)GameList.EndOfList);
            if (newMiniGame != CurrentGame)
            {
                CurrentGame = newMiniGame;
                break;
            }
        }
        UpdateGameState(GameState.Game);
    }
    private void LoadGame()
    {
        SceneManager.LoadSceneAsync((int)CurrentGame + 2); //+2 for MainMenu & MainState
    }
}

public enum GameState
{
    MainMenu,
    MainState,
    Game,
    Win,
    Loose,
    EndGame,
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
