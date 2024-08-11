using Assets.Codebase.Mechanics.LifeSystem;
using Assets.Codebase.Mechanics.MoveSystem;
using Assets.Codebase.Path2D;
using UnityEngine;

namespace Assets.Codebase.Mechanics.ControllSystem
{
    [RequireComponent(typeof(Walk))]
    [RequireComponent(typeof(WalkerAbstraction))]
    public class AI : MonoBehaviour, IControllable
    {
        [SerializeField]
        private Transform _playerTransform;

        [SerializeField]
        private float _heightTolerancy;

        private void Update()
        {
            GetComponent<WalkerAbstraction>().enabled = (_playerTransform.position - transform.position).y > _heightTolerancy;
            if ((_playerTransform.position - transform.position).y<_heightTolerancy)
                ControllMove(_playerTransform.position - transform.position);
        }

        public void ControllMove(Vector2 direction)
        {
            GetComponent<SpriteRenderer>().flipX = direction.x < 0;
            GetComponent<Walk>().Turn((direction).normalized);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                collision.GetComponent<ILife>()?.Die();
        }

        public void SetPlayerTransform(Transform playerTranform)
        {
            _playerTransform = playerTranform;
        }
    }
}
    
