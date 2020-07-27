using System.Linq;
using System.Security.Cryptography;
using Boo.Lang;
using Cards;
using TreeEditor;
using UnityEngine;

namespace DeckBuilder
{
    public class CardsLocation : MonoBehaviour
    {
       [SerializeField] private CardButton cardButton;
        private List<CardCollection> _collection;
        private List<CardButton> _cardButtonList;
        private  const float CardsDistance = 0.42f;
        private static Vector3 _initPosition;


        private void Start()
        {
            _cardButtonList = new List<CardButton>();
            //_collection = FindObjectOfType<UiDeckBuilder>().GetCollections();
            InitCards(FindObjectOfType<UiDeckBuilder>().GetCollections());
            _initPosition = gameObject.transform.position;
            ShowAllCards();
        }

        private void InitCards(List<CardCollection> collection)
        {
            _collection = new List<CardCollection>();
            foreach (var card in collection)
            {
                _collection.Add(new CardCollection(card.GetCard(),card.GetQuantity()));
            }
        }

        private void ShowAllCards()
        {
            gameObject.transform.position = _initPosition;
            float positionX = 0;
            var position = transform.position;

            foreach (var card in _collection)
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
            FindObjectOfType<UiDeckBuilder>().UpdateSizeSliderCards(positionX - CardsDistance);
        }

        public void ShowCardsOfType(string type)
        {
            int min = 0, max = 0;
            float positionX = 0;
            var position = transform.position;

            if (type.Equals("Attack"))
            {
                min = 0;
                max = 10;
            }

            if (type.Equals("Magic"))
            {
                min = 10;
                max = 20;
            }
            
            if (type.Equals("Object"))
            {
                min = 0;
                max = 10;
            }

            if (type.Equals("Aura"))
            {
                min = 0;
                max = 10;
            }
            
            foreach (var card in _collection)
            {
                if (card.GetQuantity() > 0 && card.GetCard().GetId() > min && card.GetCard().GetId() < max)
                {
                    var clone = Instantiate(cardButton, new Vector3(positionX, position.y, position.z),
                        Quaternion.Euler(-90, 0, 0), cardButton.transform);

                    clone.transform.parent = transform.parent;
                    clone.CreateCardButton(card);
                    _cardButtonList.Add(clone);
                
                    positionX += CardsDistance;
                }
            }      
        }

        public void UpdateCardButton(CardCollection cardCollection)
        {
            foreach (var c in _collection)
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
            foreach (var c in _collection)
            {
                if (c.GetCard().GetId() == cardCollection.GetCard().GetId())
                {
                    c.SetQuantity(c.GetQuantity() + 1);
                }
                
                foreach (var cardB in _cardButtonList)
                {
                    cardB.DestroyCardButton();
                }

                _cardButtonList.Clear();
                ShowAllCards();
            }
        }

        public CardCollection[] GetCollection()
        {
            return _collection.ToArray();
        }

        
    }
}
