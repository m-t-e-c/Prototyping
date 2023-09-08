using FishingIdle.Managers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace FishingIdle
{
    public class TreeZone : MonoBehaviour
    {
        [SerializeField] int _durability = 10;
        public bool isChopped = false;

        IPlayerManager _playerManager;

        const string LogAddressableKey = "TreeLog";

        void Start()
        {
            _playerManager = Locator.Instance.Resolve<IPlayerManager>();
        }

        public void GetDamage(int damage)
        {
            _durability -= damage;
            if (_durability <= 0)
            {
                Chopped();
            }
            DropTreeLog();
        }

        void DropTreeLog()
        {
            float radius = 5f; 
            float angle = Random.Range(0f, 360f); 
            float x = transform.position.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            float z = transform.position.z + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            
            Addressables.LoadAssetAsync<GameObject>(LogAddressableKey).Completed += (result) =>
            {
                Vector3 spawnPos = new Vector3(x, 1, z);
                Instantiate(result.Result, spawnPos, Quaternion.identity);
            };

        }
        
        public void Chopped()
        {
            Debug.Log("Tree Chopped Down");
            isChopped = true;
        }
        
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _playerManager.ChangePlayerState(PlayerStateType.CHOPPING);
                // TODO Show UI
            }
        }
        
        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _playerManager.ChangePlayerState(PlayerStateType.NONE);
                // TODO Hide UI
            }
        }
    }
}