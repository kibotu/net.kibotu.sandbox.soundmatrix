using System;
using UnityEngine;

namespace Assets.Source
{
    public class CameraIdle : MonoBehaviour
    {
        public float _timer = 0.0f; //used as the input to the sine function
        public float _translateChange = 0f; //How far the camera is away from it's resting point
        public float _lastTranslateChange = 0f; //used to keep track of the delta (change in) translation

        public float BobbingSpeed = 0.18f; //How quickly the camera bobs up and down
        public float BobbingAmount = 0.2f; //How high/low the camera's max/min bob is.
        public float SettlingRate = 1f; //determines how fast we return to 0 position while standing still

        public void Update()
        {
            var waveslice = 0.0f;
            //determine how fast the player wants to move
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            //first, grab a sine value to work with
            //not moving --> return to midpoint
            if (Math.Abs(Mathf.Abs(horizontal)) < Mathf.Epsilon && Math.Abs(Mathf.Abs(vertical)) < Mathf.Epsilon)
            {
                _timer = 0.0f;
            }
            else
            {
                //we are moving, grab a bob value from the sine curve
                waveslice = Mathf.Sin(_timer);
                _timer = _timer + BobbingSpeed; //move along the sine curve for the next cycle
                if (_timer > Mathf.PI * 2)
                {
                    _timer = _timer - (Mathf.PI * 2); // sine repeats after 2PI. Keep timer in a reasonable range
                }
            }

            //now calculate how much we want to move the camera
            //we ARE moving
            if (Math.Abs(waveslice) > Mathf.Epsilon)
            { //bob up and down based on a sine wave and movement amount
                _translateChange = waveslice * BobbingAmount; //scale translation by bobbing amount
                var totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
                totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
                _translateChange = totalAxes * _translateChange; //scale translation by movement amount
            }
            else
            { //we are sitting still, smoothly return to 0 position
                _translateChange = Mathf.Lerp(_lastTranslateChange, 0, Time.deltaTime * SettlingRate);
            }

            //now actually move the camera
            //move the transform's y component by the delta translation
            var pos = transform.position;
            pos.y += _translateChange - _lastTranslateChange;
            transform.position = pos;
            _lastTranslateChange = _translateChange; //keep track of last cycle's translation

            Debug.Log(transform.position);
        }
    }
}