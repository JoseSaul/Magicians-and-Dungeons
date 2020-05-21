using Boo.Lang;
using Cards;
using Character.UI;
using DeckBuilder;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    private static GameInstance Instance { get; set; }
    private UiController _uiController;
    
    [SerializeField] private Deck deck;
    [SerializeField] private Card[] allCards;
    private Collection[] _collectionCard;
    private int _lv = 1, _exp, _maxExp = 10, _maxLife = 10, _life, _maxMana = 10, _mana;
    private float _rechargeCard = 3, _recoverMana = 4f, _manaCoolDown;



    private void Start()
    {
        _uiController = FindObjectOfType<UiController>();
        _manaCoolDown = _recoverMana;
        _life = _maxLife;
        _mana = _maxMana;
        
        InitCollection();
    }

    private void Update()
    {
        CheckMana();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void InitUi()
    {
        _life = _maxLife;
        _mana = _maxMana;
    }

    public Deck GetDeck()
    {
        return deck;
    }

    public int GetMaxLife()
    {
        return _maxLife;
    }

    public int GetMaxMana()
    {
        return _maxMana;
    }

    public int GetMaxExp()
    {
        return _maxExp;
    }

    public int GetLv()
    {
        return _lv;
    }
    
    public int GetMana()
    {
        return _mana;
    }

    public void ConsumeMana(int consume)
    {
        _mana -= consume;
        FindObjectOfType<UiController>().SetMana(_mana);
    }
    
    public int GetTotalMana()
    {
        return _maxMana;
    }

    private void CheckMana()
    {
        if (_maxMana > _mana)
        {
            if (_manaCoolDown > 0)
            {
                _manaCoolDown -= Time.deltaTime;
            }
            else
            {
                _mana++;
                _uiController.SetMana(_mana);
                _manaCoolDown = _recoverMana;
            }
        }
    }

    public float GetRechargeCard()
    {
        return _rechargeCard;
    }

    public float GetRecoverMana()
    {
        return _recoverMana;
    }

    public List<Collection> GetObtainedCard()
    {
        var collectionList = new List<Collection>();
        foreach (var cardCollected in _collectionCard)
        {
            collectionList.Add(cardCollected);
        }
        
        return collectionList;
    }

    private void InitCollection()
    {
        _collectionCard = new Collection[allCards.Length];
        
        for (var i = 0; i < _collectionCard.Length; i++)
        {
            // ReSharper disable once Unity.IncorrectMonoBehaviourInstantiation
            _collectionCard[i] = new Collection(allCards[i],0);
        }
        
        //Cambiar por las que quieras.......................................................
        _collectionCard[0].SetQuantity(4);
        _collectionCard[1].SetQuantity(2);
        _collectionCard[2].SetQuantity(1);
        
    }
    
    
}
