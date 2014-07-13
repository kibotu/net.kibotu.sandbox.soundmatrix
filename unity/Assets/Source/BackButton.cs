using UnityEngine;

namespace Assets.Source
{
    public class BackButton : MonoBehaviour {

        private void OnGUI()
        {
            GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = Screen.width/40;
            if (GUI.Button(new Rect(Screen.width - Screen.width / 5f, Screen.height - Screen.height / 12f, Screen.width / 10f, Screen.height / 20f), "Back"))
            {
                Camera.main.GetComponent<PlayMakerFSM>().SendEvent("MoveBack");
            }
        }
    }
}
