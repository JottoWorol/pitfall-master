using UnityEngine;

namespace Core
{
    public class GizmoBall : MonoBehaviour
    {
        [SerializeField] private Color _color;
        [SerializeField] private float _radius;

        private void OnDrawGizmos()
        {
            Gizmos.color = _color;
            Gizmos.DrawSphere(transform.position, _radius);
        }
    }
}