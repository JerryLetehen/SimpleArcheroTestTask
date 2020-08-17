using System;

namespace Game
{
    public struct Health
    {
        public event Action OnHealthEnded;
        
        private int Value
        {
            get => health;
            set
            {
                health = value;
                if (health <= 0)
                {
                    OnHealthEnded?.Invoke();
                }
            }
        }
        
        private int health;

        public Health(uint health)
        {
            this.health = (int) health;
            OnHealthEnded = null;
        }

        public void Reduce()
        {
            Value--;
        }
    }
}