using UnityEngine;

namespace Assets.Source
{
    public class GridManager : MonoBehaviour
    {
        public GameObject[,] Grids;
        public int Rows;
        public int Cols;

        public void Generate(int rows, int cols)
        {
            var main = GameObject.Find("Main").GetComponent<Main>();

            Grids = new GameObject[rows, cols];

            for (var y = 0; y < cols; ++y)
            {
                for (var x = 0; x < rows; ++x)
                {
                    var go = new GameObject("Grid[" + x + "," + y + "]");
                    Grids[x, y] = go;
                    var grid = go.AddComponent<Grid>();
                    grid.Rows = 8;
                    grid.Cols = 8;
                    grid.Generate();
                    go.transform.position = new Vector3(x * (1 + main.GridPadding.x), y * (1 * main.GridPadding.y), 0);
                    go.transform.parent = gameObject.transform;
                }
            }
        }

        public void Awake()
        {
            Generate(Rows,Cols);
        }
    }
}