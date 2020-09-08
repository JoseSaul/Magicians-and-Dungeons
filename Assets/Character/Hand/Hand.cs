using System.Collections;
using Cards;
using Cards.Enchantment.Auras;
using UnityEngine;

namespace Character.Hand
{
    public class Hand : MonoBehaviour
    {
    
        [SerializeField] private CardSpace[] cardSpaces;
        private Deck _deck;
        private float _rechargeCard;
        private bool _onBattle;

        private void Start()
        {
           var gameInstance = FindObjectOfType<GameInstance>();
           gameInstance.GetDeck().InitDeck();
            _deck = gameInstance.GetDeck();
            _rechargeCard = gameInstance.GetRechargeCard();
        }

    
        public IEnumerator InitHand()
        {
            yield return new WaitForSeconds(0.1f);
            _deck.InitDeck();
            
            for (int i = 0; i < 3; i++)
            {
                cardSpaces[i].AddCardToSpace(_deck.GetCard());
            }
        }
        
        public void RemoveHand()
        {
            cardSpaces[0].DeleteCard();
            cardSpaces[1].DeleteCard();
            cardSpaces[2].DeleteCard();
        }

    
        private IEnumerator AddCardToSpace(CardSpace space)
        {
            yield return new WaitForSeconds(_rechargeCard);
        
            if (space.GetAvailable() && _onBattle)
            {
                space.AddCardToSpace(_deck.GetCard());
            }
        }
    

        public void DrawCard(CardSpace space)
        {
            StartCoroutine(AddCardToSpace(space));
        }


        public void ExtraDraw(int nDraws)
        {
            for (int i = 0; i < cardSpaces.Length; i++)
            {
                if (nDraws > 0)
                {
                    if (cardSpaces[i].GetAvailable())
                    {
                        cardSpaces[i].AddCardToSpace(_deck.GetCard());
                        nDraws--;
                    }
                }
            }
        }


        public void SetOnBattle(bool battle)
        {
            _onBattle = battle;
        }

        public Card[] GetCardsOfHand()
        {
            var cards = new Card[3];

            for (var i = 0; i < 3; i++)
            {
                cards[i] = cardSpaces[i].GetCard();
            }

            return cards;
        }
    
    }
}
