using System;
using UnityEngine;

[Serializable]
public class NumbersData 
{
    [SerializeField]
    private string _identifier;
    
    [SerializeField]
    private Sprite __sprite;

    public string Identifier => _identifier;

    public Sprite Sprite => __sprite;
}
