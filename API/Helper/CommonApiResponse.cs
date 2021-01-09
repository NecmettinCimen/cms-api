using System.Net;
using System.Runtime.Serialization;

namespace cms_api.Helper
{
    [DataContract]
    public class CommonApiResponse
    {
        public static CommonApiResponse Create(HttpStatusCode statusCode, object result = null, string errorMessage = null, string correletionId = null, string errorCode = null)
        {
            return new CommonApiResponse(statusCode, result, errorMessage, correletionId, errorCode);
        }
        [DataMember(IsRequired = true)]
        public string Version => "1.0";
        [DataMember(IsRequired = true)]
        public bool Success { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ErrorCode { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string ErrorMessage { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string CorreletionId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Result { get; set; }
        protected CommonApiResponse(HttpStatusCode statusCode, object result = null, string errorMessage = null, string correletionId = null, string errorCode = null)
        {
            CorreletionId = correletionId;
            Result = result;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
            Success = string.IsNullOrEmpty(errorMessage) 
            && statusCode != HttpStatusCode.Unauthorized 
            && statusCode != HttpStatusCode.InternalServerError;
        }
        public CommonApiResponse()
        {
            
        }
    }
}