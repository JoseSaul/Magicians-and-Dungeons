using System.Collections;
using Cards;
using UnityEngine;

namespace Character.Hand
{
    public class Hand : MonoBehaviour
    {
    
        [SerializeField] private CardSpace[] cardSpaces;
        private Deck _deck;
        private float _rechargeCard;

        private void Start()
        {
           var gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();
            _deck = gameInstance.GetDeck();
            _rechargeCard = gameInstance.GetRechargeCard();

            //Quitar cuando tenga trigger al entrar en combate:
            StartCoroutine(InitHand());
        }

    
        public IEnumerator InitHand()
        {
            yield return new WaitForSeconds(0.1f);

            for (int i = 0; i < 3; i++)
            {
                cardSpaces[i].DeleteCard();
                cardSpaces[i].AddCardToSpace(_deck.GetCard());
            }
            
        }

    
        private IEnumerator AddCardToSpace(CardSpace space)
        {
            yield return new WaitForSeconds(_rechargeCard);
        
            if (space.GetAvailable())
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
    
    
    
    }
}
