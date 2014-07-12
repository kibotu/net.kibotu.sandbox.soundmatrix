using System.Runtime.InteropServices;
using UnityEngine;
//using Parse;

namespace Assets.Source
{
    public class ResetButton : MonoBehaviour
    {
        public void Start()
        {
        }

        void OnGUI()
        {
//            GUI.skin.label.font = GUI.skin.button.font = GUI.skin.box.font = font;
            GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = Screen.width / 40;
            if (GUI.Button(new Rect(Screen.width / 12f, Screen.height - Screen.height / 12f, Screen.width / 10f, Screen.height / 20f), "Reset"))
            {

                guiText.fontSize = Screen.width / 25;

//                ParseObject testObject = new ParseObject("TestObject");
//                testObject["test"] = "tester";
//				var task = testObject.SaveAsync();
//				task.ContinueWith(s => {
//
//				    ParseQuery<ParseObject> query = ParseObject.GetQuery("TestObject");
//					query.GetAsync(testObject.ObjectId).ContinueWith(t => {
//						var result = t.Result;
//						Debug.Log("result " + result["test"]);
//					});
//				});


//                foreach (var note in GameObject.Find("Main").GetComponent<Main>().Grid)
//                {
//                    note.GetComponent<NoteHandler>().Reset();
//                }
                
            }
        }
    }
}
