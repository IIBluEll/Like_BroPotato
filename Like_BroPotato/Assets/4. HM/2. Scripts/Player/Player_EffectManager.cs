using System.Collections;
using UnityEngine;

namespace _4._HM._2._Scripts.Player
{
    /// <summary>
    /// 플레이어 관련된 이펙트를 관리하는 스크립트
    /// 1. 데미지를 받았을 때
    /// 2. 힐을 했을 때
    /// 3. HP가 일정 이하로 떨어졌을 때
    /// 4. 레벨업? 죽었을 때? 
    /// </summary>
    public class Player_EffectManager : MonoBehaviour
    {
        // 나중에 사운드로 쓰면 될듯
        // [SerializeField] private List<GameObject> Effects_Prefebs;
        //
        // [SerializeField] private List<string> Effects_Name;
        //
        // private Dictionary<string, GameObject> Effects_List = new Dictionary<string, GameObject>();


        [Header("## UI setting ##"), SerializeField]
        private GameObject warningText; //todo 나중에 바꿔야됨

        [Space(10f), Header(" ## Player Setting ##"), SerializeField]
        private Player_Setting player_setting;

        private SpriteRenderer playerSpriteR;

        [Range(0f, 1f)] public float critical_HP_Ratio;

        [Space(10f), Header("## Blink Status ## ")] [SerializeField]
        private float nowTime;

        [SerializeField] private float blinkDuration;
        [SerializeField] private float blinkTime;

        private bool isHitEffectPlay;

        private void Awake()
        {
            // // === 이펙트 정리 ====//
            // if (Effects_Prefebs.Count != Effects_Name.Count)
            // {
            //     Debug.LogWarning("Effects Counts Is Not Correct!! Check Effects!");
            //     return;
            // }
            //
            // for (int i = 0; i < Effects_Prefebs.Count; i++)
            // {
            //     Effects_List.Add(Effects_Name[i],Effects_Prefebs[i]);
            // }

            // === 이벤트 등록 === //

            player_setting.OnDamaged += PlayerTakeDamage_Effect;
            player_setting.OnHealed += PlayerTakeHeal_Effect;

            playerSpriteR = player_setting.GetComponent<SpriteRenderer>();
            
            #region CheckNull Reference

            Debug.Assert(player_setting, "player_setting is Not Attach!");
            Debug.Assert(playerSpriteR, "player_SpriteRender is Not Attach!");

            #endregion
        }

        // 점멸 도중에는 또 재생되지 않는다.
        private void PlayerTakeDamage_Effect()
        {
            if (isHitEffectPlay)
                return;

            IsCriticalDamage();
            
            StartCoroutine(TakeDamageEffect());
        }

        private void IsCriticalDamage()
        {
            float divideV = (float)player_setting.CurrentHp / player_setting.MaxHp;

            warningText.SetActive(divideV < critical_HP_Ratio);
        }
        
        // 플레이어 스프라이트가 점멸하기 위한 코루틴
        private IEnumerator TakeDamageEffect()
        {
            isHitEffectPlay = true;
            Color originC = playerSpriteR.color;

            nowTime = 0;

            while (nowTime < blinkDuration)
            {
                playerSpriteR.color = playerSpriteR.color == originC ? Color.red : originC;

                nowTime += blinkTime;

                yield return new WaitForSeconds(blinkTime);
            }

            playerSpriteR.color = originC;
            isHitEffectPlay = false;
        }

        private void PlayerTakeHeal_Effect()
        {
            IsCriticalDamage();
            
            // 플레이어가 힐 했을 때 이펙트 On
        }

      

    }
}