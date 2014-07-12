using UnityEngine;

namespace Assets.Source
{
    public class ResetButton : MonoBehaviour {

        void OnGUI()
        {
            if (GUI.Button(new Rect(Screen.width/12f, Screen.height - Screen.height/12f, 50, 30), "Reset"))
            {
                NativeParse.SaveInBackground("testobject", "test", "tester");

                foreach (var note in GameObject.Find("Main").GetComponent<Main>().Grid)
                {
                    note.GetComponent<NoteHandler>().Reset();
                }
                
            }
        }
    }
}
