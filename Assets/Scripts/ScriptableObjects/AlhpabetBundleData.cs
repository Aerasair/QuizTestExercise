using UnityEngine;

[CreateAssetMenu(fileName = "New AlphabetData",menuName = "AlphabetBundleData", order = 10)]
public class AlhpabetBundleData : ScriptableObject
{
    [SerializeField]
    private AlphabetData[] _alpabetData;

    public AlphabetData[] AlhabetData => _alpabetData;
}
