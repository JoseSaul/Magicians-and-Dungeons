using Character;
using TMPro;
using UnityEngine;

namespace Cards.Enchantment
{
    public class CardEnchantment : Card
    {

        [SerializeField] private TextMeshPro costMeshCard;
        [SerializeField] private TextMeshPro textCard;
        [SerializeField] private GameObject aura;
        [SerializeField] private string cardText;
        
        
        private void Start()
        {
            typeCard = 2;
            textCard.text = cardText;
            costMeshCard.text = manaCost + "";
        }
        
        public override void PlayCard()
        { 
            FindObjectOfType<PlayerController>().CardAnimation("Magic");
                
            Debug.Log("Aura");
        }
        
        
    }
}
