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
    
    

    public static event Action<GameState> OnGameStateChanged;
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
            int CurrentGameTimerS = Mathf.FloorToInt(CurrentGameTimer % 60);
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
                //Make Transition
                RandomizeNextState();
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
    Loose   
}

public enum GameList
{
    Labyrinth,
    Rope,
    Bonneteau,
    ImageMalus,
    EndOfList
}
