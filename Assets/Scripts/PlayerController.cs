using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _laneChangeSpeed = 10f;

    private InputHandler inputHandler;
    private LaneController laneController;

    private int currentLane;
    private Vector3 targetPosition;
    
    public void Initialize(InputHandler inputHandler, LaneController laneController)
    {
        this.inputHandler = inputHandler;
        this.laneController = laneController;

        targetPosition = transform.position;

        currentLane = 2; //от количество считать
        
        this.inputHandler.OnMove += Move;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            _laneChangeSpeed * Time.deltaTime);
    }

    private void Move(int direction)
    {
        currentLane = laneController.Clamp(currentLane - direction);
        targetPosition.x = laneController.GetLanePosition(currentLane).x;
    }

    private void OnDestroy()
    {
        inputHandler.OnMove -= Move;
    }
}