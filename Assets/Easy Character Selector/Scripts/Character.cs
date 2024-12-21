using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ORKGames
{
    public class Character : MonoBehaviour
    {
        public int ID;
        public float Price;
        public string Name;
        public bool IsOpened;

        private void Update()
        {
            transform.Rotate(0f, 40f * Time.deltaTime, 0f);
        }

        public void Open()
        {
            IsOpened = true;
        }
    }
}

