using DG.Tweening;
using UnityEngine;

namespace FishingIdle.UIElements.Animations
{
     public class UIButtonAnimations: MonoBehaviour
    {
        record PointerDownAnimationConfig
        {
            public float speed = 0.25f;
            public Ease ease = Ease.OutBack;
            public Vector3 targetScale = Vector3.one * 0.9f;
        }
        record PointerUpAnimationConfig
        {
            public float speed = 0.25f;
            public Ease ease = Ease.OutBack;
            public Vector3 targetScale = Vector3.one * 1f;
        }
        
        record PointerEnterAnimationConfig
        {
            public float speed = 0.15f;
            public Ease ease = Ease.OutBack;
            public Vector3 targetScale = Vector3.one * 0.95f;
        }
        
        record PointerExitAnimationConfig
        {
            public float speed = 0.15f;
            public Ease ease = Ease.OutBack;
            public Vector3 targetScale = Vector3.one * 1f;
        }

        private PointerDownAnimationConfig _pointerDownAnimationConfig;
        private PointerUpAnimationConfig _pointerUpAnimationConfig;
        private PointerEnterAnimationConfig _pointerEnterAnimationConfig;
        private PointerExitAnimationConfig _pointerExitAnimationConfig;

        private void Start()
        {
            _pointerUpAnimationConfig = new PointerUpAnimationConfig();
            _pointerDownAnimationConfig = new PointerDownAnimationConfig();
            _pointerEnterAnimationConfig = new PointerEnterAnimationConfig();
            _pointerExitAnimationConfig = new PointerExitAnimationConfig();
        }

        public void PlayOnPointerDownAnimation()
        {
            transform.DOScale(_pointerDownAnimationConfig.targetScale, _pointerDownAnimationConfig.speed)
                .SetEase(_pointerDownAnimationConfig.ease);
        }
        
        public void PlayOnPointerUpAnimation()
        {
            transform.DOScale(_pointerUpAnimationConfig.targetScale, _pointerUpAnimationConfig.speed)
                .SetEase(_pointerUpAnimationConfig.ease);
        }

        public void PlayOnPointerEnterAnimation()
        {
            transform.DOScale(_pointerEnterAnimationConfig.targetScale, _pointerEnterAnimationConfig.speed)
                .SetEase(_pointerEnterAnimationConfig.ease);
        }
        
        public void PlayOnPointerExitAnimation()
        {
            transform.DOScale(_pointerExitAnimationConfig.targetScale, _pointerExitAnimationConfig.speed)
                .SetEase(_pointerExitAnimationConfig.ease);
        }
    }
}