using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StorageCurrentSession : MonoBehaviour
{
    private List<string> usedSymbols = new List<string>();
    private List<string> currentAlhphabet = new List<string>();
    private string currentSymbLevel;

    public bool CheckSymbolInclude(string item)
    {
        bool result;
        var resInt = usedSymbols.FirstOrDefault(r => r == item).Count();
        if (resInt == 1) result = true;
        else result = false;
        return result;
    }

    public void AddSymbol(string item)
    {
        usedSymbols.Add(item);
    }

    public void AddAlphabet(List<DataModel> dataModels)
    {
        ClearLists();
        foreach (DataModel item in dataModels)
        {
            currentAlhphabet.Add(item.Identifier);
        }
    }

    public string GetRandomSymb()
    {
        int randNum = GetRandSymbLocal();
        while(usedSymbols.Contains(currentSymbLevel))
        {
            GetRandSymbLocal();
        }
        AddSymbol(currentAlhphabet[randNum]);
        return currentSymbLevel;
    }

    private int GetRandSymbLocal()
    {
        int randNum = Random.Range(0, currentAlhphabet.Count - 1);
        currentSymbLevel = currentAlhphabet[randNum];
        return randNum;
    }

    public void ClearLists()
    {
        currentAlhphabet.Clear();
    }

    public bool CompareCurrentLetter(string symb)
    {
        bool result;
        if (symb == currentSymbLevel) result= true;
        else result =  false;
        return result;
    }
}
