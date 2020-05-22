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
        private List<Collection> _collection;
        private List<CardButton> _cardButtonList;
        private  const float CardsDistance = 0.5f;


        private void Start()
        {
            _cardButtonList = new List<CardButton>();
            _collection = FindObjectOfType<GameInstance>().GetObtainedCard();
            ShowAllCards();
        }

        private void ShowAllCards()
        {
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

        public void UpdateCardButton(Collection collection)
        {
            foreach (var c in _collection)
            {
                if (c.GetCard().GetId() == collection.GetCard().GetId())
                {
                    c.SetQuantity(collection.GetQuantity());
                }
            }

            if (collection.GetQuantity() <= 0)
            {
                foreach (var cardB in _cardButtonList)
                {
                   cardB.DestroyCardButton();
                }

                _cardButtonList.Clear();
                ShowAllCards();
            }
        }

        
    }
}
