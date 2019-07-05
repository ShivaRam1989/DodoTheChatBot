using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PushPollService
{
    [ServiceContract(CallbackContract = typeof(IContractCallback))]
    [ServiceKnownType(typeof(LaunchControl))]
    public interface IContract
    {
        [OperationContract]
        string GetConnectionConfirmation();

        [OperationContract]
        LaunchControl LaunchToggle(LaunchControl control);

        [OperationContract()]
        void MyMethod();

    }

    public interface IContractCallback
    {
        [OperationContract]
        void OnCallback();
    }

    [DataContract(Name ="LaunchControl")]
    public enum LaunchControl
    {
        [EnumMember]
        Start,
        [EnumMember]
        Stop
    }
}
