using UnityEngine;

public class MovPref : MonoBehaviour
{
    int[,] pole = new int[,]{
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,1,1,0,0,0,0,0},
   {0,0,0,0,0,1,1,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
   {0,0,0,0,0,0,0,0,0,0,0,0},
  };

    public GameObject Pref;
    GameObject[,] allPref;
    // Use this for initialization
    void Start ()
    {
        createZonGame();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void createZonGame()
    {
        allPref = new GameObject[20, 10];

        for (int y = 0; y < 16; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                allPref[y, x] = GameObject.Instantiate(Pref);
                allPref[y, x].transform.position = new Vector3(x, 0 - y, 0); //в массиве координаты по Y увеличиваются вниз, а в Unity вверх 
            }
        }
    }
}
