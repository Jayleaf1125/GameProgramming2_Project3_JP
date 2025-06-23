using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Properties")]
    float _currentHealth;
    [SerializeField] float _maxHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroySelf() => Destroy(this.gameObject);
}
