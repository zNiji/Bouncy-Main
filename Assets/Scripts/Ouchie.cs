using UnityEngine;

public class Ouchie : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if(collision.gameObject.GetComponent<BallController>() != null)
            {
                collision.gameObject.GetComponent<BallController>().ResetPosition();
            }
        }
    }
}
