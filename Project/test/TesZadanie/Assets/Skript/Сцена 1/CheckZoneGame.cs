using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckZoneGame : MonoBehaviour
{
    public static int ZonH = 20; // Высота
    public static int ZonW = 10; // Ширина

    int ohkiPluss = 100;

    public static Transform[,] grid = new Transform[ZonW, ZonH]; // массив который хранит в себе значение позиции игрового поля

    Ohki ohki;

    SpwnPref spwnPref;

    void Start ()
    {
        ohki = GameObject.FindGameObjectWithTag("Kol_ohkov").GetComponent<Ohki>();
        spwnPref = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpwnPref>();
        spwnPref.CallDropRatePref();
    }

    // общая функция для проверки и удаления заполненных линий
    public void CheckZon()
    {
        for (int i = ZonH - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DelLine(i);
                RowDown(i);
            }
        }
    }

    // проверка на наличие заполненных линий
    bool HasLine(int i)
    {
        for (int x = 0; x < ZonW; x++)
        {
            if (grid[x, i] == null)
            {
                return false;
            }
        }

        return true;
    }

    //удаление заполненной линии
    public void DelLine(int i)
    {

        for (int x = 0; x < ZonW; x++)
        {
            Destroy(grid[x, i].gameObject);
            grid[x, i] = null;
            ohki.osnov += ohkiPluss;
        }
    }

    // функция которая реализует передвижение не удаленных линий на место удаленных
    public void RowDown(int i)
    {
        for (int y = i; y < ZonH; y++)
        {
            for (int x = 0; x < ZonW; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].position += new Vector3(0, -1, 0);
                }
            }
        }
    }

    // проверка достигла ли фигура верхней точки
    public bool GameOverCheckPos(MovementPref movementPref)
    {
        for (int x = 0; x < ZonW; x++)
        {
            foreach (Transform moveP in movementPref.transform)
            {
                Vector2 posV = CheckF(moveP.position);
                if (posV.y > ZonH - 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    // функция которая не позволяет фигуре проходить через другие уже не активные фигуры
    public void checkPosZona(MovementPref movement)
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

    // проверка текущей позиции игрового поля
    public Transform MovPosition(Vector2 vecPos)
    {
        if(vecPos.y > ZonH - 1)
        {
            return null;
        }
        else
        {
            return grid[(int)vecPos.x, (int)vecPos.y];
        }
    }

    //проверка на наличие фигуры в нутри границы(игрового поля)
    public bool Chek(Vector2 vecPos)
    {
        return ((int)vecPos.x >= 0 && (int)vecPos.x < ZonW && (int)vecPos.y >= 0);
    }

    //удержание фигуры в нутри игровго поля
    public static Vector2 CheckF(Vector2 vecPos)
    {
        return new Vector2(Mathf.Round(vecPos.x), Mathf.Round(vecPos.y));
    }

    // сцена конца игры при проигрыше
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
