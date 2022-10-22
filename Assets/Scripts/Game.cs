using UnityEngine;

public class Game
{
    public GameState GameState = GameState.NotPlaying;

    private static readonly Game _instance = new Game();

    public static void InitGame()
    {
        _instance.GameState = GameState.NotPlaying;
    }

    public static void StartGame()
    {
        _instance.GameState = GameState.Playing;
    }

    public static void Win()
    {
        _instance.GameState = GameState.Win;
    }

    public static void Lose()
    {
        _instance.GameState = GameState.Loose;
    }
}
