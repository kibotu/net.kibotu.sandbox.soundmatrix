using UnityEngine;

namespace Assets.Source
{
    public class Main : MonoBehaviour
    {
        public GameObject Sprite;
        public GameObject Metronom;
        public Material Active;
        public Material Inactive;
        public Material LightenedRed;
        public Material LightenedBlue;
        public Material White;
        public float WobbleFactor;

        /// <summary>
        /// c1 
        /// d1 
        /// e1 
        /// g1 
        /// h1 
        /// c2 
        /// d2 
        /// e2 
        /// g2 
        /// h2 
        /// c3
        /// </summary>
        public AudioClip[] Tones;
        public GameObject[] Explosions;
    }
}
