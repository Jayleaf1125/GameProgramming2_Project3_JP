using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;
        HandlePickup(obj);
    }

    void HandlePickup(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Coin":
                HandleCoin(obj);
                break;
        }
    }

    void HandleCoin(GameObject coin)
    {
        gameManager.IncrementTotalScore();
        Destroy(coin.gameObject);
    }
    
}
