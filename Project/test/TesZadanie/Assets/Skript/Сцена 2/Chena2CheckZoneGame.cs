using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chena2CheckZoneGame : MonoBehaviour
{
    public static int ZonH = 20; // Высота
    public static int ZonW = 12; // Ширина

    int ohkiPluss = 100;

    public static Transform[,] grid = new Transform[ZonW, ZonH];

    Ohki ohki;

    void Start()
    {
        ohki = GameObject.FindGameObjectWithTag("Kol_ohkov").GetComponent<Ohki>();
    }

    void Update()
    {

    }

    public bool GameOverCheckPos(Shena2MovementPref movementPref)
    {
        for(int x = 0; x < ZonW; x++)
        {
            foreach(Transform moveP in movementPref.transform)
            {
                Vector2 posV = CheckF(moveP.position);
                if(posV.y > ZonH - 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool RowAt(int y)
    {
        for (int x = 0; x < ZonW; ++x)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void DelZon(int y)
    {
        for (int x = 0; x < ZonW; ++x)
        {
            Destroy(grid[x, y].gameObject);

            grid[x, y] = null;
        }
    }

    public void MovRowDonw(int y)
    {
        for (int x = 0; x < ZonW; ++x)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public void MovAllRowsDown(int y)
    {
        for (int i = y; i < ZonH; ++i)
        {
            MovRowDonw(i);
        }
    }

    public void DelPref()
    {
        for (int y = 0; y < ZonH; ++y)
        {
            if (RowAt(y))
            {
                DelZon(y);
                MovAllRowsDown(y + 1);
                --y;
                ohki.osnov += ohkiPluss;
            }
        }
    }

    public void checkPosZona(Shena2MovementPref movement)
    {
        for (int y = 0; y < ZonH; ++y)
            for (int x = 0; x < ZonW; ++x)
                if (grid[x, y] != null)
                {
                    if (grid[x, y].parent == movement.transform)
                    {
                        grid[x, y] = null;
                    }
                }

        foreach (Transform mov in movement.transform)
        {
            Vector2 vPos = CheckF(mov.position);
            if (vPos.y < ZonH)
            {
                grid[(int)vPos.x, (int)vPos.y] = mov;
            }
        }
    }

    public Transform MovPosition(Vector2 vecPos)
    {
        if (vecPos.y > ZonH - 1)
        {
            return null;
        }
        else
        {
            return grid[(int)vecPos.x, (int)vecPos.y];
        }
    }

    public bool Chek(Vector2 vecPos)
    {
        return ((int)vecPos.x >= 0 && (int)vecPos.x < ZonW && (int)vecPos.y >= 0);
    }

    public static Vector2 CheckF(Vector2 vecPos)
    {
        return new Vector2(Mathf.Round(vecPos.x), Mathf.Round(vecPos.y));
    }
}
