using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class WalletScore : MonoBehaviour
{
    public int Score;
    [SerializeField] private float _incrementDuration = 1f; // Длительность накопления очков
    [SerializeField] private float _baseShakeStrength = 10f; // Базовая сила тряски
    [SerializeField] private int _shakeVibrato = 10; // Количество колебаний во время тряски

    [SerializeField] RectTransform _scoreRectTransform;
    [SerializeField] private TMP_Text _scoreText;

    private Coroutine _currentCoroutine;
    private Vector2 _initialPosition;

    private void Start()
    {
        _initialPosition = _scoreRectTransform.anchoredPosition;
    }
    public void AddScoreGradually(int totalScore)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        // Убедиться, что объект вернется в исходное состояние
        _scoreRectTransform.DOKill(true);
        _scoreRectTransform.anchoredPosition = _initialPosition;

        // Рассчитать силу тряски
        float shakeStrength = CalculateShakeStrength(totalScore, _incrementDuration);

        // Анимация тряски
        _scoreRectTransform
            .DOShakeAnchorPos(_incrementDuration, shakeStrength, _shakeVibrato, 90, true)
            .OnKill(() => _scoreRectTransform.anchoredPosition = _initialPosition) // Возвращаем на место при завершении
            .OnComplete(() => _scoreRectTransform.anchoredPosition = _initialPosition); // Возвращаем на место после завершения

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
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        Score = 0;
        _scoreText.text = Score.ToString();
    }

    private float CalculateShakeStrength(int totalScore, float duration)
    {
        // Рассчитываем силу тряски: чем больше очков и меньше длительность, тем сильнее тряска
        float scoreFactor = Mathf.Log(totalScore + 1); // Логарифмическая зависимость от количества очков
        float timeFactor = Mathf.Max(0.1f, duration); // Учитываем минимальное время, чтобы избежать деления на 0
        return _baseShakeStrength * (scoreFactor / timeFactor);
    }
}
