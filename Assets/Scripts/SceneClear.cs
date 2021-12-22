using UnityEngine;

public class SceneClear : MonoBehaviour
{
    public void ClearAfterLevel(GameObject[] gmArray)
    {
        foreach(var item in gmArray)
        {
            Destroy(item);
        }
    }
}
