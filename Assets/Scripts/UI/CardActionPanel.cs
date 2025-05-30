using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardActionPanel : MonoBehaviour
{
    public static event Action OnExecuteClicked;
    public static event Action OnViewDetailsClicked;

    [Header("UI")]
    [SerializeField] private RectTransform _panel;
    [SerializeField] private Button _viewDetailsButton;
    [SerializeField] private Button _executeButton;
    [SerializeField] private GameObject _content;

    [Header("Configuration")]
    [SerializeField] private Vector3 _buttonOffset;

    // Start is called before the first frame update
    void Awake()
    {        
        _viewDetailsButton.onClick.AddListener(() => OnClick(_viewDetailsButton));
        _executeButton.onClick.AddListener(() => OnClick(_executeButton));

        _content.SetActive(false);
    }

    public  void OnCardClicked(Card card)
    {
        _panel.position = card.gameObject.transform.position + _buttonOffset;

        _content.SetActive(true);
    }

    private void OnClick(Button button)
    {
        if (_viewDetailsButton == button)
        {
            OnViewDetailsClicked?.Invoke();            
        }
        else if (_executeButton == button)
        {
            OnExecuteClicked?.Invoke();
        }

        _content.SetActive(false);
    }
}
