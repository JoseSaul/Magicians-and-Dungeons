using Cards.Enchantment.Auras;
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
        [SerializeField] private int boost;
        
        
        private void Start()
        {
            var gi = FindObjectOfType<GameInstance>();
            textMeshCard.text = gi.Language(cardTextEn,cardTextSp);
            costMeshCard.text = manaCost + "";
        }
        
        public override void PlayCard()
        { 
            FindObjectOfType<PlayerController>().CardAnimation("Aura");
            
            var auraObject = Instantiate(aura, new Vector3(0, 0, 0), Quaternion.identity);
            auraObject.GetComponent<Aura>().SetBoost(boost);
        }
        
        
    }
}
