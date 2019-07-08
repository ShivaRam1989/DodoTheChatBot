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
        void LaunchToggle(LaunchControl control, MetaData metaData);
    }

    public interface IContractCallback
    {

        [OperationContract()]
        void MyMethod(LaunchControl control, MetaData metaData);
    }

    [DataContract(Name ="LaunchControl")]
    public enum LaunchControl
    {
        [EnumMember]
        Start,
        [EnumMember]
        Stop,
        [EnumMember]
        Play,
        [EnumMember]
        Pause,
        [EnumMember]
        Hop
    }

    [DataContract(Name = "MetaData")]
    public class MetaData
    {
        [DataMember]
        public string VideoId { get; set; }
        [DataMember]
        public int Interval { get; set; }

    }
}
