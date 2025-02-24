using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //Global Variables
    [SerializeField]
    private bool MyBool = false;

    float MaxSize = 10f;
    float MinSize = 0.1f;
    bool Sizing = false;    

    private void Awake()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


        gameObject.transform.Rotate(new Vector3(-10, 0, 0));
        if (Input.GetKey(KeyCode.Space))
        if (MyBool)
        {
            Debug.Log("Hi");
        }
    }
}
