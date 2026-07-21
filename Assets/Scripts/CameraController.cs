using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private PlayerController player;

    public void Initialize(PlayerController player)
    {
        this.player = player;
    }

    private void LateUpdate()
    {
        if (player == null)
            return;

        transform.position = player.transform.position + _offset;
        transform.LookAt(player.transform);
    }
}