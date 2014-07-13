using System;
using System.Collections;
using UnityEngine;

namespace Assets.Source
{
    public class NoteHandler : MonoBehaviour
    {
        public delegate void AudioCallback();

        private Main _main;
        public int ExplosionId;
        private Grid _grid;
        public int Row;
        public int Col;

        private PlayMakerFSM _fsm;

        public void Start()
        {
            _main = GameObject.Find("Main").GetComponent<Main>();
            _grid = transform.parent.parent.GetComponent<Grid>();
            _fsm = GetComponent<PlayMakerFSM>();
        }

        public void Activating()
        {
            renderer.material = _main.Active;
        }

        public void Deactivating()
        {
            renderer.material = _main.Inactive;
        }

        public void HitByMetronom()
        {
            _fsm.SendEvent("Metronom");
        }

        public void PlayNote()
        {
            //  play sound
            PlaySoundWithCallback(audio.clip, AudioFinished);

            // lighten
            renderer.material = _main.LightenedRed;

            // particles
            ExplodeAtPosition(audio.clip.length);

            // wobble
//            var wobble = gameObject.AddComponent<Wobble>();
//            wobble.Duration = audio.clip.length / 2f;
//            wobble.Factor = Main.WobbleFactor;
        }

        void AudioFinished()
        {
            var wobble = gameObject.GetComponent<Wobble>();
            if (wobble != null) wobble.Finish();

            _fsm.SendEvent("TonePlayed");

            Activating();
        }

        public void PlaySoundWithCallback(AudioClip clip, AudioCallback callback)
        {
            audio.PlayOneShot(clip);
            StartCoroutine(DelayedCallback(clip.length, callback));
        }

        private IEnumerator DelayedCallback(float time, AudioCallback callback)
        {
            yield return new WaitForSeconds(time);
            callback();
        }

        public void Reset()
        {
            
        }

        public void ExplodeAtPosition(float duration)
        {
            var explosion = (GameObject)Instantiate(_main.Explosions[ExplosionId]);
            var pos = gameObject.transform.position;
            pos.z = -1.001f;
           // explosion.GetComponent<Detonator>().duration = duration;
            explosion.GetComponent<ParticleRenderer>().lengthScale = duration;
            explosion.transform.position = pos;
        }

        public void PlayScaleAnimation()
        {
            var speed =_grid.Metronom.IntervalSpeed;
        }
    }
}
