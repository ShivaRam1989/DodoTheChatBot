using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IISHost
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Invoke : IContract
    {

        public static IContractCallback callback = null;

        public string GetConnectionConfirmation()
        {
            if (callback == null)
            {
                callback = OperationContext.Current.GetCallbackChannel<IContractCallback>();
            }
            return "Connection confirmed";
        }

        public void AdminCommands(AdminCommand control, MetaData metaData)
        {
            switch (control)
            {
                case AdminCommand.Play:
                    {
                        callback.PlayVideo(metaData, control);
                        break;
                    }
                case AdminCommand.Listen:
                case AdminCommand.StopListen:
                case AdminCommand.Launch:
                case AdminCommand.Pause:
                case AdminCommand.Hop:
                case AdminCommand.Stop:
                default:
                    {
                        callback.AdminCommand(control);
                        break;
                    }
            }
        }

        public void ShowPpt(MetaData metaData)
        {
            callback.OpenPPT(metaData);
        }
    }
}