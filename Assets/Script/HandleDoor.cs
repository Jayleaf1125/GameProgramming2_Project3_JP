using UnityEngine;

public class HandleDoor : MonoBehaviour
{
    public GameManager gm;
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
        if(collision.gameObject.CompareTag("Player"))
        {
            if(gm.GetTotalScore() == 25)
            {
                Debug.Log("Door can be entered");
            } else
            {
                Debug.Log("Door cannot be entered");
            }
        }
    }
}
