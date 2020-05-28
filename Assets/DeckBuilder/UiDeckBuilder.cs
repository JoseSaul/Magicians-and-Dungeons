using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DeckBuilder
{
    public class UiDeckBuilder : MonoBehaviour
    {
        [SerializeField] private Slider sliderCards, sliderDeck;
        [SerializeField] private CardsLocation cardsLocation;
        [SerializeField] private DeckLocation deckLocation;
        [SerializeField] private TextMeshProUGUI textCollection, textDeck;


        private void Start()
        {
            textCollection.SetText(FindObjectOfType<GameInstance>().Language("Collection","Colección"));
            textDeck.SetText(FindObjectOfType<GameInstance>().Language("Deck","Mazo"));
        }

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
            var gameInstance = FindObjectOfType<GameInstance>();
            gameInstance.SetDeck(deckLocation.GetDeckList().ToArray());
            gameInstance.SetCollection(cardsLocation.GetCollection());
            //Save game.......................................................
            SceneManager.LoadScene("Scenes/MainMenu");

        }

        public void ExitToMainMenu()
        {
            SceneManager.LoadScene("Scenes/MainMenu");
        }
    

    }
}
