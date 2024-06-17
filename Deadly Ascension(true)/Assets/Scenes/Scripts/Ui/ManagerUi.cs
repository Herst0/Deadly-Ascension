using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ADNText, MoneyText;

    public int _adn;
    public int _money;
    void Start()
    {
        ADNText.text = "ADN : " + _adn;
        MoneyText.text = "Money : " + _money;
    }

    public void IncreaseADN()
    {
        _adn += 1;
        ADNText.text = "ADN : " + _adn;
    }
    
    public void IncreaseMoney(int _quantity)
    {
        _money += _quantity;
        MoneyText.text = "Money : " + _money;
    }
}
