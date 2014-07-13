using UnityEngine;

namespace Assets.Source
{
    public class CameraMovement : MonoBehaviour
    {
        public float Time;
        public iTweenPath Path;
        private iTweenPath _currentPath;
        private PlayMakerFSM _fsm;
        private GridManager _grids;
        private Main _main;
        private Grid _currentGrid;

        public void Awake()
        {
            Path = GetComponent<iTweenPath>();
            _fsm = Camera.main.GetComponent<PlayMakerFSM>();
            _main = GameObject.Find("Main").GetComponent<Main>();
            _grids = GameObject.Find("Grids").GetComponent<GridManager>();
        }

        public void MoveToGrid(Vector2 dest)
        {
            _currentGrid = _grids.Grids[(int)dest.x, (int)dest.y].GetComponent<Grid>();
            var x = (_currentGrid.ToneGrid[0, 0].transform.position.x + _currentGrid.ToneGrid[_currentGrid.Rows - 1, 0].transform.position.x) / 2;
            var y = (_currentGrid.ToneGrid[0, 0].transform.position.y + _currentGrid.ToneGrid[0, _currentGrid.Cols - 1].transform.position.y) / 2;

            var destination = new Vector3(x,y, -13);
            Path.nodes[1] = destination;

            _currentPath = Path;
            _currentGrid.Box.enabled = false;

            iTween.MoveTo(Camera.main.gameObject,
                  iTween.Hash(
                      "path", iTweenPath.GetPath(_currentPath.pathName),
                      "time", Time,
                      "orientToPath", false,
                      "delay", .4,
                      "easeType", "easeInOutSine",
                      "onComplete", "MoveComplete",
                      "onCompleteTarget", gameObject,
                      "lookTime", 0.1f,
                      "lookahead", 0.1f));
        }

        public void MoveBack()
        {
            if (_currentPath == null) return;

            iTween.MoveTo(Camera.main.gameObject,
               iTween.Hash(
                   "path", iTweenPath.GetPathReversed(_currentPath.pathName),
                   "time", Time,
                   "orientToPath", false,
                   "delay", .4,
                   "easeType", "easeInOutSine",
                   "onComplete", "MoveComplete",
                   "onCompleteTarget", gameObject,
                   "lookTime", 0.1f,
                   "lookahead", 0.1f));

            _currentGrid.Box.enabled = true;

            _currentPath = null;
        }

        public void MoveComplete()
        {
            _fsm.SendEvent("Arrive");
        }
    }
}
