using System.Collections.Generic;

namespace Asteroids.Model
{
    public static class NloArmyManager
    {
        private static Queue<Nlo> _firstArmy = new Queue<Nlo>(),
                                  _secondArmy = new Queue<Nlo>();

        public static int AddNlo(Nlo nlo)
        {
            if (_firstArmy.Count <= _secondArmy.Count)
            {
                _firstArmy.Enqueue(nlo);
                return 1;
            }
            _secondArmy.Enqueue(nlo);
            return 2;
        }

        public static Nlo GetTarget(int armyNumber)
        {
            if(armyNumber == 1)
            {
                if (_secondArmy.Count > 0) return _secondArmy.Peek();
                else return _firstArmy.Peek();
            }
            else
            {
                if (_firstArmy.Count > 0) return _firstArmy.Peek();
                else return _secondArmy.Peek();
            }
        }

        public static void UpdateArmies() 
        {
            while (_firstArmy.Count > 0 && _firstArmy.Peek().IsDead) _firstArmy.Dequeue();
            while (_secondArmy.Count > 0 && _secondArmy.Peek().IsDead) _secondArmy.Dequeue();
        }
    }
}
