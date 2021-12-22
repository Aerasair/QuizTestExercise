using UnityEngine;

public class EventClick : MonoBehaviour
{
    StorageCurrentSession stc;
    InitLevels init;
    SceneClear sc;
    DoTBounce dotBounce = new DoTBounce();
    DoTFade dotFade = new DoTFade();

    private void Start()
    {
        stc = GameObject.Find("Storage").GetComponent<StorageCurrentSession>();
        init = GameObject.Find("InitFirstLevel").GetComponent<InitLevels>();
        GameObject anim = GameObject.Find("AnimationCollection");
        dotBounce = anim.GetComponent<DoTBounce>();
        dotFade = anim.GetComponent<DoTFade>();
    }

    private void OnMouseDown()
    {
        bool result =  stc.CompareCurrentLetter(gameObject.GetComponent<DataModel>().Identifier);
        Debug.Log(gameObject.GetComponent<DataModel>().Identifier + ":" + result );

        if(result == true)
        {
            sc = new SceneClear();
            sc.ClearAfterLevel(init.GetSpawnedGM());
            init.LoadNextLevel();
            dotBounce.Shake(0,1,2.0f);
            dotFade.FadeOutIn(0.1f,1f);
        }
        if (result != true)
        {
            dotBounce.Shake(1, 0,1.0f);
        }
    }

}
