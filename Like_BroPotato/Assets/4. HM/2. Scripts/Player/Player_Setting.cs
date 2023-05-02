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

        [Space(5f),Header("## Invincible Time ##"), SerializeField] 
        protected float invincibilityTime = 2f; // 무적 시간
        
        [SerializeField]private bool isDead;
        [SerializeField]private bool isHitting;

        private PlayerMove playermove;

        public int _DebugInt;
        
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

                    playermove.enabled = false;
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
        // 최대 체력 변동이 있을 때 발생하는 이벤트
        public event Action OnChangeHealth;
        // 죽었을 때 발생하는 이벤트
        public event Action OnDead;

        #endregion
        
        protected void OnEnable()
        {
            CurrentHp = MaxHp;
            isDead = false;

            playermove = this.GetComponent<PlayerMove>();
            playermove.enabled = true;
        }

        private void Awake()
        {
            CurrentHp = MaxHp;
            isDead = false;
        }

        private void PlayerTakeDamage(int amount)
        {
            // 데미지를 입었을 때 / 무적 판정 필요
            if (isHitting || isDead)
                return;
            
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

        private void PlayerTakeHeal(int amount)
        {
            // 힐을 했을 때
            CurrentHp += amount;

            // 힐 이펙트?
            if (!isDead)
                OnHealed?.Invoke();
        }

        private void PlayerIncreaseMaxHP(int amount)
        {
            MaxHp += amount;
            
            OnChangeHealth?.Invoke();
        }
        
        

        // ************* For Debug ************
        public void Damage_Btn()
        {
            PlayerTakeDamage(_DebugInt);
        }

        public void Heal_Btn()
        {
            PlayerTakeHeal(_DebugInt);
        }

        public void IncreaseHP_Btn()
        {
            PlayerIncreaseMaxHP(_DebugInt);
        }
  
    }
}