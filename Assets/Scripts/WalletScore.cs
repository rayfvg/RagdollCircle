using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class WalletScore : MonoBehaviour
{
    public int Score;

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _scoreValue;

    [SerializeField] private float _incrementDuration = 1f; // Длительность накопления очков

    private Coroutine _currentCoroutine;

    public void AddScoreGradually(int totalScore)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _scoreValue.transform.DOShakeRotation(1f, 20f, 5, 10, true, ShakeRandomnessMode.Harmonic);
        _scoreValue.transform.DOShakeScale(1f, 2f, 2, 10, true, ShakeRandomnessMode.Harmonic);
        _currentCoroutine = StartCoroutine(IncrementScore(totalScore));
    }

    private IEnumerator IncrementScore(int totalScore)
    {
        float elapsedTime = 0f;
        int accumulatedScore = 0;

        while (elapsedTime < _incrementDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / _incrementDuration;
            int targetScore = Mathf.RoundToInt(totalScore * progress);

            int deltaScore = targetScore - accumulatedScore;
            if (deltaScore > 0)
            {
                AddScore(deltaScore);
                accumulatedScore = targetScore;
            }

            yield return null;
        }

        int finalDelta = totalScore - accumulatedScore;
        if (finalDelta > 0)
        {
            AddScore(finalDelta);
        }

        _currentCoroutine = null;
    }

    public void AddScore(int value)
    {
        Score += value;
        _scoreText.text = Score.ToString();
    }

    public void ResetScore()
    {
        Score = 0;
        _scoreText.text = Score.ToString();
    }
}
