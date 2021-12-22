using UnityEngine;
using UnityEngine.UI;

public class InitLevels : MonoBehaviour
{
    private TileGenerator tileG;
    private TileFiller tileF;

    private GameObject[] levelForTiles;
    private EndGame endGame;

    StorageCurrentSession stc;
    int levelNumber = 1;

    Text FindSymbText;

    void Start()
    {
        FindSymbText = GameObject.Find("FindSymbText").GetComponent<Text>();
        endGame = GameObject.Find("EndGame").GetComponent<EndGame>();
        LoadLevel();
    }

    private void LoadLevel()
    {
        tileG = gameObject.GetComponent<TileGenerator>();
        levelForTiles = tileG.GetTiles(levelNumber);

        tileF = new TileFiller();
        tileF.FillTile(levelForTiles);

        stc = GameObject.Find("Storage").GetComponent<StorageCurrentSession>();
        FindSymbText.text = "Find \"" + stc.GetRandomSymb() + "\"";
    }

    public void LoadNextLevel()
    {
        if (levelNumber == 3) { endGame.InitEndGame(); return; }

        levelNumber++;
        LoadLevel();
    }

    public GameObject[] GetSpawnedGM()
    {
        var gm = levelForTiles;
        levelForTiles = null; 
        return gm;
    }


    public int GetQuantityElemtnsByCurrentLevel()
    {
        int quantity;
        switch (levelNumber)
        {
            case 1: quantity = 3; break;
            case 2: quantity = 6; break;
            case 3: quantity = 9; break;
            default: quantity = 3; break;
        }
        return quantity;
    }

}
