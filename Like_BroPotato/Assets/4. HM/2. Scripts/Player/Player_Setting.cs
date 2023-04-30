using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace _4._HM._2._Scripts.Player
{
    public class Player_Setting : MonoBehaviour
    {
        [Header("## Player Status ##"), SerializeField] 
        protected int maxHp = 100;
        private int currentHp;
        private int sum_Damage = 0; // 내가 받은 모든 데미지
        private int sum_Healing = 0; // 내가 총 힐한 양
        private int sum_Kill = 0; // 내가 총 죽인 적 수

        [Range(0f,1f)]
        public float critical_HP_Ratio;
        
        [Space(5f),Header("## Invincible Time ##"), SerializeField] 
        protected float invincibilityTime = 2f; // 무적 시간
        
        private bool isDead;
        private bool isHitting;

        public int CurrentHp
        {
            get => currentHp;
            set
            {
                currentHp = value;

                if (currentHp <= 0)
                {
                    currentHp = 0;

                    if (!isDead)
                        isDead = true;

                    OnDead?.Invoke();
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

        #region ## Events

        // 데미지를 입었을 때 발생하는 이벤트
        public event Action OnDamaged;
        // 회복했을 떄 발생하는 이벤트
        public event Action OnHealed;
        // 죽었을 때 발생하는 이벤트
        public event Action OnDead;

        #endregion
        
        protected void OnEnable()
        {
            CurrentHp = MaxHp;
            isDead = false;
        }

        private void TakeDamage(int amount)
        {
            // 데미지를 입었을 때 / 무적 판정 필요
            if (isHitting || isDead)
                return;

            sum_Damage += amount;
            
            StartCoroutine(InvincibilityTime(amount));
        }
        // 무적 시간을 주기 위한 코루틴
        IEnumerator InvincibilityTime(int amount)
        {
            isHitting = true;
            CurrentHp -= amount;

            OnDamaged?.Invoke();

            yield return new WaitForSeconds(invincibilityTime);

            isHitting = false;
        }

        private void TakeHeal(int amount)
        {
            // 힐을 했을 때
            CurrentHp += amount;
            sum_Healing += amount;

            // 힐 이펙트?
            if (!isDead)
                OnHealed?.Invoke();
        }

        // ************* For Debug ************
        public void Damage_Btn()
        {
            TakeDamage(10);
        }

        public void Heal_Btn()
        {
            TakeHeal(10);
        }
    }
}