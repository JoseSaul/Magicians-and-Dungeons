using UnityEngine;

namespace DeckBuilder
{
    public class TriggerCard : MonoBehaviour
    {

        [SerializeField] private CardButton cardButton;
    
        private void OnMouseDown()
        {
            cardButton.AddCard();
        }
    
    }
}
