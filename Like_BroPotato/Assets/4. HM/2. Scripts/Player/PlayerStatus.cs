namespace _4._HM._2._Scripts.Player
{
    /// <summary>
    /// 플레이어 상태를 체크하는 스크립트
    /// 1. 플레이어 피통 확인
    /// 2. 플레이어 피가 일정 이하로 낮아지면 화면이 빨개지는 이벤트 발생
    /// </summary>
    public class PlayerStatus : Player_Setting
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            
            Init();
        }

        protected void Init()
        {
            CurrentHp = MaxHp;
            OnDamaged += (amount) => Add();
        }

        protected override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
        }

        protected override void TakeHeal(int amount)
        {
            base.TakeHeal(amount);
        }

        public void Add()
        {
            
        }
    }
}