using System;


public class GameEvents
{
    public static Action onStartGame;
    public static void RaiseStartGame() => onStartGame?.Invoke();
}