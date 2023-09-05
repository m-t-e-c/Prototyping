using System.Collections.Generic;
using System.Linq;
using FishingIdle.Managers;
using FishingIdle.Models;
using UnityEngine;

namespace FishingIdle
{
    public class PlayerBehaviour : MonoBehaviour
    {
        readonly List<PlayerActionState> _playerActionStates = new();
        
        [SerializeField] CharacterController characterController;
        [SerializeField] PlayerStateType currentStateType;
        [SerializeField] float speed;
        
        Joystick _joystick;
        PlayerModel _model;

        PlayerActionState _currentState;

        IPlayerManager _playerManager;
        
        public void Init(Joystick joystick)
        {
            _playerManager = Locator.Instance.Resolve<IPlayerManager>();
            _playerManager.OnPlayerStateChanged += OnPlayerStateChanged;
            
            _model = new PlayerModel();
            _joystick = joystick;

            GetPlayerActionStates();
        }

        void OnPlayerStateChanged(object sender, PlayerStateType stateType)
        {
            currentStateType = stateType;
        }

        void GetPlayerActionStates()
        {
            var playerActionStates = GetComponents<PlayerActionState>();
            foreach (PlayerActionState actionState in playerActionStates)
            {
                _playerActionStates.Add(actionState);
            }
        }

        void StateControl()
        {
            if (currentStateType.Equals(PlayerStateType.NONE))
            {
                return;
            }
            
            if (!ReferenceEquals(_currentState, null))
            {
                if (_currentState.playerStateType != currentStateType)
                {
                    _currentState.OnExitState();
                    _currentState = _playerActionStates.FirstOrDefault(state => state.playerStateType == currentStateType);
                    if (_currentState != null)
                    {
                        _currentState.OnEnterState();
                    }
                }
                currentStateType = _currentState.OnUpdateState();
            }
            else
            {
                foreach (PlayerActionState state in _playerActionStates)
                {
                    if (state.playerStateType.Equals(currentStateType))
                    {
                        _currentState = state;
                        currentStateType = _currentState.playerStateType;
                        _currentState.OnEnterState();
                    }
                }
            }
        }
        
        void Update()
        {
            StateControl();
            
            if (ReferenceEquals(_joystick, null))
            {
                return;
            }
            
            Vector3 moveVector = (Vector3.right * _joystick.Horizontal + Vector3.forward * _joystick.Vertical) * speed;
            characterController.Move(moveVector * Time.deltaTime);
        }

        void OnDestroy()
        {
           _model.Dispose();
        }
    }
}