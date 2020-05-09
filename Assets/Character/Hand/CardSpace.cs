using System;
using Cards;
using UnityEngine;
using UnityEngine.UIElements;

namespace Character.Hand
{
    public class CardSpace : MonoBehaviour
    {
    
        [SerializeField] private Hand hand;
        [SerializeField] private int id;
        private Card _card;
        

        public void AddCardToSpace(Card card)
        {
            _card = Instantiate(card, transform.position, Quaternion.Euler(-45,0,0),transform);
        }

        public void PlayCard()
        {
            if (!_card.Equals(null) && FindObjectOfType<PlayerController>().GetCanMove())
            {
                GameInstance gameInstance = FindObjectOfType<GameInstance>();
                if (gameInstance.GetMana() >= _card.GetManaCost())
                {
                    gameInstance.ConsumeMana(_card.GetManaCost());
                
                    _card.PlayCard();
                    Destroy(_card.gameObject);
                    hand.DrawCard(id);
                }
            
            }
        }
        
    
    
    }
}
