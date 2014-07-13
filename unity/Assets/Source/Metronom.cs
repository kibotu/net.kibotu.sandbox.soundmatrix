using UnityEngine;

namespace Assets.Source
{
    public class Metronom : MonoBehaviour
    {
        private Grid _grid;
        private PlayMakerFSM _fsm;
        private int _counter;
        public float IntervalSpeed;

        public void Awake ()
        {
            _fsm = GetComponent<PlayMakerFSM>();
        }

        public void Start()
        {
            _grid = transform.parent.GetComponent<Grid>();
        }

        public void Increment()
        {
            transform.localPosition = new Vector3(++_counter % _grid.Rows, _grid.Cols);
            _grid.HitColumn((int) transform.localPosition.x);

            _fsm.FsmVariables.GetFsmFloat("IntervalSpeed").Value = IntervalSpeed;
        }
    }
}
