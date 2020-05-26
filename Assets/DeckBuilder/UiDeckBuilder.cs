using UnityEngine;
using UnityEngine.UI;

namespace DeckBuilder
{
    public class UiDeckBuilder : MonoBehaviour
    {
        [SerializeField] private Slider sliderCards;
        [SerializeField] private CardsLocation cardsLocation;

        public void UpdateSizeSliderCards(float size)
        {
            sliderCards.maxValue = size;
            sliderCards.value = 0;
        }

        public void MoveCards(float value)
        {
            var trans = cardsLocation.transform;
            var pos = trans.position;
            pos.x = -value;
            trans.position = pos;
        }
    
    

    }
}
