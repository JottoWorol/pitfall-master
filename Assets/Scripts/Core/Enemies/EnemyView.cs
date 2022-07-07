using UnityEngine;

namespace Core.Enemies
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        public Rigidbody Rigidbody => _rigidbody;
    }
}