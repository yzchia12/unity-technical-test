using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//I use this as a UIManager
public class Hand : MonoBehaviour
{
    public static event Action<CardAbility> OnCardExecute;

    [Header("Settings")]
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private GameObject _contentHolder;

    [Header("Panel")]
    [SerializeField] private CardActionPanel _cardActionPanel;
    [SerializeField] private CardDetailPanel _cardDetailPanel;

    private CardSO[] cardData;
    private Card selectedCard;

    

    void Awake()
    {
        SpawnAllAvailableCards();

        Card.OnCardClicked += OnCardClicked;

        CardActionPanel.OnExecuteClicked += OnExecuteClicked;

        CardActionPanel.OnViewDetailsClicked += OnViewDetailsClicked;
    }

    private void OnCardClicked(Card card)
    {
        selectedCard = card;

        _cardActionPanel.OnCardClicked(card);
    }

    private void OnExecuteClicked()
    {        
        OnCardExecute?.Invoke(selectedCard.GetCardData().Ability);
    }

    private void OnViewDetailsClicked()
    {
        _cardDetailPanel.ShowCard(selectedCard.GetCardData());
    }

    public void SpawnAllAvailableCards()
    {
        cardData = Resources.LoadAll<CardSO>("ScriptableObjects/Card/");

        GameObject cardGO;
        Card card;

        for (int i = 0; i < cardData.Length; i++)
        {
            cardGO = GameObject.Instantiate(_cardPrefab, _contentHolder.transform);

            card = cardGO.GetComponent<Card>();

            card.Initialize(cardData[i]);
        }
    }
}
