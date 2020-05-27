using UnityEngine;
using UnityEngine.UI;

namespace DeckBuilder
{
    public class UiDeckBuilder : MonoBehaviour
    {
        [SerializeField] private Slider sliderCards, sliderDeck;
        [SerializeField] private CardsLocation cardsLocation;
        [SerializeField] private DeckLocation deckLocation;
        
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
    
        public void UpdateSizeSliderDeck(float size)
        {
            sliderDeck.maxValue = size;
            sliderDeck.value = 0;
        }

        public void MoveCardsDeck(float value)
        {
            var trans = deckLocation.transform;
            var pos = trans.position;
            pos.x = -value;
            trans.position = pos;
        }

        public void SaveDeck()
        {
            
        }

        public void ExitToMainMenu()
        {
            
        }
    

    }
}
