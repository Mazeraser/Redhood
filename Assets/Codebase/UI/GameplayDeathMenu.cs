using Assets.Codebase.Mechanics.LifeSystem;

namespace Assets.Codebase.UI
{
    public class GameplayDeathMenu : GameplayMenu
    {
        private void Awake()
        {
            PlayerLife.PlayerIsDeathEvent += Activate;
        }
        private void OnDestroy()
        {
            PlayerLife.PlayerIsDeathEvent -= Activate;
        }
    }
}