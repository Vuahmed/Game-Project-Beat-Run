using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private readonly List<ITickable> tickables = new ();
    
    private InputHandler inputHandler;
    private TimeHandler timeHandler;
    
    [SerializeField] private PlayerController playerController;
    [SerializeField] private LaneController laneController;
    [SerializeField] private CameraController cameraController;

    private void Awake()
    {
        inputHandler = new InputHandler();
        timeHandler = new TimeHandler(60f);
        tickables.Add(timeHandler);
            
        playerController.Initialize(inputHandler, laneController);
        cameraController.Initialize(playerController);
    }

    private void Update()
    {
        foreach (var tickable in tickables)
        {
            tickable.Tick();
        }
    }

    private void OnDestroy()
    {
        inputHandler.Dispose();
    }
}