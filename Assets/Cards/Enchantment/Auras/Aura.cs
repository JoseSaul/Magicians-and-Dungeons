using Character.Hand;
using UnityEngine;

namespace Cards.Enchantment.Auras
{
    public class Aura : MonoBehaviour
    {
        protected int boost;
        
        private void Start()
        {
            var card = FindObjectOfType<Hand>().GetCardsOfHand();

            if (card == null) return;
            foreach (var selected in card)
            {
                TriggerAura(selected);
            }

        }

        public virtual void TriggerAura(Card card)
        {
            
        }

        public void SetBoost(int booster)
        {
            boost = booster;
        }
        
    }
}
