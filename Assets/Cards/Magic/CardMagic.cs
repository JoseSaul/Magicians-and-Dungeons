using Character;
using UnityEngine;

namespace Cards.Magic
{
    public class CardMagic : Card
    {

        [SerializeField] private TextMesh costMeshCard;
        [SerializeField] private int magicalPower;
        private int _bonusPower;
        


        private void Start()
        {
            TypeCard = 1;
            textMeshCard.text = (magicalPower + _bonusPower) + " Magical Damage";
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
