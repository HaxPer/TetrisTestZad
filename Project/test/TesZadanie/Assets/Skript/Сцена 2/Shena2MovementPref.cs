using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shena2MovementPref : MonoBehaviour
{
    [System.Serializable]
    public class Pref
    {
        public GameObject prefab;
        public int droprate;
    }

    public List<Pref> ListPrefs = new List<Pref>();
    public int ChansDropa;

    float timeDown = 0;
    float SpeedDown = 1;


    public bool allRot = true;
    public bool limRot = false;

    Chena2CheckZoneGame zoneGame;
    SpwnPref spwnPref;

    public GameObject Spawn;

    void Start()
    {
        zoneGame = GameObject.FindGameObjectWithTag("GameZon").GetComponent<Chena2CheckZoneGame>();
        spwnPref = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpwnPref>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

            if (CheckPosPref())
            {
                zoneGame.checkPosZona(this);
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);

            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (CheckPosPref())
            {
                zoneGame.checkPosZona(this);
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);

            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (allRot)
            {

                if (limRot)
                {

                    if (transform.rotation.eulerAngles.z >= 90)
                    {

                        transform.Rotate(0, 0, -90);

                    }
                    else
                    {
                        transform.Rotate(0, 0, 90);

                    }

                }
                else
                {

                    transform.Rotate(0, 0, 90);
                }

                if (CheckPosPref())
                {
                    zoneGame.checkPosZona(this);
                }
                else
                {
                    if (limRot)
                    {

                        if (transform.rotation.eulerAngles.z >= 90)
                        {

                            transform.Rotate(0, 0, -90);

                        }
                        else
                        {

                            transform.Rotate(0, 0, 90);
                        }

                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -1, 0);

            if (CheckPosPref())
            {
                zoneGame.checkPosZona(this);
            }
            else
            {
                if(zoneGame.GameOverCheckPos(this))
                {
                    SceneManager.LoadScene("GameOver");
                }
                else
                {
                    transform.position += new Vector3(0, 1, 0);
                    zoneGame.DelPref();
                    enabled = false;
                    spwnPref.CallDropRatePref();
                }
            }
        }
    }

    bool CheckPosPref()
    {
        foreach (Transform mino in transform)
        {
            Vector2 pos = Chena2CheckZoneGame.CheckF(mino.position);

            if (zoneGame.Chek(pos) == false)
            {
                return false;
            }

            if (zoneGame.MovPosition(pos) != null && zoneGame.MovPosition(pos).parent != transform)
            {
                return false;
            }
        }
        return true;
    }
}
