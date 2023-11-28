using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace UIScripts
{
    public class UiBarHealth : UiBar
    {
        [SerializeField] private Image healthBar;

        public void OnEnable() => SetFillImage += SetFillAmount;

        public void OnDisable() => SetFillImage -= SetFillAmount;
        
        protected override void SetFillAmount(float value, float maxHeath)
        {
            healthBar.fillAmount = value / maxHeath;
            Canvas.ForceUpdateCanvases();
        }
    }
}