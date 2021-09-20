using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NullFrameworkException.Mobile.InputHandling
{
    public class SwipeInputHandler : RunnableBehaviour
    {
        // contains all the information about a specific swipe, such as points along the swipe
        public class Swipe
        {
            public readonly List<Vector2> positions = new List<Vector2>();
            public readonly Vector2 initialPosition;
            public readonly int fingerID;

            public Swipe (Vector2 _initialPosition, int _fingerID)
            {
                initialPosition = _initialPosition;
                fingerID = _fingerID;
                positions.Add(_initialPosition);
            }
        }

        // the count of how many swipes are in progress
        public int SwipeCount => swipes.Count;

        // contains all the swipes currently being processed, each key is the corresponding finger ID
        private Dictionary<int, Swipe> swipes = new Dictionary<int, Swipe>();

        // attempts to get relevant swipe information relating to the passed ID
        public Swipe GetSwipe (int _index)
        {
            swipes.TryGetValue(_index, out Swipe swipe);
            return swipe;
        }

        protected override void OnSetup(params object[] _params)
        {

        }

        protected override void OnRun(params object[] _params)
        {
            if (Input.GetMouseButtonDown(0))        // touch began
            {

            }
            else if (Input.GetMouseButton(0))       // touch moved
            {
               
            }
            else if (Input.GetMouseButtonUp(0))     // touch ended
            {

            }

            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        // this is the first frame this touch is detected, so put it in the dictionary as a swipe
                        swipes.Add(touch.fingerId, new Swipe(touch.position, touch.fingerId));
                    }
                    else if (touch.phase == TouchPhase.Moved && swipes.TryGetValue(touch.fingerId, out Swipe swipe))
                    {
                        // this touch moved so add the position to the swipe
                        swipe.positions.Add(touch.position);
                    }
                    else if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && swipes.TryGetValue(touch.fingerId, out swipe))
                    {
                        // the swipe has ended so remove it from the dictionary
                        swipes.Remove(swipe.fingerID);
                    }
                }
            }
        }
    }
}
