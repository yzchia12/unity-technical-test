using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Card")]
public class CardSO : ScriptableObject
{
    public string Name;
    public int Health;
    public int Damage;
    
}
