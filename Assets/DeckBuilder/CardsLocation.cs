using Boo.Lang;
using Cards;
using TreeEditor;
using UnityEngine;

namespace DeckBuilder
{
    public class CardsLocation : MonoBehaviour
    {
       [SerializeField] private CardButton cardButton;
        private Collection[] _availableCards;
        private List<CardButton> _cardButtonList;
        private  const float CardsDistance = 0.5f;
        
        
        void Start()
        {
            _cardButtonList = new List<CardButton>();
            //_availableCards = FindObjectOfType<GameInstance>().GetObtainedCard();

            //SetAllCards();
        }

        public void DebugStart()
        {
            _availableCards = FindObjectOfType<GameInstance>().GetObtainedCard();
            
            SetAllCards();
        }

        private void SetAllCards()
        {
            float positionX = 0;
            
            foreach (var card in _availableCards)
            {
                var position = transform.position;

                var clone = Instantiate(cardButton, new Vector3(positionX, position.y, position.z),
                    Quaternion.Euler(-90, 0, 0), cardButton.transform);

                clone.transform.parent = transform.parent;
                clone.CreateCardButton(card.GetCard(), card.GetQuantity());
                
                
                positionX += CardsDistance;
            }
        }

        
    }
}
