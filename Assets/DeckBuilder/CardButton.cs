using Cards;
using TMPro;
using UnityEngine;

namespace DeckBuilder
{
    public class CardButton : MonoBehaviour
    {

        [SerializeField] private TextMeshPro copiesText;
        private Collection _card;


        public void CreateCardButton(Collection cardCollection)
        {
            _card = cardCollection;
            copiesText.text = _card.GetQuantity() + "";
            Instantiate(_card.GetCard(), transform.position, Quaternion.Euler(-90,0,0),transform);
        }

        public void AddCard()
        {
            _card.SetQuantity(_card.GetQuantity() - 1);
            copiesText.text = _card.GetQuantity() + "";
            FindObjectOfType<CardsLocation>().UpdateCardButton(_card);
        }

        public void DestroyCardButton()
        {
            Destroy(gameObject);
        }


    }
}
