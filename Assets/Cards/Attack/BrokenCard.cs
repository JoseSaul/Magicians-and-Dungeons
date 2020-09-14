using Character;
using UnityEngine;

namespace Cards.Attack
{
    public class BrokenCard : Card
    {
        private const int Power = 1;

        void Start()
        {
            manaCost = 0;
            var gi = FindObjectOfType<GameInstance>();
            textMeshCard.text = (Power) + gi.Language(" Physical Damage and 2 to you", " Daño Físico y 2 a ti") ;
        }

        public override void PlayCard()
        {
            FindObjectOfType<PlayerController>().CardAnimation("Attack");
            FindObjectOfType<GameInstance>().ReceiveDamage(Power*2);
            
            Debug.Log("Ataco");
        }
        
        void Update()
        {
        
        }
        
    }
}
