using Character.UI;
using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private Joystick joystick;
        [SerializeField] private GameObject character;
        [SerializeField] private UiController uiController;

        private CharacterController _player;
        private Animator _anim;
        private GameInstance _gameInstance;
        
        private bool _canMove = true;
        private float _moveForward, _moveLateral;
        private const float  Speed = 3, RotationSpeed = 300f;
        private Vector3 _moveDirection = Vector3.zero;
        private static readonly int Walk = Animator.StringToHash("Walk");


        private void Start()
        {
            _player = GetComponent<CharacterController>();
            _anim = GetComponent<Animator>();
            _gameInstance = FindObjectOfType<GameInstance>();
            
            _gameInstance.InitUi();
            uiController.SetMaxHealth(_gameInstance.GetMaxLife());
            uiController.SetMaxMana(_gameInstance.GetMaxMana());
            uiController.SetMaxExp(_gameInstance.GetMaxExp());
            uiController.SetLv(_gameInstance.GetLv());
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            
            if (_canMove)
            {
                _moveForward = joystick.Horizontal;
                _moveLateral = joystick.Vertical;
            }
            else
            {
                _moveForward = 0f;
                _moveLateral = 0f;
            }
            
            _player.Move(new Vector3(_moveForward,0,_moveLateral) * (Speed * Time.deltaTime));

            if (!_moveForward.Equals(0f) || !_moveLateral.Equals(0f))
            {
                _anim.SetBool(Walk,true);
                _moveDirection = new Vector3 (_moveForward, 0, _moveLateral);
                
                character.transform.rotation = Quaternion.RotateTowards (character.transform.rotation, 
                    Quaternion.LookRotation (_moveDirection), RotationSpeed * Time.deltaTime);
            }
            else
            {
                _anim.SetBool(Walk,false);
            }
        }


        public void CardAnimation(string anim)
        {
            _canMove = false;
            _anim.SetTrigger(anim);
        }

        
        public void RestartMovement()
        {
            _canMove = true;
        }


        public bool GetCanMove()
        {
            return _canMove;
        }
        


    }
}
