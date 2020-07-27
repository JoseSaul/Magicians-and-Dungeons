
using Boo.Lang;
using Cards;
using UnityEngine;

namespace DeckBuilder
{
    public class DeckLocation : MonoBehaviour
    {
        [SerializeField] private CardButton cardButton;
        private List<CardButton> _cardButtonList;
        private  const float CardsDistance = 0.42f;
        private static Vector3 _initPosition;
        private List<CardCollection> _deckCollection;

        private void Start()
        {
            _cardButtonList = new List<CardButton>();
            
            InitCards(FindObjectOfType<UiDeckBuilder>().GetDeckCollections());
            _initPosition = gameObject.transform.position;
            ShowAllCards();
        }
        
        private void InitCards(List<CardCollection> collection)
        {
            _deckCollection = new List<CardCollection>();
            foreach (var card in collection)
            {
                _deckCollection.Add(new CardCollection(card.GetCard(),card.GetQuantity()));
            }
        }
        
        private void ShowAllCards()
        {
            gameObject.transform.position = _initPosition;
            float positionX = 0;
            var position = transform.position;

            foreach (var card in _deckCollection)
            {
                if (card.GetQuantity() > 0)
                {
                    var clone = Instantiate(cardButton, new Vector3(positionX, position.y, position.z),
                        Quaternion.Euler(-90, 0, 0), cardButton.transform);
                       

                    clone.transform.parent = transform.parent;
                    clone.transform.SetParent(gameObject.transform);
                    clone.CreateCardButton(card);
                    _cardButtonList.Add(clone);
                
                    positionX += CardsDistance;
                }
            }
            FindObjectOfType<UiDeckBuilder>().UpdateSizeSliderDeck(positionX - CardsDistance);
        }
        
        public void UpdateCardButton(CardCollection cardCollection)
        {
            foreach (var c in _deckCollection)
            {
                if (c.GetCard().GetId() == cardCollection.GetCard().GetId())
                {
                    c.SetQuantity(cardCollection.GetQuantity());
                }
            }

            if (cardCollection.GetQuantity() <= 0)
            {
                foreach (var cardB in _cardButtonList)
                {
                    cardB.DestroyCardButton();
                }

                _cardButtonList.Clear();
                ShowAllCards();
            }
        }
        
        public void AddCard(CardCollection cardCollection)
        {
            var exist = false;
            foreach (var c in _deckCollection)
            {
                if (c.GetCard().GetId() == cardCollection.GetCard().GetId())
                {
                    c.SetQuantity(c.GetQuantity() + 1);
                    exist = true;
                }
            }

            if (!exist)
            {
                _deckCollection.Add(new CardCollection(cardCollection.GetCard(),1));
            }
            
            foreach (var cardB in _cardButtonList)
            {
                cardB.DestroyCardButton();
            }

            _cardButtonList.Clear();
            ShowAllCards();
        }

        public CardCollection[] GetDeckList()
        {
            return _deckCollection.ToArray();
        }
        
        
    }
}
