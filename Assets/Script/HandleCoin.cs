using Unity.VisualScripting;
using UnityEngine;

public class HandleCoin : MonoBehaviour
{
    float _rotationSpeed = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, _rotationSpeed));
    }
}
