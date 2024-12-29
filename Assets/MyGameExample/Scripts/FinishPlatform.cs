using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishPlatform : MonoBehaviour
{
    public AudioSource FinishSound;

    [SerializeField] private ParticleSystem[] _particles;
    [SerializeField] private GameObject _finishUi;
    [SerializeField] private GameObject _gameplayUI;

    [SerializeField] private GameObject _LoserTableUI;

    [SerializeField] private WalletScore _walletScore;

    [SerializeField] private TMP_Text _conteinerScore;

    [SerializeField] private StartLevels _startLevels;

    [SerializeField] private Button _finishButton;
    [SerializeField] private GameObject _currentLvl;
    [SerializeField] private GameObject _mainMenu;

    [SerializeField] private Button _backinMenu;
    [SerializeField] private Button _mainMenuButton;

    public int ScoreFor1Starr;
    public int ScoreFor2Starr;
    public int ScoreFor3Starr;

    [SerializeField] private GameObject[] _stars;

    [SerializeField] private int _id;

    public bool _isFinished = false;

    private Coroutine _currentCoroutine;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.GetComponent<CameraTarget>() != null && _isFinished == false)
    //    {
    //        FinishTable();
    //        Debug.Log("Fin");
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CameraTarget>() != null && _isFinished == false)
        {
            FinishTable();
            Debug.Log("Fin");

        }
    }

    private void OnEnable()
    {
        _finishButton.onClick.AddListener(RetunrToMenuAfterWin);
        _backinMenu.onClick.AddListener(backToMenuAfterLose);
        _mainMenuButton.onClick.AddListener(backToMenuAfterLose);
    }
    private void OnDisable()
    {
        _finishButton.onClick.RemoveListener(RetunrToMenuAfterWin);
        _backinMenu.onClick.RemoveListener(backToMenuAfterLose);
        _mainMenuButton.onClick.RemoveListener(backToMenuAfterLose);
    }

    private void FinishTable()
    {
        FinishSound.Play();
        _isFinished = true;
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(PatricleActive());
    }

    private IEnumerator PatricleActive()
    {
        foreach (var particle in _particles)
            particle.Play();

        yield return new WaitForSeconds(1.5f);

        int oldScore = PlayerPrefs.GetInt(_id.ToString());
        if (oldScore < _walletScore.Score)
            PlayerPrefs.SetInt(_id.ToString(), _walletScore.Score);

        Enemy enemy = FindObjectOfType<Enemy>();
        Destroy(enemy.gameObject);
        _isFinished = false;

        AwardStarts();

        _gameplayUI.SetActive(false);
        _conteinerScore.text = _walletScore.Score.ToString();

        _currentCoroutine = null; // Очистка ссылки после завершения
    }

    public void ResetInFinishPlase()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
        _isFinished = false;
    }

    private void RetunrToMenuAfterWin()
    {
        _isFinished = false;
        _currentLvl.SetActive(false);
        _mainMenu.SetActive(true);
        _finishUi.SetActive(false);
        _startLevels.TryUpdateValueScore();
        ResetStars();
    }

    private void backToMenuAfterLose()
    {
        Enemy enemy = FindObjectOfType<Enemy>();
        if (enemy != null)
            Destroy(enemy.gameObject);

        _isFinished = false;
        _currentLvl.SetActive(false);
        _LoserTableUI.SetActive(false);
        _mainMenu.SetActive(true);
        _gameplayUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void AwardStarts()
    {
        _finishUi.SetActive(true);

        if (_walletScore.Score >= ScoreFor1Starr)
        {
            _stars[0].SetActive(true);
            AnimateStar(_stars[0].transform);
        }

        if (_walletScore.Score >= ScoreFor2Starr)
        {
            _stars[1].SetActive(true);
            AnimateStar(_stars[1].transform);
        }

        if (_walletScore.Score >= ScoreFor3Starr)
        {
            _stars[2].SetActive(true);
            AnimateStar(_stars[2].transform);
        }

    }

    private void ResetStars()
    {
        foreach (GameObject start in _stars)
            start.SetActive(false);
    }

    private void AnimateStar(Transform star)
    {
        star.localScale = Vector3.zero; // Устанавливаем изначальный размер 0
        star.DOScale(new Vector3(1.6f, 1.6f, 1.6f), 0.8f) // Увеличиваем до пульсации
            .SetEase(Ease.OutBounce) // Используем плавное увеличение
            .OnComplete(() =>
                star.DOScale(Vector3.one, 0.8f / 2).SetEase(Ease.OutBack)); // Возвращаем к исходному размеру
    }
}
