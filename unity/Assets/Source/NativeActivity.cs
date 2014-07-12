using UnityEngine;


namespace Assets.Source
{
    public class NativeActivity : MonoBehaviour {

        public void OnAwake()
        {
//            Debug.Log("OnAwake");
            
            const string flurrykey = "S5MMHGJYDVDNX2HTX4CR";

            NativeFlurry.OnStartSession(flurrykey);
        }

        public void OnStart()
        {
//            Debug.Log("OnStart");
        }

        public void OnApplicationPause(bool pauseStatus)
        {
//            Debug.Log("OnApplicationPause " + pauseStatus);
        }

        public void OnApplicationFocus(bool focusStatus)
        {
//            Debug.Log("OnApplicationFocus " + focusStatus);
        }

        public void OnApplicationQuit()
        {
//            Debug.Log("OnApplicationQuit");

            NativeFlurry.OnEndSession();
        }
    }
}
