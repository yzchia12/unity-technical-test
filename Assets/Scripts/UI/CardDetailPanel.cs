using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDetailPanel : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Card _card;
    [SerializeField] private GameObject _content;
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        _closeButton.onClick.AddListener(OnClick);

        _content.SetActive(false);
    }

    public void ShowCard(CardSO cardData)
    {
        _content.SetActive(true);

        _card.Initialize(cardData);
    }

    private void OnClick()
    {
        _content.SetActive(false);
    }
}
