using UnityEngine;

namespace Assets.Source
{
    public class NativeFlurry
    {
        #if UNITY_IPHONE && !UNITY_EDITOR

            public static void OnStartSession(string key) {}

            public static void OnEndSession() {}

        #elif UNITY_ANDROID && !UNITY_EDITOR

            static AndroidJavaClass FlurryAgent
            {
                get { return _flurry ?? (_flurry = new AndroidJavaClass("com.flurry.android.FlurryAgent")); }
            }
            static AndroidJavaClass _flurry = null;

            public static void OnStartSession(string key)
            {
                var jcUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                FlurryAgent.CallStatic("onStartSession", jcUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"), key);
            }

            public static void OnEndSession()
            {
                FlurryAgent.CallStatic("onEndSession");
            }

        #else

            public static void OnStartSession(string key) {}
            public static void OnEndSession() {}

        #endif
    }
}
