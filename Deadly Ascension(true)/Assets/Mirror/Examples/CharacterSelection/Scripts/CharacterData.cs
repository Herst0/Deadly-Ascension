using UnityEngine;
using Mirror;
namespace Mirror.Examples.CharacterSelection
{
    public class CharacterData : NetworkBehaviour
    {
        // A reference data script for most things character and customisation related.

        public static CharacterData characterDataSingleton { get; private set; }

        public GameObject[] characterPrefabs;
        public string[] characterTitles;
        public int[] characterHealths;
        public float[] characterSpeeds;
        public int[] characterAttack;
        public string[] characterAbilities;

        public void Awake()
        {
            characterDataSingleton = this;
        }

    }

}