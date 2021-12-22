using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GamePackFactory : MonoBehaviour
{
    List<DataModel> numbersDatas = new List<DataModel>();
    List<DataModel> alphabetDatas = new List<DataModel>();
    InitLevels init;
    StorageCurrentSession stc;

    void Start()
    {
        stc = GameObject.Find("Storage").GetComponent<StorageCurrentSession>();
        init = GameObject.Find("InitFirstLevel").GetComponent<InitLevels>();
    }

    private void FillPackFromBundles()
    {
        AlhpabetBundleData bundleData1 = (AlhpabetBundleData)Resources.Load("SOCollection/AlphabetData");
        var bundleList = bundleData1.AlhabetData.ToList();
   
            foreach (var item in bundleData1.AlhabetData)
            {
                DataModel d = new DataModel();
                d.Sprite = item.Sprite;
                d.Identifier = item.Identifier;
                alphabetDatas.Add(d);
            }
        
        List<DataModel> shufledBundle = ShuffleBundle(alphabetDatas);
        ///////////////////////////////////////
        NumbersBundleData numbersBundle = (NumbersBundleData)Resources.Load("SOCollection/NumbersData");


        foreach (var item in numbersBundle.NumbersData)
        {
            DataModel d = new DataModel();
            d.Sprite = item.Sprite;
            d.Identifier = item.Identifier;
            numbersDatas.Add(d);
        }
       List<DataModel> sfufleBundleN = ShuffleBundle(numbersDatas);
    }

    /// <summary>
    /// перемешиваем элементы и берем из них только необходимое количество для текущего уровня
    /// </summary>
       private List<DataModel> ShuffleBundle(List<DataModel> bundleData)
    {
        int RND = Random.Range(0, bundleData.Count);

        DataModel tempGO;

        for (int i = 0; i < bundleData.Count; i++)
        {
            int rnd = Random.Range(0, bundleData.Count);
            tempGO = bundleData[rnd];
            bundleData[rnd] = bundleData[i];
            bundleData[i] = tempGO;
        }

        bundleData = bundleData.Take(init.GetQuantityElemtnsByCurrentLevel()).ToList();//берем верхние X элементов для нашего алфавита на текущий уровень

        return bundleData;
    }

    public List<DataModel> GetRandomAsset()
    {
        FillPackFromBundles();
        int rand = Random.Range(1, 3);
        List<DataModel> listDM = new List<DataModel>();
        switch (rand)
        {
            case 1: listDM = TakeTopElementsForLevel(alphabetDatas); FillListAlhpInStorage(listDM);  return alphabetDatas; break;
            case 2: listDM = TakeTopElementsForLevel(numbersDatas); FillListAlhpInStorage(listDM); return numbersDatas;  break;
            default:  return alphabetDatas;  break; 

        }
    }


    private List<DataModel> TakeTopElementsForLevel(List<DataModel> dtM)
    {
        return dtM.Take(init.GetQuantityElemtnsByCurrentLevel()).ToList();
    }
    private void FillListAlhpInStorage(List<DataModel> dtM)
    {
        stc.AddAlphabet(dtM);
    }
}
