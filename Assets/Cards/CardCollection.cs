using System;
using UnityEngine;

namespace Cards
{
    public class CardCollection : MonoBehaviour
    {

        private Card _card;
        private int _quantity;

        public CardCollection()
        {
            
        }
        
        public CardCollection(Card card, int quantity)
        {
            _card = card;
            _quantity = quantity;
        }

        public void SetCard(Card card)
        {
            _card = card;
        }

        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }
        
        public Card GetCard()
        {
            return _card;
        }
    
        public int GetQuantity()
        {
            return _quantity;
        }
        
    }
}
