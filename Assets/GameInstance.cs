using Boo.Lang;
using Cards;
using Character.UI;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    private static GameInstance Instance { get; set; }
    private UiController _uiController;
    
    [SerializeField] private Deck deck;
    [SerializeField] private Card[] allCards;
    private CardCollection[] _collectionCard;
    private int _lv = 1, _exp, _maxExp = 10, _maxLife = 10, _life, _maxMana = 10, _mana;
    private float _rechargeCard = 3, _recoverMana = 4f, _manaCoolDown;
    
    //Settings
    private bool _eng = true;



    private void Start()
    {
        _manaCoolDown = _recoverMana;
        _life = _maxLife;
        _mana = _maxMana;
        
        InitCollection();
    }

    public void OnStartGame()
    {
        _uiController = FindObjectOfType<UiController>();
        InitUi();
        _uiController.SetMaxHealth(GetMaxLife());
        _uiController.SetMaxMana(GetMaxMana());
        _uiController.SetMaxExp(GetMaxExp());
        _uiController.SetLv(GetLv());
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

    public string Language(string eng, string spa)
    {
        return _eng ? eng : spa;
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

    public List<CardCollection> GetObtainedCard()
    {
        var collectionList = new List<CardCollection>();
        foreach (var cardCollected in _collectionCard)
        {
            collectionList.Add(cardCollected);
        }
        
        return collectionList;
    }
    
    public List<CardCollection> GetDeckAsCollection()
    {
        var deckCollection = new List<CardCollection>();
        var auxDeck = deck.GetDeck();
        foreach (var card in auxDeck)
        {
            if (card != null)
            {
                var selectedCard = card;
                int count = 0;

                for (int i = 0; i < auxDeck.Length; i++)
                {
                    if (auxDeck[i] == selectedCard)
                    {
                        count++;
                        auxDeck[i] = null;
                    }
                }

                deckCollection.Add(new CardCollection(selectedCard, count));
            }
        }
        return deckCollection;
    }

    public void SetDeck(CardCollection[] cardCollections)
    {
        var deckList = new List<Card>();
        foreach (var collection in cardCollections)
        {
            for (var i = 0; i < collection.GetQuantity(); i++)
            {
                deckList.Add(collection.GetCard());
            }
        }
        deck.SetDeck(deckList.ToArray());
    }

    public void SetCollection(CardCollection[] _collectionCard)
    {
        this._collectionCard = _collectionCard;
    }

        private void InitCollection()
    {
        _collectionCard = new CardCollection[allCards.Length];
        
        for (var i = 0; i < _collectionCard.Length; i++)
        {
            // ReSharper disable once Unity.IncorrectMonoBehaviourInstantiation
            _collectionCard[i] = new CardCollection(allCards[i],0);
        }
        
        //Cambiar por las que quieras.......................................................
        _collectionCard[0].SetQuantity(4);
        _collectionCard[1].SetQuantity(2);
        _collectionCard[2].SetQuantity(1);
        
    }
    
    
}
