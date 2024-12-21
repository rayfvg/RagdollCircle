using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ORKGames
{
    public class Selector : MonoBehaviour
    {
        [Header("Buttons")]
        public GameObject SelectButton;
        public GameObject LockedButton;
        public GameObject BuyButton;

        [Space(40)]
        public float SelectedCharacterSize;

        [Header("CanvasTexts")]
        public Text PersonNameText;
        public Text PriceText;

        [Header("GameObjectOnScene")]
        public SaveSystem saveSystem;

        [HideInInspector] public bool IsSelected;

        private Character character;
        private GameObject selectedCharacter;

        
        private void Update()
        {
            if (selectedCharacter == null)
            {
                HideButtons();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            character = other.gameObject.GetComponent<Character>();

            selectedCharacter = other.gameObject;

            selectedCharacter.transform.localScale = new Vector3(SelectedCharacterSize, SelectedCharacterSize, SelectedCharacterSize);

            PersonNameText.text = character.Name;

            if (character.IsOpened)//selected Character is Opened?
            {
                ShowSelectButton();
            }
            else
            {
                ShowLockBuyButton();
                PriceText.text = character.Price.ToString() + "$";
            }

            IsSelected = true;
        }
        private void OnTriggerStay(Collider other)
        {

        }
        private void OnTriggerExit(Collider other)
        {
            character = null;


            selectedCharacter.transform.localScale = new Vector3(1f, 1f, 1f);

            PersonNameText.text = "";
            selectedCharacter = null;

            IsSelected = false;
        }

        public void SelectButtonAction()
        {
            Debug.Log("selected character ID " + character.ID);
        }
        public void BuyButtonAction()
        {
            character.Open();
            saveSystem.SaveNewPerson(character.ID);
            CheckCharacter();

            Debug.Log($"You Buy Character Name" + character.name + "ID = " + character.ID);
        }



        private void HideButtons()
        {
            SelectButton.SetActive(false);
            BuyButton.SetActive(false);
            LockedButton.SetActive(false);
        }
        private void ShowSelectButton()
        {
            SelectButton.SetActive(true);
        }
        private void ShowLockBuyButton()
        {
            LockedButton.SetActive(true);
            BuyButton.SetActive(true);
        }

        private void CheckCharacter()
        {
            if (character.IsOpened)
            {
                LockedButton.SetActive(false);
                BuyButton.SetActive(false);

                SelectButton.SetActive(true);
            }
        }
    }

}
