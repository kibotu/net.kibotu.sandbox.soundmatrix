using UnityEngine;

namespace Assets.Source
{
    public class NativeParse
    {
        #if UNITY_IPHONE && !UNITY_EDITOR

            public static void Initialize(string applicationId, string clientKey) {}
            public static void SaveInBackground(string parseObject, string key, string value) {}

        #elif UNITY_ANDROID && !UNITY_EDITOR

            static AndroidJavaClass Parse
            {
                get { return _parse ?? (_parse = new AndroidJavaClass("com.parse.Parse")); }
            }
            static AndroidJavaClass _parse = null;

            public static void Initialize(string applicationId, string clientKey)
            {
                var jcUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                Parse.CallStatic("initialize", jcUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"), applicationId, clientKey);
            }

            public static void SaveInBackground(string parseObject, string key, string value)
            {
                Debug.Log("Initialize " + parseObject + " " + key + " " + value); 

                var po = new AndroidJavaObject("com.parse.ParseObject", parseObject);
                po.Call("put", key, value);
                po.Call("saveInBackground");
            }
        
        #else

            public static void Initialize(string applicationId, string clientKey){}
            public static void SaveInBackground(string parseObject, string key, string value) { }

        #endif
    }
}
