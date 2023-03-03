using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class Nlo : Enemy
    {
        private readonly float _speed;

        private int _army;
        
        public bool IsDead = false;

        public Nlo(Vector2 position, float speed) : base(position, 0)
        {
            Debug.Log(position);

            Destroying += OnDestroy;

            _speed = speed;

            _army = NloArmyManager.AddNlo(this);

            Debug.Log(_army);
        }

        private void OnDestroy()
        {
            IsDead = true;
            NloArmyManager.UpdateArmies();
        }

        public override void Update(float deltaTime)
        {
            var target = NloArmyManager.GetTarget(_army);

            Vector2 nextPosition = Vector2.MoveTowards(Position, target.Position, _speed * deltaTime);
            MoveTo(nextPosition);
            LookAt(target.Position);

            if (Position == target.Position && _army != target.GetArmyNumber())
            {
                Destroy();
            }
        }

        public int GetArmyNumber()
        {
            return _army;
        }

        private void LookAt(Vector2 point)
        {
            Rotate(Vector2.SignedAngle(Quaternion.Euler(0, 0, Rotation) * Vector3.up, (Position - point)));
        }
    }
}
