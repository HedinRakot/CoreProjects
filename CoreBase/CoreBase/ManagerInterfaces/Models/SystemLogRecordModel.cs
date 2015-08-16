using System;
using System.Runtime.Serialization;
// ReSharper disable InconsistentNaming

namespace CoreBase.Models
{
    [DataContract]
    public class SystemLogRecordModel : BaseModel
	{
        [DataMember]
        public string userLogin { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public DateTime date { get; set; }
	}
}