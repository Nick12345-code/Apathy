using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NullFrameworkException.Mobile.InputHandling
{
    public class JoystickInputHandler : RunnableBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private MobileInputManager manager;
        [SerializeField] private RectTransform handle;
        [SerializeField] private RectTransform background;
        [SerializeField, Range(0, 1)] private float deadzone = 0.25f;
        // starting position of the handle
        private Vector3 initialPosition;

        //private MobileInputManager manager;

        public Vector2 Axis { get; private set; } = Vector2.zero;

        protected override void OnSetup(params object[] _params)
        {
            manager = (MobileInputManager) _params[0];
            // cache initial position of handle
            initialPosition = handle.position;
        }

        protected override void OnRun(params object[] _params)
        {

        }

        public void OnDrag(PointerEventData _eventData)
        {
            float xDifference = (background.rect.size.x - handle.rect.size.x * .5f);
            float yDifference = (background.rect.size.y - handle.rect.size.y * .5f);

            // calculate the axis of the input based on the event data and the relative position to the background's center
            Axis = new Vector2()
            {
                x = (_eventData.position.x - background.position.x) / xDifference,
                y = (_eventData.position.y - background.position.y) / yDifference
            };

            Axis = Vector2.ClampMagnitude(Axis, 1f);

            // apply axis position to handle position
            handle.position = new Vector3()
            {
                x = (Axis.x * xDifference) + background.position.x,
                y = (Axis.y * yDifference) + background.position.y
            };

            // apply deadzone effect after handle has been placed, to prevent the handle from being visually stuck in the deadzone
            Axis = (Axis.magnitude < deadzone) ? Vector2.zero : Axis;
        }

        public void OnEndDrag(PointerEventData _eventData)
        {
            // handle is let go, so reset the axis and position of the handle
            Axis = Vector2.zero;
            handle.position = initialPosition;
        }

        public void OnPointerDown(PointerEventData _eventData) => OnDrag(_eventData);
        public void OnPointerUp(PointerEventData _eventData) => OnEndDrag(_eventData);
    }
}
