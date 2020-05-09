using System.Collections;
using UnityEngine;

namespace Character.Hand
{
    public class Hand : MonoBehaviour
    {
    
        [SerializeField] private CardSpace[] cardSpaces;
        private readonly bool[] _space = new[] {true, true, true};
        private Deck _deck;
        private int _rechargeCard;

        private void Start()
        {
            GameInstance gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();
            _deck = gameInstance.GetDeck();
            _rechargeCard = gameInstance.GetRechargeCard();

            //Quitar cuando tenga trigger al entrar en combate:
            StartCoroutine(InitHand());
        }

    
        public IEnumerator InitHand()
        {
            yield return new WaitForSeconds(0.1f);
        
            cardSpaces[0].AddCardToSpace(_deck.GetCard());
            _space[0] = false;
            cardSpaces[1].AddCardToSpace(_deck.GetCard());
            _space[1] = false;
            cardSpaces[2].AddCardToSpace(_deck.GetCard());
            _space[2] = false;
        }

    
        private IEnumerator AddCardToSpace(int space)
        {
            yield return new WaitForSeconds(_rechargeCard);
        
            if (_space[space])
            {
                cardSpaces[space].AddCardToSpace(_deck.GetCard());
                _space[space] = false;
            }
        }
    

        public void DrawCard(int space)
        {
            _space[space] = true;
            StartCoroutine(AddCardToSpace(space));
        }


        public void ExtraDraw(int nDraws)
        {
            for (int i = 0; i < _space.Length; i++)
            {
                if (nDraws > 0)
                {
                    if (_space[i])
                    {
                        cardSpaces[2].AddCardToSpace(_deck.GetCard());
                        _space[2] = false;
                        nDraws--;
                    }
                }
            }
        }
    
    
    
    }
}
