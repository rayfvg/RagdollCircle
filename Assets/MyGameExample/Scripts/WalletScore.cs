using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class WalletScore : MonoBehaviour
{
    public int Score;
    [SerializeField] private float _incrementDuration = 1f; // ������������ ���������� �����
    [SerializeField] private float _baseShakeStrength = 10f; // ������� ���� ������
    [SerializeField] private int _shakeVibrato = 10; // ���������� ��������� �� ����� ������

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

        // ���������, ��� ������ �������� � �������� ���������
        _scoreRectTransform.DOKill(true);
        _scoreRectTransform.anchoredPosition = _initialPosition;

        // ���������� ���� ������
        float shakeStrength = CalculateShakeStrength(totalScore, _incrementDuration);

        // �������� ������
        _scoreRectTransform
            .DOShakeAnchorPos(_incrementDuration, shakeStrength, _shakeVibrato, 90, true)
            .OnKill(() => _scoreRectTransform.anchoredPosition = _initialPosition) // ���������� �� ����� ��� ����������
            .OnComplete(() => _scoreRectTransform.anchoredPosition = _initialPosition); // ���������� �� ����� ����� ����������

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
        // ������������ ���� ������: ��� ������ ����� � ������ ������������, ��� ������� ������
        float scoreFactor = Mathf.Log(totalScore + 1); // ��������������� ����������� �� ���������� �����
        float timeFactor = Mathf.Max(0.1f, duration); // ��������� ����������� �����, ����� �������� ������� �� 0
        return _baseShakeStrength * (scoreFactor / timeFactor);
    }
}
