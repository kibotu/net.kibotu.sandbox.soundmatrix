using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Assets.Source
{
    public class Main : MonoBehaviour
    {
        public GameObject Sprite;
        public float Interval = 1f;
        public float ElapsedTime;
        public Sprite RedGem;
        public Sprite BlueGem;
        public Color Red = new Color(234f / 255f, 153f / 153f, 255f / 255f, 1f);
        public Color Blue = new Color(178f / 255f, 209f / 255f, 255f / 255f, 1f);

        private const int Dx = 11;
        private const int Dy = 11;

        public AudioClip[] Tones;

        private GameObject _metronom;
        private int _metroCounter;
        public GameObject[,] Grid;
        public GameObject[] Explosions;

        void Start () {

            Red = new Color(235f / 255f, 56f / 255f, 56f / 255f, 1f);
            Blue = new Color(103f / 255f, 122f / 153f, 255f / 153f, 1f);

            _metronom = (GameObject)Instantiate(Sprite);
            _metronom.name = "Metronom";
            _metronom.transform.position = new Vector3(0, Dy);

            Grid = new GameObject[Dx,Dy];
            const float xPadding = 0.0f;
            const float yPadding = 0.1f;

            for (var y = 0; y < Dy; ++y)
            {
                for (var x = 0; x < Dx; ++x)
                {
                    var note = (GameObject)Instantiate(Sprite);
                    note.transform.parent = GameObject.Find("Notes").transform;
                    Grid[x, y] = note;
                    note.transform.position = new Vector3(x, y * (1 + yPadding) - (1 + yPadding));

                    Debug.Log(Red);
                    Debug.Log(Blue);
                    note.renderer.material.color = Blue;

                    /* 
                    * c1 
                    * d1 
                    * e1 
                    * g1 
                    * h1 
                    * c2 
                    * d2 
                    * e2 
                    * g2 
                    * h2 
                    * c3
                    */
                    note.GetComponent<AudioSource>().clip = Tones[y];
                }
            }
        }

        public void Update()
        {
            ElapsedTime += Time.deltaTime;
            if (ElapsedTime >= Interval)
            {
                ElapsedTime -= Interval;
                _metronom.transform.position = new Vector3(++_metroCounter % Dx, Dy);
            }
        }

        public float Metronom()
        {
            return _metronom.transform.position.x;
        }

        public static Color HexToColor(string hex)
        {
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            return new Color32(r, g, b, 255);
        }

        string ColorToHex(Color32 color)
        {
            string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
            return hex;
        }
    }
}
