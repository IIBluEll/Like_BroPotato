using System;
using UnityEngine;

namespace _4._HM._2._Scripts.Player
{
    public class Player_Setting : MonoBehaviour
    {
        [SerializeField] protected int maxHp = 100;

        private int currentHp;
        private bool isDead = false;

        public int CurrentHp
        {
            get => currentHp;
            set
            {
                if (currentHp <= 0)
                {
                    currentHp = 0;

                    if (!isDead)
                        isDead = true;
                }
                else if (currentHp > maxHp)
                {
                    currentHp = maxHp;
                }
            }
        }

        public int MaxHp
        {
            get => maxHp;
            set
            {
                int changeHp = Mathf.Max(value - maxHp, 0);
                maxHp = value;
                currentHp += changeHp;

                Debug.Log($"{changeHp}만큼 체력 증가");
            }
        }

        public event Action<int> OnDamaged;
        
        protected virtual void OnEnable()
        {
            CurrentHp = MaxHp;
            isDead = false;
        }

        protected virtual void TakeDamage(int amount)
        {
            // 데미지를 입었을 때 
            CurrentHp -= amount;
            
            // 피격 이벤트?
            if (!isDead)
            {
                OnDamaged?.Invoke(amount);
            }
        }

        protected virtual void TakeHeal(int amount)
        {
            // 힐을 했을 때
            CurrentHp += amount;
            
            // 힐 이펙트?
        }
    }
}