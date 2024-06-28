using System;


public class GameEvents
{
    public static event Action onStartGame;
    public static event Action onEndGame;
    public static void RaiseStartGame() => onStartGame?.Invoke();
    public static void RaiseEndGame() => onEndGame?.Invoke();
}