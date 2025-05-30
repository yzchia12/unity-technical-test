using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Card : MonoBehaviour
{
    public static event Action<Card> OnCardClicked;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _cardNameText;
    [SerializeField] private TextMeshProUGUI _cardHealthText;
    [SerializeField] private TextMeshProUGUI _cardAttackText;
    [SerializeField] private Button _cardButton;
    [SerializeField] private Image _cardImage;

    private CardSO cardData;

    public void Initialize(CardSO cardData)
    {
        _cardNameText.text = cardData.Name;
        _cardHealthText.text = "HP: " + cardData.Health;
        _cardAttackText.text = "Attack: " + cardData.Damage;
        _cardImage.color = cardData.CardImage;

        this.cardData = cardData;

        _cardButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        OnCardClicked?.Invoke(this);
    }

    public void OnExecute()
    {
        gameObject.SetActive(false);
    }

    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }

    public CardSO GetCardData()
    {
        return cardData;
    }
}
