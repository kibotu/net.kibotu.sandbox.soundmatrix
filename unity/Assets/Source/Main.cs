using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Source
{
    public class Main : MonoBehaviour
    {
        public float Interval = 1f;
        public float ElapsedTime;
        public GameObject Sprite;
        public Material Active;
        public Material Inactive;
        public Material Lightened;
        public Material White;

        public static Queue<Action> ExecuteInterval = new Queue<Action>();

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

        public void Update()
        {
            ElapsedTime += Time.deltaTime;
            if (ElapsedTime >= Interval)
            {
                ElapsedTime -= Interval;
                foreach (var a in ExecuteInterval)
                {
                    a.Invoke();
                }
            }
        }
    }
}
