using UnityEngine;
using UnityEngine.UI;

namespace _4._HM._2._Scripts.Player
{
    public class PlayerHP_UI : MonoBehaviour
    {
        [SerializeField] private Player_Setting playerHp;
        [SerializeField] private Slider hpSlider;
        [SerializeField] private GameObject slider_FillArea;
        [SerializeField] private Text hpCount;

        private void Awake()
        {
            #region CheckNull SerializedField

            Debug.Assert(playerHp, "Not < Player > Setting");
            Debug.Assert(hpSlider, "Not < HPSlider > Setting");
            Debug.Assert(slider_FillArea, "Not < Fill_Area > Setting");
            Debug.Assert(hpCount, "Not < Hp_Count TXT > Setting");

            #endregion

            // 이벤트 구독 
            playerHp.OnDamaged += ChangeHpSlider;
            playerHp.OnHealed += ChangeHpSlider;
            playerHp.OnDead += PlayerDied;

            ChangeHpSlider();
        }

        // 데미지 또는 힐했을 때 HP 슬라이더 변경해야됨
        private void ChangeHpSlider()
        {
            hpSlider.value = (float)playerHp.CurrentHp / playerHp.MaxHp;
            hpCount.text = playerHp.CurrentHp.ToString() + " / " + playerHp.MaxHp.ToString();
        }

        // 플레이어가 죽었을 경우 이벤트 구독 해제를 통한 시스템 자원 관리
        // FillArea를 비활성화 함으로써 HP바 수정
        private void PlayerDied()
        {
            slider_FillArea.SetActive(false);
            ChangeHpSlider();

            playerHp.OnDamaged -= ChangeHpSlider;
            playerHp.OnHealed -= ChangeHpSlider;
            playerHp.OnDead -= PlayerDied;
        }
    }
}