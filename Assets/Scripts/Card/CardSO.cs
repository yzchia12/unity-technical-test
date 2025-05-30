using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Card")]
public class CardSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private CardAbility _ability;
    [SerializeField] private Color _cardImage;

    public string Name => _name;
    public int Health => _health;
    public int Damage => _damage;
    public CardAbility Ability => _ability;
    public Color CardImage => _cardImage;
    
}
