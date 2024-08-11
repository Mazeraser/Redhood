using Assets.Codebase.Mechanics.CameraHelper;
using Assets.Codebase.Mechanics.ControllSystem;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.Infrastructure.Factory
{
    public class EnemyFactory : MonoBehaviour, IFactory<GameObject>
    {
        [SerializeField]
        private GameObject _enemy;
        [SerializeField]
        private Transform _enemySpawn;

        [SerializeField]
        private float _spawnDelay=0;
        private float _timer; //can cut for play timer
        
        private GameObject _currentItem;
        public GameObject CurrentItem { get=>_currentItem; }

        public GameObject CreateItem()
        {
            return Instantiate(_enemy, _enemySpawn);
        }


        [Inject]
        private void Construct(IInterestable playerTranform)
        {
            _enemy.GetComponent<AI>().SetPlayerTransform(playerTranform.GetTransform);
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _spawnDelay && _currentItem==null) 
                _currentItem = CreateItem();
        }
    }
}
    
