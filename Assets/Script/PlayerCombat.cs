using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] GameObject _stompParticlesPrefab;
    public Transform stompParticlesPos;
    public float propelForce;

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
                _rb.AddForce(new Vector3(0, propelForce, 0), ForceMode.Impulse);
                StartCoroutine(SpawnStompParticles());
            }
        }
    }

    IEnumerator SpawnStompParticles()
    {
        var par = Instantiate(_stompParticlesPrefab, stompParticlesPos.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(par);
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(stompParticlesPos.position, .5f);
    }
}
