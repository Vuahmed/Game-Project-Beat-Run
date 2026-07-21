using UnityEngine;
using UnityEngine.Serialization;

public class LaneController : MonoBehaviour
{
    [SerializeField] private Lane[] lanes;
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        foreach (Lane lane in lanes)
        {
            lane.transform.position += Vector3.forward * (moveSpeed * Time.deltaTime);
        }
    }

    public int Clamp(int index)
    {
        return Mathf.Clamp(index, 0, lanes.Length - 1);
    }

    public Vector3 GetLanePosition(int index)
    {
        return lanes[index].transform.position;
    }
}