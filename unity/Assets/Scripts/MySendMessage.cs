using HutongGames.PlayMaker;
using UnityEngine;

namespace NoDisOne.PlayMaker.Actions
{
    public enum MessageType
    {
        SendMessage,
        SendMessageUpwards, // No return value as multiple receiver
        BroadcastMessage    // No return value as multiple receiver
    }

    public class MyMessageArgs
    {
        public object Parameter1 { get; set; }
        public object Parameter2 { get; set; }
        public object ReturnParameter { get; set; }
    }

    [ActionCategory(ActionCategory.ScriptControl)]
    public class MySendMessage : FsmStateAction
    {
        [RequiredField]
        [UnityEngine.Tooltip("GameObject that sends the message.")]
        public FsmOwnerDefault gameObject;

        [UnityEngine.Tooltip("Where to send the message (please see Unity docs)")]
        public MessageType delivery;

        [UnityEngine.Tooltip("Send options (please see Unity docs)")]
        public SendMessageOptions options;

        [UnityEngine.Tooltip("Script Method you would like to SendMessage")]
        [RequiredField]
        public string MethodName;

        // Just 2 Parameters for this example, we can work on a generic N parameters one next time
        [ActionSection("Parameter 1")]
        public FsmVar Parameter1;           

        [ActionSection("Parameter 2")]
        public FsmVar Parameter2;

        [ActionSection("Return Parameter")]
        [UIHint(UIHint.Variable)]
        [UnityEngine.Tooltip("Variable to store return value in.")]
        public FsmVar ReturnParameter;

        public override void Reset()
        {
            gameObject = null;
            delivery = MessageType.SendMessage;
            options = SendMessageOptions.DontRequireReceiver;
            MethodName = "";
        }

        public override void OnEnter()
        {
            DoSendMessage();

            Finish();
        }

        void DoSendMessage()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                return;
            }

            MyMessageArgs myMessageArgs = new MyMessageArgs();
            myMessageArgs.Parameter1 = Parameter1.GetValue();
            myMessageArgs.Parameter2 = Parameter2.GetValue();

            switch (delivery)
            {
                case MessageType.SendMessage:
                    go.SendMessage(MethodName, myMessageArgs, options);

                    if (myMessageArgs.ReturnParameter != null)
                    {
                        // NOTE: the client Script Method must set myMessageArgs.ReturnParameter to the correct type 
                        PlayMakerUtils.ApplyValueToFsmVar(this.Fsm, ReturnParameter, myMessageArgs.ReturnParameter);
                    }
                    return;

                case MessageType.SendMessageUpwards:
                    go.SendMessageUpwards(MethodName, myMessageArgs, options);
                    // No Return Parameters as Multiple Receivers
                    return;

                case MessageType.BroadcastMessage:
                    go.BroadcastMessage(MethodName, myMessageArgs, options);
                    // No Return Parameters as Multiple Receivers
                    return;
            }

            Finish();
        }
    }
}
