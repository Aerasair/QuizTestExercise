using UnityEngine;

public class EndGame : MonoBehaviour
{
    private CanvasGroup CanvasGroupTiles, CanvasGroupRestart, CanvasGroupText;

    void Start()
    {
        CanvasGroupTiles = GameObject.Find("CanvasGroupTiles").GetComponent<CanvasGroup>();
        CanvasGroupRestart = GameObject.Find("CanvasGroupRestart").GetComponent<CanvasGroup>();
        CanvasGroupText = GameObject.Find("CanvasGroupText").GetComponent<CanvasGroup>();
    }

    public void InitEndGame()
    {
        CanvasGroupTiles.interactable = false;
        CanvasGroupTiles.blocksRaycasts = false;

        CanvasGroupText.alpha = 0f;

        CanvasGroupRestart.interactable = true;
        CanvasGroupRestart.blocksRaycasts = true;
        CanvasGroupRestart.alpha = 1f;
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
