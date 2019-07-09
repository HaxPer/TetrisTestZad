using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPref : MonoBehaviour
{
    float timeDown = 0;
    float SpeedDown = 1;


    public bool allRot = true;
    public bool limRot = false;

    void Start()
    {
        
    }

    void Update ()
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
                FindObjectOfType<CheckZoneGame>().checkPosZona(this);
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
                FindObjectOfType<CheckZoneGame>().checkPosZona(this);
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
                    FindObjectOfType<CheckZoneGame>().checkPosZona(this);
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

        if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - timeDown >= SpeedDown)
        {
            transform.position += new Vector3(0, -1, 0);

            if (CheckPosPref())
            {
                FindObjectOfType<CheckZoneGame>().checkPosZona(this);
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                FindObjectOfType<CheckZoneGame>().DelPref();
                enabled = false;
            }
            timeDown = Time.time;
        }
    }

    bool CheckPosPref()
    {
        foreach (Transform mino in transform)
        {
            Vector2 pos = CheckZoneGame.CheckF(mino.position);

            if (FindObjectOfType<CheckZoneGame>().Chek(pos) == false)
            {
                return false;
            }

            if(FindObjectOfType<CheckZoneGame>().MovPosition(pos) != null && FindObjectOfType<CheckZoneGame>().MovPosition(pos).parent != transform)
            {
                return false;
            }
        }
        return true;
    }
}
