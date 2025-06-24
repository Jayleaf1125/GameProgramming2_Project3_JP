using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    float _totalScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _totalScore = 0;
    }

    public void IncrementTotalScore() => _scoreText.text = $"Coins Collected: {++_totalScore}";
    public float GetTotalScore() => _totalScore;
}
