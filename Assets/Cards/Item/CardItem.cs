using Character;
using TMPro;
using UnityEngine;

namespace Cards.Item
{
    public class CardItem : Card
    {
        [SerializeField] private int health, mana;
        
        private void Start()
        {
            textMeshCard.text = "";
            var gi = FindObjectOfType<GameInstance>();
            
            if (health > 0)
            {
                textMeshCard.text += "+ " + health + gi.Language(" Health"," Vida");
            }

            if (mana > 0)
            {
                textMeshCard.text += "+ " + mana + " Mana";
            }
            
        }

        public override void PlayCard()
        { 
            FindObjectOfType<PlayerController>().CardAnimation("Object");

            var gi = FindObjectOfType<GameInstance>();
            gi.GetLife().Cure(health);
            gi.GetMana().RestoreMana(mana);
        }
        
    }
}
