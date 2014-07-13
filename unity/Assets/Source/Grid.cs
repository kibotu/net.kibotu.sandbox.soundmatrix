using UnityEngine;

namespace Assets.Source
{
    public class Grid : MonoBehaviour {

        public int Rows;
        public int Cols;
        public GameObject[,] ToneGrid;
        public BoxCollider Box;

        public float Speed;
        public string Name;
        public int Priority;
        public const float YPadding = 0.1f;

        public Metronom Metronom;

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
//            const float xPadding = 0.0f;

            for (var y = 0; y < Cols; ++y)
            {
                for (var x = 0; x < Rows; ++x)
                {
                    var note = (GameObject)Instantiate(main.Sprite);
                    note.transform.parent = parent;
                    ToneGrid[x, y] = note;
                    note.transform.position = new Vector3(x, y * (1 + YPadding) - (1 + YPadding));

                    note.renderer.material = main.Inactive;
                   
                    note.GetComponent<AudioSource>().clip = main.Tones[y + 3];

                    var noteHandler = note.GetComponent<NoteHandler>();
                    noteHandler.Row = x;
                    noteHandler.Col = y;
                }
            }

            CreateBox();
        }

        public void HitColumn(int column)
        {
            for (var x = 0; x < Rows; ++x)
            {
                ToneGrid[column, x].SendMessage("HitByMetronom");
            }
        }

        public void OnMouseDown()
        {
            GameObject.Find("CameraTween").GetComponent<CameraMovement>().MoveToGrid(new Vector2(int.Parse(name[5].ToString()), int.Parse(name[7].ToString())));
        }

        public void CreateBox()
        {
            Box = gameObject.AddComponent<BoxCollider>();
            var x = (ToneGrid[0, 0].transform.position.x + ToneGrid[Rows - 1, 0].transform.position.x) / 2;
            var y = (ToneGrid[0, 0].transform.position.y + ToneGrid[0, Cols - 1].transform.position.y) / 2;
            Box.size = new Vector3(Rows * 1.3f, Cols * 1.3f, 1);
            Box.center = new Vector3(x, y, -2);
            Box.enabled = true;
        }
    }
}