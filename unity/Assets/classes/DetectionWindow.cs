using UnityEngine;
using System.Collections;

/*DetextionWindow.cs
 * It is a window that is used to determine if a touch is present
 * inside a delimited portion of the screen
 */

public class DetectionWindow
        {
            float _coordMinX;
            float _coordMaxX;
            float _coordMinY;
            float _coordMaxY;

            public DetectionWindow()
            {
                //default window is 50% of the screen width/height docked to the BottomLeft corner
                _coordMinX = 0;
                _coordMinY = 0;
                _coordMaxX = 0.5f * Screen.width;
                _coordMaxY = 0.5f * Screen.height;


            }
            //It is possible to directly set the values of the detection windows
            public DetectionWindow(float minX, float maxX, float minY, float maxY)
            {
                _coordMinX = minX;
                _coordMaxX = maxX;
                _coordMinY = minY;
                _coordMaxY = maxY;
            }
            //Set the size of the window and choose which corner it ll be docked
            public DetectionWindow(float width, float height, EnumScreenCorners dock)
            {
                switch (dock)
                {
                    case EnumScreenCorners.NONE :
                    case EnumScreenCorners.BOTTOMLEFT:
                        _coordMinX = 0.0f;
                        _coordMinY = 0.0f;
                        _coordMaxX = width * Screen.width;
                        _coordMaxY = height * Screen.height;
                    break;

                    case EnumScreenCorners.BOTTOMRIGHT : 
                        _coordMinX = (Screen.width * (1-(1-width)));
                        _coordMinY = 0.0f;
                        _coordMaxX = Screen.width;
                        _coordMaxY = (Screen.height * (1 - (1-height)));
                        break;

                    case EnumScreenCorners.UPPERLEFT:
                        _coordMinX = 0.0f;
                        _coordMinY = (Screen.height * (1-height));
                        _coordMaxX = (Screen.width * (1 - width));
                        _coordMaxY = Screen.height;
                        break;

                    case EnumScreenCorners.UPPERRIGHT:
                        _coordMinX = (Screen.width * (1 - width));
                        _coordMinY = (Screen.height * (1 - height));
                        _coordMaxX = Screen.width;
                        _coordMaxY = Screen.height;
                        break;
                        
                }
            }
         /*PROPERTIES*/

            public float coordMinX
            {
                get { return _coordMinX; }
                set { _coordMinX = value; }
            }
            public float coordMaxX
            {
                get { return _coordMaxX; }
                set { _coordMaxX = value; }
            }
            public float coordMinY
            {
                get { return _coordMinY; }
                set { _coordMinY = value; }
            }
            public float coordMaxY
            {
                get { return _coordMaxY; }
                set { _coordMaxY = value; }
            }

            //return true if the touch is inside the window, false if not
            public bool isTouchInsideWindow(Touch touch)
            {
                if ((touch.position.x > _coordMinX) && (touch.position.x < _coordMaxX) && (touch.position.y > _coordMinY) && (touch.position.y < _coordMaxY))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    

