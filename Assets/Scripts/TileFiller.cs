using System.Collections.Generic;
using UnityEngine;

public class TileFiller : MonoBehaviour
{
    GamePackFactory gamePackFactory;
    List<DataModel> assetPack;
    InitLevels init;

    private GameObject CanvasGroupTiles;
    private GameObject TilePrefab;

    private void SetTilePrefab()
    {
        TilePrefab = (GameObject)Resources.Load("Prefabs/TilePrefub");
        CanvasGroupTiles = GameObject.Find("CanvasGroupTiles");
    }

    private void GetFactory()
    {
        gamePackFactory = GameObject.Find("Storage").GetComponent<GamePackFactory>();
        assetPack = gamePackFactory.GetRandomAsset();
    }

    public void FillTile(GameObject[] levelForTiles)
    {
        GetFactory();
        SetTilePrefab();

        for (int i = 0; i <= levelForTiles.Length - 1; i++)
        {
            levelForTiles[i] = Instantiate(TilePrefab, levelForTiles[i].transform.position, Quaternion.identity);
            levelForTiles[i].GetComponent<DataModel>().Identifier = assetPack[i].Identifier;
            levelForTiles[i].GetComponent<SpriteRenderer>().sprite = assetPack[i].Sprite;

            levelForTiles[i].transform.parent = CanvasGroupTiles.transform;
        }
    }

 
}
