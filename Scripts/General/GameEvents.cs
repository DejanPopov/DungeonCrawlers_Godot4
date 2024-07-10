using System;


public class GameEvents
{
    public static event Action onStartGame;
    public static event Action onEndGame;
    public static event Action<int> onNewEnemyCount;
    public static event Action onVictory;
    public static event Action<RewardResource> onReward;

    public static void RaiseStartGame() => onStartGame?.Invoke();
    public static void RaiseEndGame() => onEndGame?.Invoke();
    public static void RaiseNewEnemyCount(int count) => onNewEnemyCount?.Invoke(count);
    public static void RaiseVicotory() => onVictory?.Invoke();
    public static void RaiseReward(RewardResource reward) => onReward?.Invoke(reward);
}  