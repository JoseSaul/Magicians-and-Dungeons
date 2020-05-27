using Cards;
using TMPro;
using UnityEngine;

namespace DeckBuilder
{
    public class CardButton : MonoBehaviour
    {
        [SerializeField] private TextMeshPro copiesText;
        [SerializeField] private bool isDeck;
        private CardCollection _card;


        public void CreateCardButton(CardCollection cardCardCollection)
        {
            _card = cardCardCollection;
            copiesText.text = _card.GetQuantity() + "";
            Instantiate(_card.GetCard(), transform.position, Quaternion.Euler(-90,0,0),transform);
        }

        public void AddCard()
        {
            _card.SetQuantity(_card.GetQuantity() - 1);
            copiesText.text = _card.GetQuantity() + "";

            if (isDeck)
            {
                FindObjectOfType<DeckLocation>().UpdateCardButton(_card);
                FindObjectOfType<CardsLocation>().AddCard(_card);
            }
            else
            {
                FindObjectOfType<CardsLocation>().UpdateCardButton(_card);
                FindObjectOfType<DeckLocation>().AddCard(_card);
            }
            
        }

        public void DestroyCardButton()
        {
            Destroy(gameObject);
        }


    }
}
