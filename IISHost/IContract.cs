using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IISHost
{
    [ServiceContract(CallbackContract = typeof(IContractCallback))]
    [ServiceKnownType(typeof(AdminCommand))]
    public interface IContract
    {
        [OperationContract]
        string GetConnectionConfirmation(bool connect);

        [OperationContract]
        void AdminCommands(AdminCommand control, MetaData metaData);

        [OperationContract]
        void ShowPpt(MetaData metaData);
    }

    public interface IContractCallback
    {

        [OperationContract]
        void PlayVideo(MetaData metaData, AdminCommand control);

        [OperationContract]
        void OpenPPT(MetaData metaData);

        [OperationContract()]
        void AdminCommand(AdminCommand control);
    }

    [DataContract(Name = "LaunchControl")]
    public enum AdminCommand
    {
        [EnumMember]
        Launch,
        [EnumMember]
        Play,
        [EnumMember]
        Pause,
        [EnumMember]
        Stop,
        [EnumMember]
        Hop,
        [EnumMember]
        Listen,
        [EnumMember]
        StopListen
    }

    [DataContract(Name = "MetaData")]
    public class MetaData
    {
        [DataMember]
        public string VideoId { get; set; }
        [DataMember]
        public string Interval { get; set; }
        [DataMember]
        public string PptId { get; set; }

    }
}
