using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class UiBarArmor : UiBar
    {
        [SerializeField] private Image armorBar;

        public void OnEnable() => SetFillImage += SetFillAmount;

        public void OnDisable() => SetFillImage -= SetFillAmount;

        protected override void SetFillAmount(float value, float maxHeath)
        {
            armorBar.fillAmount = value / maxHeath;
            Canvas.ForceUpdateCanvases();
        }
    }
}