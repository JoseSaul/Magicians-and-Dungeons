using System;
using Cards;
using UnityEngine;

namespace Character.Hand
{
    public class CardSpace : MonoBehaviour
    {
        private Card _card;
        private bool _available = true;
        

        public void AddCardToSpace(Card card)
        {
            _card = Instantiate(card, transform.position, Quaternion.Euler(-45,0,0),transform);
            _available = false;
        }

        public void PlayCard()
        {
            if (!_card.Equals(null) && FindObjectOfType<PlayerController>().GetCanMove() && !Time.timeScale.Equals(0))
            {
                GameInstance gameInstance = FindObjectOfType<GameInstance>();
                if (gameInstance.GetMana() >= _card.GetManaCost())
                {
                    gameInstance.ConsumeMana(_card.GetManaCost());
                
                    _card.PlayCard();
                    Destroy(_card.gameObject);
                    _available = true;
                    FindObjectOfType<Hand>().DrawCard(this);
                }
            }
        }


        public void DeleteCard()
        {
            try
            {
                if (_available == false)
                {
                    Destroy(_card.gameObject);
                }
            }
            catch (NullReferenceException)
            {
                
            }
            _available = true;
        }


        public bool GetAvailable()
        {
            return _available;
        }
        
    
    
    }
}
