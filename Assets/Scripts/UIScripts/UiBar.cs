using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public abstract class UiBar : MonoBehaviour, IImageClamp
    {
        public Action<float, float> SetFillImage { get; protected set; }

        protected abstract void SetFillAmount(float value, float maxHeath);
    }
}