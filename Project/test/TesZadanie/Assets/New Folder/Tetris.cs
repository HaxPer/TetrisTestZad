//http://doctrina-kharkov.blogspot.com/2016/07/programme.html
using UnityEngine;
using System.Collections;

public class Tetris : MonoBehaviour
{
	public GameObject pfbBlock; //префаб блока

	public int[,] pole = new int[,]{
		{2,0,0,0,0,0,0,0,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,1,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,1,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,1,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,1,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,0,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,0,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,0,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,0,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,0,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,0,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,0,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,0,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,0,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,0,0,0,0,0,0,2},
		{2,0,0,0,0,0,0,0,0,0,0,0,0,2},
        {2,0,0,0,0,0,0,0,0,0,0,0,0,2},
        {2,0,0,0,0,0,0,0,0,0,0,0,0,2},
        {2,0,0,0,0,0,0,0,0,0,0,0,0,2},
        {2,0,0,0,0,0,0,0,0,0,0,0,0,2},
        {2,2,2,2,2,2,2,2,2,2,2,2,2,2},
    };
	public GameObject[,] blocks; //массив блоков на экране

    int xCord;
    int yCord;

    void Start ()
	{
		FillAll ();
	}

	void FillAll ()
	{
		blocks = new GameObject[20, 14];

		for (int y = 0; y < 20; y++) {
			for (int x = 1; x < 13; x++) {
				blocks [y, x] = GameObject.Instantiate (pfbBlock);
				blocks [y, x].transform.position = new Vector3 (x, 19 - y, 0); //в массиве координаты по Y увеличиваются вниз, а в Unity вверх 
			}
		}
	}

	void Draw ()
	{
		for (int y = 0; y < 20; y++) {
			for (int x = 1; x < 13; x++) {
				if (pole [y, x] > 0) {
					blocks [y, x].SetActive (true);
					if ( pole[y,x] == 2 ){
						blocks[y,x].GetComponent<SpriteRenderer>().color = Color.white;				
					}
					if ( pole[y,x] == 1 ){
						blocks[y,x].GetComponent<SpriteRenderer>().color = Color.red;				
					}
				} else {
					blocks [y, x].SetActive (false);
				}
			}
		}
	}

	void Replace ()
	{
		for (int y = 0; y < 20; y++) {
			for (int x = 0; x < 12; x++) {				
				if (pole [y, x] == 1) {
					pole [y, x] = 2;
				} else {
					pole [y, x] = pole [y, x];
				}
			}
		}
	}
	
	void CleanLine (int line)
	{
		for (int x=0; x < 14; x++) {
			pole [line, x] = 0;
		}
	}

	void Update ()
	{	
        Draw ();

        MOVEpref();
	}

    void MOVEpref()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            int[,] tmp = new int[20, 14];

            for (int y = 19; y >= 0; y--)
            {
                for (int x = 1; x < 13; x++)
                {

                    if (y > 0)
                    {
                        if (pole[y, x] == 2 && pole[y - 1, x] == 1)
                        {
                            Replace(); //заменяем все единицы на двойки
                            return; //преккащаем
                        }
                    }

                    if (y == 19 && pole[y, x] == 1)
                    { //добрались до низа						
                        Replace(); //заменяем все единицы на двойки
                        return; //преккащаем
                    }

                    if (y < 19)
                    {
                        if (pole[y, x] == 1)
                        {
                            tmp[y + 1, x] = 1;
                        }
                    }

                    if (pole[y, x] == 2)
                    {
                        tmp[y, x] = 2;
                    }
                }
            }

            yCord++;

            pole = tmp;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int[,] tmp = new int[20, 14];

            for (int y = 0; y < 19; y++)
            {
                for (int x = 1; x < 13; x++)
                {

                    if (x == 10 && pole[y, x + 1] == 1)
                    {
                        return;
                    }

                    if (pole[y, x] == 1 && pole[y, x + 1] == 2)
                    {
                        return;
                    }

                    if (pole[y, x] == 1)
                    {
                        tmp[y, x + 1] = 1;
                    }

                    if (pole[y, x] == 2)
                    {
                        tmp[y, x] = pole[y, x];
                    }
                }
            }

            xCord++;

             pole = tmp;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int[,] tmp = new int[20, 14];

            for (int y = 0; y < 19; y++)
            {
                for (int x = 10; x >= 0; x--)
                {

                    if (x == 1 && pole[y, x - 1] == 1)
                    {
                        return;
                    }

                    if (pole[y, x] == 1 && pole[y, x - 1] == 2)
                    {
                        return;
                    }

                    if (pole[y, x] == 1)
                    {
                        tmp[y, x - 1] = 1;
                    }

                    if (pole[y, x] == 2)
                    {
                        tmp[y, x] = pole[y, x];
                    }
                }
            }

            xCord--;

            pole = tmp;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            int[,] tmp = new int[xCord, yCord];
            for (int y = xCord; y < yCord + 3; y++)
            {
                for (int x = xCord; x < xCord + 3; x++)
                {
                    tmp[y - yCord, x - xCord] = pole[y, x];
                    if (pole[y, x] == 2)
                    {
                        return;
                    }
                }
            }
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    pole[y + yCord, x + xCord] = tmp[2 - x, y];
                }
            }
        }

        int cleanedLines = 0;
        for (int y = 18; y >= 0; y--)
        {
            int sum = 0;
            for (int x = 0; x < 14; x++)
            {
                sum = sum + pole[y, x];
                if (sum == 20)
                {
                    CleanLine(y);
                    cleanedLines++;
                }
            }
        }

        for (int i = 0; i < cleanedLines; i++)
        {
            for (int y = 18; y > 1; y--)
            {
                for (int x = 0; x < 14; x++)
                {
                    if (pole[y, x] == 0 && pole[y - 1, x] == 2)
                    {
                        pole[y, x] = 2;
                        pole[y - 1, x] = 0;
                    }
                }
            }
        }
    }
}