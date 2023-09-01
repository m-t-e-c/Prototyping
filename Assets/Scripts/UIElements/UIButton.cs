using FishingIdle.UIElements.Animations;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FishingIdle.UIElements
{
    public class UIButton : Button
    {
        UIButtonAnimations _uiButtonAnimations;
        
        protected override void Awake()
        {
            base.Awake();
            _uiButtonAnimations = GetComponent<UIButtonAnimations>();
        }
        
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            _uiButtonAnimations.PlayOnPointerDownAnimation();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            _uiButtonAnimations.PlayOnPointerUpAnimation();
        }
    }
}