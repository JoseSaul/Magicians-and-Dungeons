using Character;
using TMPro;
using UnityEngine;

namespace Cards.Enchantment
{
    public class CardEnchantment : Card
    {

        [SerializeField] private TextMeshPro costMeshCard;
        [SerializeField] private GameObject aura;
        [SerializeField] private string cardTextEn, cardTextSp;
        
        
        private void Start()
        {
            typeCard = 2;
            var gi = FindObjectOfType<GameInstance>();
            textMeshCard.text = gi.Language(cardTextEn,cardTextSp);
            costMeshCard.text = manaCost + "";
        }
        
        public override void PlayCard()
        { 
            FindObjectOfType<PlayerController>().CardAnimation("Aura");
                
            Instantiate(aura, new Vector3(0, 0, 0), Quaternion.identity);
            Debug.Log("Aura");
        }
        
        
    }
}
