using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HandleDoor : MonoBehaviour
{
    public GameManager gm;
    public float amountOfCoinsNeededToOpenDoor;
    public Material portalMaterial;
    public TMP_Text message;

    Renderer _renderer;
    Material _originalMaterial;
    bool _isDoorUnlocked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _originalMaterial = _renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(gm.GetTotalScore() == amountOfCoinsNeededToOpenDoor)
            {
                HandleUnlocking();
            } else
            {
                Debug.Log("Door cannot be entered");
            }
        }
    }

    void HandleUnlocking()
    {
        if (!_isDoorUnlocked)
        {
            _isDoorUnlocked = true;
            message.text = "Enter the Door";
            _renderer.material = portalMaterial;
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
