using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ORKGames
{
    public class CharactersManager : MonoBehaviour
    {
        [Header("Drag this your  CharactersPrefabs")]
        public GameObject[] CharactersPrefabs = new GameObject[0];
        public int amountObjects;
        [Header("Help Tools")]
        [SerializeField] Transform Podium;
        [SerializeField] Transform Selector;
        void Start()
        {
            Vector3 center = transform.position;
            amountObjects = CharactersPrefabs.Length;

            for (int i = 0; i < CharactersPrefabs.Length; i++)
            {
                Vector3 pos = Circle(center, amountObjects, i);

                Quaternion rot = Quaternion.identity;
                if (i > 1)
                {
                    rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
                }
                if (i == 0)
                {
                    Selector.transform.position = pos;
                }
                GameObject InstantiatedObject = Instantiate(CharactersPrefabs[i], pos, rot);
                InstantiatedObject.transform.SetParent(Podium);
            }
        }

        Vector3 Circle(Vector3 center, float radius, int iterations)
        {
            //float ang = Random.value * 360;

            float ang = iterations * (360 / amountObjects);
            Vector3 pos;
            pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
            //pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
            pos.y = center.y;
            //pos.z = center.z;
            pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
            return pos;
        }
    }


}
