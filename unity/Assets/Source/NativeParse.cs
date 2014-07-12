using System;
using UnityEngine;

namespace Assets.Source
{
    public class NativeParse
    {
//        #if UNITY_IPHONE && !UNITY_EDITOR
//
//        #elif UNITY_ANDROID && !UNITY_EDITOR

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

            public static string SaveInBackground(string parseObject, string key, string value)
            {
                Debug.Log("Initialize " + parseObject + " " + key + " " + value); 

                var po = new AndroidJavaObject("com.parse.ParseObject", parseObject);
                po.Call("put", key, value);
                po.Call("saveInBackground");
                return po.Call<String>("getObjectId");
            }

            public static void LoadInBackground(string parseObject, string objectId)
            {
                var query = new AndroidJavaClass("com.parse.ParseQuery").CallStatic<AndroidJavaObject>("getQuery", parseObject);
                query.Call("getInBackground", objectId, new AndroidJavaObject("java.lang.Object"));

//                var cb = new GetCallback();
//                cb.done(new AndroidJavaObject("com.parse.ParseObject", parseObject), null);
            }

            public class GetCallback : AndroidJavaObject
            {
                public GetCallback() : base("com.parse.GetCallback") { }

                public void done(AndroidJavaObject parseObject, AndroidJavaObject parseException)
                {  
                        if (parseException == null) {
                            Debug.Log("parseObject");
                            Debug.Log("parseObject: " + parseObject.Call<String>("getObjectId"));
                        } else {
                            // something went wrong
                            Debug.Log("something went wrong");
                        }
                }
            }

//        #else
//
//            public static void Initialize(string applicationId, string clientKey) {}
//            public static string SaveInBackground(string parseObject, string key, string value) { return "not implemented."; }
//            public static void LoadInBackground(string parseObject, string objectId) {}
//
//        #endif
    }
}
