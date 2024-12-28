using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class BuAdsThavel : MonoBehaviour
{
    [SerializeField] private GameObject _selectButtonRedThavel;
    [SerializeField] private ParticleSystem _pacticleRedThavel;
    [SerializeField] private Button _adsButtonThavel;

    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;



    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    public void TryBuySkinThavel()
    {
        _selectButtonRedThavel.SetActive(true);
        _adsButtonThavel.gameObject.SetActive(false);
        _pacticleRedThavel.gameObject.SetActive(false);

        PlayerPrefs.SetInt("Thavel" + "buy", 1);

    }

    void Rewarded(int id)
    {
        if (id == 2)
            TryBuySkinThavel();
    }
    public void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
}
