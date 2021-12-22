using UnityEngine;

[CreateAssetMenu(fileName = "New NumbersData",menuName = "NumbersBundleData", order = 10)]
public class NumbersBundleData : ScriptableObject
{
    [SerializeField]
    private NumbersData[] _numbersData;

    public NumbersData[] NumbersData  => _numbersData;
}
