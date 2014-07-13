using NoDisOne.PlayMaker.Actions;
using UnityEngine;

public class MySendMessageReceiveScript : MonoBehaviour {

    void TestReceiveMySendMessageReturnFloat(MyMessageArgs myMessageArgs)
    {
        Debug.Log("TestReceiveMySendMessageReturnFloat : Parameter1: " + myMessageArgs.Parameter1);
        Debug.Log("TestReceiveMySendMessageReturnFloat : Parameter2: " + myMessageArgs.Parameter2);

        float a = (float)myMessageArgs.Parameter1;
        float b = (float)myMessageArgs.Parameter2;

        myMessageArgs.ReturnParameter = a + b;
        Debug.Log("TestReceiveMySendMessageReturnFloat : Setting ReturnParameter to Float : " + myMessageArgs.ReturnParameter);
    }

    void TestReceiveMySendMessageReturnGameObject(MyMessageArgs myMessageArgs)
    {
        Debug.Log("TestReceiveMySendMessageReturnGameObject : Parameter1: " + myMessageArgs.Parameter1);
        Debug.Log("TestReceiveMySendMessageReturnGameObject : Parameter2: " + myMessageArgs.Parameter2);

        myMessageArgs.ReturnParameter = Camera.main.gameObject;

        Debug.Log("TestReceiveMySendMessageReturnGameObject : Setting ReturnParameter to Gameobject : " + ((GameObject)myMessageArgs.ReturnParameter).name);
    }

}
