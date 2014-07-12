using System;
using UnityEngine;

namespace Assets.Source
{
    public class Grid : MonoBehaviour {

        public int Rows;
        public int Cols;
        public GameObject[,] ToneGrid;

        public float Speed;
        public string Name;

        private GameObject _metronom;
        private int _metroCounter;

        public void Generate ()
        {
            var main = GameObject.Find("Main").GetComponent<Main>();

            var parent = new GameObject("Notes").transform;
            parent.parent = transform;

            _metronom = (GameObject)Instantiate(main.Sprite);
            _metronom.name = "Metronom";
            _metronom.renderer.material = main.White;
            _metronom.transform.position = new Vector3(0, Cols);
            _metronom.transform.parent = transform;

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

        public int ActiveGridRow()
        {
            return (int) _metronom.transform.localPosition.x;
        }

        public bool IsActiveCell(int row, int col)
        {
            return row == ActiveGridRow();
        }

        public float Interval = 1f;
        public float ElapsedTime;

        public void Update()
        {
            ElapsedTime += Time.deltaTime;
            if (ElapsedTime >= Interval)
            {
                ElapsedTime -= Interval;
                _metronom.transform.localPosition = new Vector3(++_metroCounter%Rows, Cols);
            }
        }
    }
}