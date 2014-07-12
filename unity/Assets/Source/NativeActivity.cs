using UnityEngine;


namespace Assets.Source
{
    public class NativeActivity : MonoBehaviour
    {
        public bool Debug;

        public void Awake()
        {
            AndroidJNI.AttachCurrentThread();
            AndroidJNIHelper.debug = Debug;
            NativeFlurry.OnStartSession("S5MMHGJYDVDNX2HTX4CR");
        }

        public void OnStart()
        {
        }
        
        public void OnApplicationPause(bool pauseStatus)
        {
        }

        public void OnApplicationFocus(bool focusStatus)
        {
        }

        public void OnApplicationQuit()
        {
            Resources.UnloadUnusedAssets();
            NativeFlurry.OnEndSession();
        }
    }
}