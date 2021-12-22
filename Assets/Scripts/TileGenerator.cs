using UnityEngine;

public class TileGenerator :MonoBehaviour
{
    public GameObject[] GetTiles(int level)
    {
        switch (level)
        {
            case 1: GetLevel1(); break;
            case 2: GetLevel2(); break;
            case 3: GetLevel3(); break;
            default: GetLevel1(); break;
        }
        return levelForTiles;
    }

    private GameObject[] levelForTiles;
    
    private GameObject[] GetLevel1()
    {
        levelForTiles = new GameObject[3];
        k = 0;
        for (int i = 1; i <= 3; i++)
        {
            levelForTiles[k] = new GameObject();
            levelForTiles[k].transform.position   = new Vector2(3*i, -3);
            k++;
        }

        return levelForTiles;
    }

    private GameObject[] GetLevel2()
    {
        levelForTiles = new GameObject[6];
        k = 0;
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 2; j++)
            {
                levelForTiles[k] = new GameObject();
                levelForTiles[k].transform.position = new Vector2(3 * i, 1 - 4*j );
                k++;
            }
        }
        return levelForTiles;
    }

    int k;
    private GameObject[] GetLevel3()
    {
        levelForTiles = new GameObject[9];
        k = 0;
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                levelForTiles[k] = new GameObject();
                levelForTiles[k].transform.position =  new Vector3(3 * i, 1 - 4*j, 0f);
                k++;
            }
        }
        return levelForTiles;
    }
   
}
