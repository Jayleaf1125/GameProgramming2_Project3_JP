using Unity.VisualScripting;
using UnityEngine;

public class HandleCoin : MonoBehaviour
{
    private float value = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;

        if (obj.CompareTag("Player"))
        {
            Debug.Log("Coin Picked Up");
            Destroy(this.gameObject);
        }
    }

    void Rotate()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, 5));
    }
}
