using Cards;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DeckBuilder
{
    public class CardButton : MonoBehaviour
    {

        [SerializeField] private TextMeshPro copiesText;
        private int _copies;
        private Card _card;


        public void CreateCardButton(Card card, int numberCopies)
        {
            _card = card;
            _copies = numberCopies;
            copiesText.text = _copies + "";
            Instantiate(card, transform.position, Quaternion.Euler(-90,0,0),transform);
        }

        public void AddCard()
        {
            print("añado");
            _copies--;
            copiesText.text = _copies + "";
            if (_copies <= 0)
            {
                Destroy(gameObject);
            }
        }
    
    
    }
}
