using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PushPollService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Invoke : IContract
    {

        public string GetConnectionConfirmation()
        {
            return "Connection confirmed";
        }

        public LaunchControl LaunchToggle(LaunchControl control)
        {
            SendToWPFClient(control);
            return control == LaunchControl.Start ? LaunchControl.Stop:LaunchControl.Start;
        }

        public IContractCallback callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IContractCallback>();
            }
        }

        public void SendToWPFClient(LaunchControl control)
        {
            callback.MyMethod(control);
        }
    }
}
