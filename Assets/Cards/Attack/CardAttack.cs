using Character;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Cards.Attack
{
    public class CardAttack : Card
    {
        [SerializeField] private int power;
        private int _bonusPower;
        

        private void Start()
        {
            manaCost = 0;
            var gi = FindObjectOfType<GameInstance>();
            textMeshCard.text = (power + _bonusPower) + gi.Language(" Physical Damage", " Daño Físico");
        }

        public override void PlayCard()
        {
            FindObjectOfType<PlayerController>().CardAnimation("Attack");
            
            Debug.Log("Ataco");
        }

        
        public void PlusBonusAttack(int bonus)
        { 
            _bonusPower += bonus;
            textMeshCard.text = (power + _bonusPower) + " Physical Damage";
        }
        
        
        public void QuitBonusAttack(int bonus)
        {
            _bonusPower -= bonus;
            textMeshCard.text = (power + _bonusPower) + " Physical Damage";
        }
        
         

    }
}
