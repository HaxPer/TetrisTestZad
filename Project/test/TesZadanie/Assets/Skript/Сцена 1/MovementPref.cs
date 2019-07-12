using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPref : MonoBehaviour
{
    float timeDown = 0; // ----------\
                                    // отвечают за подения фигуры
    float SpeedDown = 1; // ---------/


    public bool allRot = true; // переменная которая отвечает за то что можно ли вращать фигуру или нет
    public bool limRot = false; // переменная которая отвечает за вращение фигуры на 180 гр. или на 90 гр.

    CheckZoneGame zoneGame;
    SpwnPref spwnPref;

    void Start()
    {
        zoneGame = GameObject.FindGameObjectWithTag("GameZon").GetComponent<CheckZoneGame>();
        spwnPref = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpwnPref>();
    }

    void Update ()
    {
        Movement();
    }

    //передвижение фигуры
    void Movement()
    {
        //передвижение вправа при нажатии стрелки вправа
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

        //передвижение влево при нажатии стрелки влево
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

        //поворот фигуры при нажатии стрелки вверх
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

        //передвижение вниз при нажатии стрелки вниз
        if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - timeDown >= SpeedDown)
        {
            transform.position += new Vector3(0, -1, 0);

            if (CheckPosPref())
            {
                zoneGame.checkPosZona(this);
            }
            else
            {
                if (zoneGame.GameOverCheckPos(this))
                {
                    zoneGame.GameOver();
                }
                else
                {
                    transform.position += new Vector3(0, 1, 0);
                    zoneGame.CheckZon();
                    enabled = false;
                    spwnPref.CallDropRatePref();
                }
            }
            timeDown = Time.time;
        }
    }

    bool CheckPosPref()
    {
        foreach (Transform mino in transform)
        {
            Vector2 pos = CheckZoneGame.CheckF(mino.position);

            if (zoneGame.Chek(pos) == false)
            {
                return false;
            }

            if(zoneGame.MovPosition(pos) != null && zoneGame.MovPosition(pos).parent != transform)
            {
                return false;
            }
        }
        return true;
    }

    
}
