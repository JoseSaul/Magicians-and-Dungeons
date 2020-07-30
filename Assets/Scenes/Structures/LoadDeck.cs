using Character.Hand;
using UnityEngine;

namespace Scenes.Structures
{
    public class LoadDeck : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var hand = FindObjectOfType<Hand>();
            hand.SetOnBattle(true);
            StartCoroutine(hand.InitHand());
        }

        private void OnTriggerExit(Collider other)
        {
            var hand = FindObjectOfType<Hand>();
            hand.SetOnBattle(false);
            hand.RemoveHand();
        }
    }
}
