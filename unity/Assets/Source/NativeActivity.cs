using UnityEngine;


namespace Assets.Source
{
    public class NativeActivity : MonoBehaviour {

        public void Awake()
        {
            NativeFlurry.OnStartSession("S5MMHGJYDVDNX2HTX4CR");
            NativeParse.Initialize("JDbBWkOOUksLw7EefanIfckq4Rme9A62pF6uz4Qb", "y6dVB0I6RKCMiKjPxF3el2O1ErZp2MdCgIygu6RQ");
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
            NativeFlurry.OnEndSession();
        }
    }
}