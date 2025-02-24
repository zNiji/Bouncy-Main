using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform ball;
    public Transform orientation;
    public Vector3 offset = new Vector3 (0f, 5f, -8.0f);
    public float smoothing = 0.1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orientation = ball.GetComponent<BallController>().orientation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (ball != null && orientation != null)
        {
            Vector3 targetPosition = ball.position + orientation.rotation * offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            transform.LookAt(ball.position);
        }
    }
}
