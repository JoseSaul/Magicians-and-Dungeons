using System;
using System.Collections;
using System.Collections.Generic;
using Character.UI;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    private static GameInstance Instance { get; set; }

    [SerializeField] private Deck deck;
    private int _lv, _exp, _maxExp = 10, _life, _maxLife = 10, _mana, _maxMana = 10, _rechargeCard = 3, _recoverMana = 2;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitUI()
    {
        _life = _maxLife;
        _mana = _maxMana;
    }

    public Deck GetDeck()
    {
        return deck;
    }

    public int GetMaxLife()
    {
        return _maxLife;
    }

    public int GetMaxMana()
    {
        return _maxMana;
    }

    public int GetMaxExp()
    {
        return _maxExp;
    }

    public int GetLV()
    {
        return _lv;
    }
    
    public int GetMana()
    {
        return _mana;
    }

    public void ConsumeMana(int consume)
    {
        _mana -= consume;
        FindObjectOfType<UiController>().SetMana(_mana);
    }
    
    public int GetTotalMana()
    {
        return _maxMana;
    }

    public int GetRechargeCard()
    {
        return _rechargeCard;
    }

    public int GetRecoverMana()
    {
        return _recoverMana;
    }
    
}
