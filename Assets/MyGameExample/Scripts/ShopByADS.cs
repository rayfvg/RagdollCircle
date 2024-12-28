using TMPro;
using Unity.Loading;
using UnityEngine;
using UnityEngine.UI;
using YG;
using YG.Example;

public class ShopByADS : MonoBehaviour
{
    [SerializeField] private GameObject _selectButtonRed;
 

    [SerializeField] private GameObject[] _selectButtonReds;

    [SerializeField] private GameObject _buyAdsButton;

    [SerializeField] private ParticleSystem _pacticleGreen;
    [SerializeField] private ParticleSystem _pacticleRed;
    [SerializeField] private ParticleSystem _pacticleRedThawel;


    [SerializeField] private Animator _animator;
    [SerializeField] private Animator[] _animators;

    private void OnEnable()
    {
        LoadSaves();
        
    }

   

 

    //public void TryBuySkinThavel()
    //{
    //    _selectButtonRed.SetActive(true);

    //   // _pacticleRedThawel.gameObject.SetActive(false);

    //    PlayerPrefs.SetInt("Thavel" + "buy", 1);

    //}

    public void SelectSkin()
    {
        foreach (var anim in _animators)
            anim.SetBool("dance", false);

        foreach (var red in _selectButtonReds)
            red.gameObject.GetComponent<Button>().interactable = true;

        _selectButtonRed.GetComponent<Button>().interactable = false;
        _animator.SetBool("dance", true);
        _pacticleGreen.gameObject.SetActive(true);

        PlayerPrefs.SetInt("Bloomselect", 0);
        PlayerPrefs.SetInt("Circleselect", 0);
        PlayerPrefs.SetInt("Thavelselect", 0);

        PlayerPrefs.SetInt(gameObject.name + "select", 1);
    }

    public void LoadSaves()
    {
      
        if (PlayerPrefs.GetInt(gameObject.name + "buy") == 1)
        {
            _buyAdsButton.SetActive(false);
            _selectButtonRed.SetActive(true);

            _pacticleRed.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt(gameObject.name + "select") == 1)
        {
            foreach (var anim in _animators)
                anim.SetBool("dance", false);

            foreach (var red in _selectButtonReds)
                red.gameObject.GetComponent<Button>().interactable = true;

            _selectButtonRed.GetComponent<Button>().interactable = false;
            _animator.SetBool("dance", true);
            _pacticleGreen.gameObject.SetActive(true);
        }

    }


    
}
