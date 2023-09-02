using System;
using Presenters.MiniGamePresenter;
using UnityEngine;

namespace FishingIdle.Presenters.MiniGamePresenter
{
    public class MiniGamePresenter : BasePresenter<MiniGamePresenter>
    {
        [SerializeField] MovingStick movingStick;
        [SerializeField] RectTransform easyTarget;
        [SerializeField] RectTransform hardTarget;

        Action _onMiniGameCompleted;
        Action _onMiniGameCompletedPerfect;

        bool _isMiniGameActive;

        public void Init(Action onMiniGameCompleted, Action onMiniGameCompletedPerfect, float miniGameSpeed)
        {
            _onMiniGameCompleted = onMiniGameCompleted;
            _onMiniGameCompletedPerfect = onMiniGameCompletedPerfect;
            _isMiniGameActive = true;
            
            movingStick.SetSpeed(miniGameSpeed);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _isMiniGameActive)
            {
                if (IsTouchingTargetRect(hardTarget))
                {
                    _onMiniGameCompletedPerfect?.Invoke();
                    _isMiniGameActive = false;
                    movingStick.Stop();
                    Close();
                    return;
                }

                if (IsTouchingTargetRect(easyTarget))
                {
                    _onMiniGameCompleted?.Invoke();
                    _isMiniGameActive = false;
                    movingStick.Stop();
                    Close();
                }
            }
        }

        bool IsTouchingTargetRect(RectTransform target)
        {
            Rect targetRect = target.rect;
            Vector3 targetRectWorldPosition = target.TransformPoint(targetRect.center);

            Rect movingStickRect = ((RectTransform)movingStick.transform).rect;
            Vector3 movingStickWorldPosition = movingStick.transform.TransformPoint(movingStickRect.center);

            if (Mathf.Abs(movingStickWorldPosition.x - targetRectWorldPosition.x) < (movingStickRect.width + targetRect.width) / 2 &&
                Mathf.Abs(movingStickWorldPosition.y - targetRectWorldPosition.y) < (movingStickRect.height + targetRect.height) / 2)
            {
                return true;
            }
            return false;
        }
    }
}