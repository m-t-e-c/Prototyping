using FishingIdle.Models;
using UnityEngine;

namespace FishingIdle
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Joystick joystick;
        [SerializeField] CharacterController characterController;
        [SerializeField] float speed;
        
        PlayerModel _model;

        void Start()
        {
            _model = new PlayerModel();
        }

        void Update()
        {
            Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical) * speed;
            characterController.Move(moveVector * Time.deltaTime);
        }
        
        void OnDestroy()
        {
           _model.Dispose();
        }
    }
}