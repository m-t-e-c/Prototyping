using UnityEngine;

namespace Presenters.MiniGamePresenter
{
    public class MovingStick : MonoBehaviour
    {
        [SerializeField] RectTransform backgroundRect;

        Vector2 startPosition;
        RectTransform rectTransform;
        float moveSpeed;
        bool isMovingUp = true;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            startPosition = rectTransform.anchoredPosition;
        }
        
        public void SetSpeed(float speed)
        {
            moveSpeed = speed;
        }

        public void Stop()
        {
            moveSpeed = 0.0f;
        }

        private void Update()
        {
            float moveAmount = moveSpeed * Time.deltaTime;

            if (isMovingUp)
            {
                rectTransform.anchoredPosition += Vector2.up * moveAmount;

                if (rectTransform.anchoredPosition.y >= startPosition.y + backgroundRect.rect.height)
                {
                    isMovingUp = false;
                }
            }
            else
            {
                rectTransform.anchoredPosition -= Vector2.up * moveAmount;

                if (rectTransform.anchoredPosition.y <= startPosition.y)
                {
                    isMovingUp = true;
                }
            }
        }
    }
}