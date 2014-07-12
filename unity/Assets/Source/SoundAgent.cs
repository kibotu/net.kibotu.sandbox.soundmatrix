using UnityEngine;

namespace Assets.Source
{
    public class SoundAgent : MonoBehaviour
    {
        private GridManager _grid;

        public void Start()
        {
            _grid = GameObject.Find("Grids").GetComponent<GridManager>();
        }
	
        void Update () {
	        
            
        }
    }
}
