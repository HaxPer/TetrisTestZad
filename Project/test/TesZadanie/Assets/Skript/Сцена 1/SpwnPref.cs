using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpwnPref : MonoBehaviour {

    [System.Serializable]
    public class Pref
    {
        public GameObject prefab;
        public int droprate;
    }

    public List<Pref> ListPrefs = new List<Pref>();
    public int ChansDropa;
    Chena2CheckZoneGame zoneGame;
    Shena2MovementPref movementPref;

    void Start()
    {
        zoneGame = GameObject.FindGameObjectWithTag("GameZon").GetComponent<Chena2CheckZoneGame>();
    }

    void Update()
    {

    }

    public void CallDropRatePref()
    {
        int DipDrop = Random.Range(0, 7);

        if (DipDrop <= ChansDropa)
        {
            int prefWeight = 0;

            for (int i = 0; i < ListPrefs.Count; i++)
            {
                prefWeight += ListPrefs[i].droprate;
            }

            int randValua = Random.Range(0, prefWeight);

            for (int j = 0; j < ListPrefs.Count; j++)
            {
                if (randValua <= ListPrefs[j].droprate)
                {
                    Instantiate(ListPrefs[j].prefab, transform.position, transform.rotation);
                    return;
                }
                randValua -= ListPrefs[j].droprate;
            }
        }
    }
}
