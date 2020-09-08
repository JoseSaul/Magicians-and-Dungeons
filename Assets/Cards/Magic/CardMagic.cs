using Character;
using TMPro;
using UnityEngine;

namespace Cards.Magic
{
    public class CardMagic : Card
    {

        [SerializeField] private TextMeshPro costMeshCard;
        [SerializeField] private int magicalPower;
        private int _bonusPower;
        


        private void Start()
        {
            typeCard = 1;
            var gi = FindObjectOfType<GameInstance>();
            textMeshCard.text = (magicalPower + _bonusPower) + gi.Language(" Magical Damage", " Daño Mágico");
            costMeshCard.text = manaCost + "";
        }
        
        
        public override void PlayCard()
        { 
            FindObjectOfType<PlayerController>().CardAnimation("Magic");
                
            Debug.Log("Magia");
        }
        
        
        public void PlusBonusMagic(int bonus)
        { 
            _bonusPower += bonus;
            textMeshCard.text = (magicalPower + _bonusPower) + " Physical Damage";
        }
        
        
        public void QuitBonusMagic(int bonus)
        {
            _bonusPower -= bonus;
            textMeshCard.text = (magicalPower + _bonusPower) + " Physical Damage";
        }
        
        
    }
}
