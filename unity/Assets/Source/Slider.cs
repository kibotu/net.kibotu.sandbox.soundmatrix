using UnityEngine;

namespace Assets.Source
{
    public class Slider : MonoBehaviour {

        public float vSliderValue = 1.7F;

        void OnGUI()
        {
//            var pos = Camera.main.WorldToScreenPoint(new Vector3(1,0, 0));
            vSliderValue = GUI.HorizontalSlider(new Rect(Screen.width / 12f, Screen.height / 12f, Screen.width / 3f, Screen.height / 10f), vSliderValue, 0.01f, 5F);
            Time.timeScale = vSliderValue;
            var pixelOffset = guiText.pixelOffset;
            pixelOffset.x = Screen.width /12f;
            pixelOffset.y = Screen.height - Screen.height/20f;
            guiText.pixelOffset = pixelOffset;
            guiText.fontSize = Screen.width/40;
        }
    }
}
