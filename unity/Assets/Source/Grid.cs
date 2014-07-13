using UnityEditor;
using UnityEngine;

namespace Assets.Source
{
    public class Grid : MonoBehaviour {

        public int Rows;
        public int Cols;
        public GameObject[,] ToneGrid;

        public float Speed;
        public string Name;
        public int Priority;

        public Metronom Metronom;
//        private int _metroCounter;

        public void Generate ()
        {
            var main = GameObject.Find("Main").GetComponent<Main>();

            var parent = new GameObject("Notes").transform;
            parent.parent = transform;

            var metronom = (GameObject)Instantiate(main.Metronom);
            metronom.transform.parent = transform;
            metronom.name = "Metronom";
            metronom.transform.position = new Vector3(0, Cols);
            Metronom = metronom.GetComponent<Metronom>();
            Metronom.IntervalSpeed = 1f;

            ToneGrid = new GameObject[Rows, Cols];
            const float xPadding = 0.0f;
            const float yPadding = 0.1f;

            for (var y = 0; y < Cols; ++y)
            {
                for (var x = 0; x < Rows; ++x)
                {
                    var note = (GameObject)Instantiate(main.Sprite);
                    note.transform.parent = parent;
                    ToneGrid[x, y] = note;
                    note.transform.position = new Vector3(x, y * (1 + yPadding) - (1 + yPadding));

                    note.renderer.material = main.Inactive;
                   
                    note.GetComponent<AudioSource>().clip = main.Tones[y + 3];

                    var noteHandler = note.GetComponent<NoteHandler>();
                    noteHandler.Row = x;
                    noteHandler.Col = y;
                }
            }
        }

        public void HitColumn(int column)
        {
            for (var x = 0; x < Rows; ++x)
            {
                ToneGrid[column, x].SendMessage("HitByMetronom");
            }
        }
    }
}