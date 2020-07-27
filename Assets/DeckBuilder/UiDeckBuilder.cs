using Boo.Lang;
using Cards;
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
        private List<CardCollection> _collection, _deckCollection, _deckAux;

        private void Start()
        {
            textCollection.SetText(FindObjectOfType<GameInstance>().Language("Collection","Colección"));
            textDeck.SetText(FindObjectOfType<GameInstance>().Language("Deck","Mazo"));
            _collection = FindObjectOfType<GameInstance>().GetObtainedCard();
            _deckCollection = FindObjectOfType<GameInstance>().GetDeckAsCollection();
            _deckAux = _deckCollection;
        }

        public List<CardCollection> GetCollections()
        {
            return _collection;
        }

        public List<CardCollection> GetDeckCollections()
        {
            return _deckCollection;
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
            gameInstance.SetDeck(deckLocation.GetDeckList());
            gameInstance.SetCollection(cardsLocation.GetCollection());
            //Save game.......................................................
            SceneManager.LoadScene("Scenes/MainMenu");

        }

        public void ExitToMainMenu()
        {
            FindObjectOfType<GameInstance>().SetDeck(_deckAux.ToArray());
            SceneManager.LoadScene("Scenes/MainMenu");
        }
    

    }
}
