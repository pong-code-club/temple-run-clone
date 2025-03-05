using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentGameState;

    void Awake()
    {
        if (GameManager.Instance != null)
        {
            Destroy(this);
        }

        Instance = this;

        SetGameState(GameState.START);
    }

    void Update()
    {
        RunSimulationTick();
    }

    public void SetGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.NONE:
                break;
            case GameState.START:
                SetGameStateStart();
                break;
            case GameState.CONTINUE:
                SetGameStateContinue();

                break;
            case GameState.END:
                SetGameStateEnd();
                break;
        }
    }

    void RunSimulationTick()
    {
        switch (CurrentGameState)
        {
            case GameState.NONE:
                break;
            case GameState.START:
                RunGameStateStart();
                break;
            case GameState.CONTINUE:
                RunGameStateContinue();
                break;
            case GameState.END:
                RunGameStateEnd();
                break;
        }
    }

    void SetGameStateStart()
    {
        CurrentGameState = GameState.START;
    }

    void SetGameStateContinue()
    {
        CurrentGameState = GameState.CONTINUE;
    }

    void SetGameStateEnd()
    {
        CurrentGameState = GameState.END;
    }

    void RunGameStateStart()
    {

    }

    void RunGameStateContinue()
    {

    }

    void RunGameStateEnd()
    {

    }
}
