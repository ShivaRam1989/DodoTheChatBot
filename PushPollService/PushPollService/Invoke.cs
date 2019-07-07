using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PushPollService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,ConcurrencyMode =ConcurrencyMode.Multiple)]
    public class Invoke : IContract
    {

        public static IContractCallback callback = null;

        public string GetConnectionConfirmation()
        {
            if (callback != null)
            {
                callback = OperationContext.Current.GetCallbackChannel<IContractCallback>();
            }
            return "Connection confirmed";
        }

        public LaunchControl LaunchToggle(LaunchControl control)
        {
            SendToWPFClient(control);
            return control == LaunchControl.Start ? LaunchControl.Stop:LaunchControl.Start;
        }

        public void SendToWPFClient(LaunchControl control)
        {
            callback.MyMethod(control);
        }
    }
}
