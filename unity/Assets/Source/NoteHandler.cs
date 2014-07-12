using System;
using System.Collections;
using UnityEngine;

namespace Assets.Source
{
    public class NoteHandler : MonoBehaviour
    {
        public delegate void AudioCallback();

        public Main Main;

        public bool IsActive;
        public bool IsRunning;
        public int ExplosionId;
        public Color lightning = new Color(0.3f,0.3f,0.3f);

        public void Start()
        {
            Main = GameObject.Find("Main").GetComponent<Main>();
        }

        void Toggle()
        {
            IsActive = !IsActive;
            Dye();
        }

        void OnMouseDown()
        {
            Toggle();
        }

        public void Update()
        {
            if (IsActive && !IsRunning && Math.Abs(Main.Metronom() - gameObject.transform.position.x) < 0.0001f)
            {
                IsRunning = true;
                PlaySoundWithCallback(audio.clip, AudioFinished);
            }
        }

        void AudioFinished()
        {
            IsRunning = false;
            Dye();

            var wobble = gameObject.GetComponent<Wobble>();
            if (wobble != null) wobble.Finish();
        }

        public void PlaySoundWithCallback(AudioClip clip, PianoKeyScript.AudioCallback callback)
        {
            audio.PlayOneShot(clip);

            // lighten
            renderer.material.color += lightning;

            // particles
            ExplodeAtPosition(clip.length);

            // wobble
            var wobble = gameObject.AddComponent<Wobble>();
            wobble.Duration = clip.length / 2f;
            wobble.Factor = 0.01f;

            StartCoroutine(DelayedCallback(clip.length, callback));
        }

        private IEnumerator DelayedCallback(float time, PianoKeyScript.AudioCallback callback)
        {
            yield return new WaitForSeconds(time);
            callback();
        }

        public void Reset()
        {
            IsActive = false;
            Dye();
            var wobble = gameObject.GetComponent<Wobble>();
            if(wobble != null) wobble.Finish();
        }

        public void Dye()
        {
            renderer.material.color = IsActive ? Main.Red : Main.Blue;
        }

        public void ExplodeAtPosition(float duration)
        {
            var explosion = (GameObject)Instantiate(Main.Explosions[ExplosionId]);
            var pos = gameObject.transform.position;
            pos.z = -1.001f;
           // explosion.GetComponent<Detonator>().duration = duration;
            explosion.GetComponent<ParticleRenderer>().lengthScale = duration;
            explosion.transform.position = pos;
        }
    }
}
