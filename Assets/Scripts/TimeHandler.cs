using UnityEngine;

public class TimeHandler : ITickable
{
    private readonly float levelDuration;
    
    private float time;
    private bool isFinished => time >= levelDuration;

    public TimeHandler(float levelDuration)
    {
        this.levelDuration = levelDuration;
        
        time = 0f;
    }

    public void Tick()
    {
        if (isFinished)
            return;

        time += Time.deltaTime;
    }
}