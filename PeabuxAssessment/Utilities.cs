namespace PeabuxAssessment
{

    public class UResponseHandler
    {
        public static ResponseParam InitializeResponse()
        {
            return new ResponseParam()
            {
                Successful = false,
                ResponseCode = ResponseCodes.NOT_PROCESSED,
                Message = null,
                Data = null
            };
        }

        public ResponseParam CommitResponse(string code, string message, object data = null)
        {
            return new ResponseParam()
            {
                Successful = code == "00" ? true : false,
                ResponseCode = code,
                Message = message,
                Data = data == null ? new List<object>() { } : data
            };
        }


        public ResponseParam HandleException(string customMessage = null)
        {
            const string ERR_MESSAGE = "An error occoured. Please try again later or contact admin for resolution";
            return new ResponseParam()
            {
                Successful = false,
                ResponseCode = ResponseCodes.ERROR,
                Message = string.IsNullOrWhiteSpace(customMessage) ? ERR_MESSAGE : $"An exception error occoured. | {customMessage}",
                Data = new List<object>() { }
            };
        }
    }

    public class ResponseParam
    {
        public bool Successful { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class ResponseCodes
    {
        public static readonly string SUCCESS = "00";
        public static readonly string NOT_PROCESSED = "01";
        public static readonly string UNSUCCESSFUL = "02";
        public static readonly string ERROR = "99";
    }
}
