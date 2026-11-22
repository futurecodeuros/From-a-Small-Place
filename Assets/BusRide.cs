using UnityEngine;

public class BusRide : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float braking = 8f;

    private bool isBraking;

    public void StartBraking()
    {
        isBraking = true;
    }

    private void Update()
    {
        if (isBraking)
        {
            speed = Mathf.MoveTowards(speed, 0f, braking * Time.deltaTime);
        }

        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}