using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.IO;

namespace ORKGames
{
    public class SaveSystem : MonoBehaviour
    {
        public CharactersManager charactersManager;

        private Save sv;
        private string path;
        void Start()
        {
            UnlockPurchashedCharacters();
        }


        private void UnlockPurchashedCharacters()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
            path = Application.dataPath + "/Save.json";
#endif

            if (File.Exists(path))
            {
                sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
            }
            if (sv == null)
            {
                sv = new Save
                {
                    OpenedID = new List<int>()
                };
            }

            foreach (int o in sv.OpenedID)
            {
                int W = o;
                {
                    charactersManager.CharactersPrefabs[W].GetComponent<Character>().Open();
                }
            }

        }
        public void SaveNewPerson(int id)
        {
            sv.OpenedID.Add(id);

            SaveFileJson();
        }
        private void SaveFileJson()
        {
            File.WriteAllText(path, JsonUtility.ToJson(sv));
        }
    }
    [System.Serializable]
    public class Save
    {
        public List<int> OpenedID;
    }

}
