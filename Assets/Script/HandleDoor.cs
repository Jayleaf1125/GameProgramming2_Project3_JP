using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
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
                StartCoroutine(TryAgain()); 
            }
        }
    }

    IEnumerator TryAgain()
    {
        string temp = message.text;
        message.text = "You're missing coins";
        yield return new WaitForSeconds(3f);
        message.text = temp;
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
