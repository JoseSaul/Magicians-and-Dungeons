using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Cards
{
    public class Deck : MonoBehaviour
    {
    
        [SerializeField] private Card[] deck = new Card[30];
        [SerializeField] private Card brokenCard;
        private readonly List<Card> _deck = new List<Card>();


        private void Start()
        {
            InitDeck();
        }

        public Card[] GetDeck()
        {
            return deck;
        }

        public void InitDeck()
        {
            foreach (var card in deck)
            {
                if (card != null)
                {
                    _deck.Add(card);
                }
            }
        }
        
        public Card GetCard()
        {
            if (_deck.Count > 0)
            {
                var random = new Random();
                var index = random.Next(_deck.Count);
                var selectedCard = _deck[index];
                _deck.RemoveAt(index);
                return selectedCard;
            }
            else
            {
                return brokenCard;
            }
        }

    }
}
