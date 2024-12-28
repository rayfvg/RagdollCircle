using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG.Example;
using YG;
using UnityEngine.UI;

public class BuySkinCiirkle : MonoBehaviour
{
    [SerializeField] private GameObject _selectButtonRedCircle;
    [SerializeField] private ParticleSystem _pacticleRedCircle;
    [SerializeField] private Button _adsButton;

    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;



    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    public void TryBuySkinCirkul()
    {
        _selectButtonRedCircle.SetActive(true);
        _adsButton.gameObject.SetActive(false);
        _pacticleRedCircle.gameObject.SetActive(false);

        PlayerPrefs.SetInt("Circle" + "buy", 1);

    }

    void Rewarded(int id)
    {
        if (id == 1)
            TryBuySkinCirkul();
    }
    public void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
}
