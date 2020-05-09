using Character.Hand;
using UnityEngine;

namespace Character.UI
{
    public class ButtonCard : MonoBehaviour
    {

        [SerializeField] private CardSpace cardSpace;
        
        public void PressButtonCard()
        {
            cardSpace.PlayCard();
        }

    }
}
