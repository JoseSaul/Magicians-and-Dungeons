using System;
using System.Collections;
using System.Collections.Generic;
using Cards;
using UnityEngine;

public class Deck : MonoBehaviour
{
    
    [SerializeField] private Card[] deck = new Card[30];
    private Card[] _deck;

    private void Start()
    {
        _deck = deck;
    }


    public Card GetCard()
    {
        return _deck[3];
    }
    
}
