using UnityEditor;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] GameObject _stompParticlesPrefab;
    public Transform stompParticlesPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;

        if (obj.CompareTag("Enemy"))
        {
            var enemyHead = obj.transform.GetChild(0);

            if (enemyHead != null && enemyHead.CompareTag("Enemy_Head")) 
            {
                _rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
                Instantiate(_stompParticlesPrefab, stompParticlesPos.position, Quaternion.identity);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(stompParticlesPos.position, .5f);
    }
}
