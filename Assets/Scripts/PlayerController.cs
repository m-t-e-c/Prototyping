using FishingIdle.Models;
using UnityEngine;

namespace FishingIdle
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] CharacterController characterController;
        [SerializeField] float speed;
        
        Joystick _joystick;
        PlayerModel _model;

        public void Init(Joystick joystick)
        {
            _model = new PlayerModel();
            _joystick = joystick;
        }

        void Update()
        {
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