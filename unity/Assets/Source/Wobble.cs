using UnityEngine;

namespace Assets.Source
{
    public class Wobble : MonoBehaviour
    {
        public float Duration;
        public float Factor;
        private Vector3 _startScale;

        public void Start()
        {
            _startScale = transform.localScale;
        }
	
        void Update () {
            var wobble = Mathf.Sin(Time.time * Mathf.PI * 2.0f / Duration) * Factor;
            var xScale = _startScale.x + wobble;
            var yScale = _startScale.y / xScale;

            var scale = transform.localScale;
            scale.x = xScale;
            scale.y = yScale;
            transform.localScale = scale;
        }

        public void Finish()
        {
            transform.localScale = _startScale;
            Destroy(this);
        }
    }
}