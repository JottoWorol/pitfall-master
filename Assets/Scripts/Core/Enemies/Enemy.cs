using UnityEngine;

namespace Core.Enemies
{
    public class Enemy
    {
        public EnemyView View { get; private set; }
        
        public Enemy(EnemyView view)
        {
            View = view;
        }

        public Vector3 Position => View.transform.position;

        public void Destroy()
        {
            Object.Destroy(View.gameObject);
        }

        public void SetVelocity(Vector3 velocity)
        {
            View.Rigidbody.velocity = velocity;
            View.Rigidbody.rotation = Quaternion.LookRotation(velocity, Vector3.up);
        }
    }
}