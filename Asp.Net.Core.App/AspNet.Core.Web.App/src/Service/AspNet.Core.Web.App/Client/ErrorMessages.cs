using System.Collections.Concurrent;

namespace AspNet.Core.Web.App.Client
{
    /// <summary>
    /// 
    /// </summary>
    public static class ErrorMessages
    {
        private static ConcurrentDictionary<ErrorMessageKey, string> _sgConnectValidationErrorList;

        /// <summary>
        /// 
        /// </summary>
        public enum ErrorMessageKey
        {
            /// <summary>
            /// 
            /// </summary>
            HeaderMissing = 1000,

            /// <summary>
            /// 
            /// </summary>
            InvalidAccessToken = 1001
        }

        /// <summary>
        /// 
        /// </summary>
        public static ConcurrentDictionary<ErrorMessageKey, string> SgConnectValidationErrorList
        {
            get
            {
                if (_sgConnectValidationErrorList == null)
                {
                    _sgConnectValidationErrorList = new ConcurrentDictionary<ErrorMessageKey, string>();

                    _sgConnectValidationErrorList.TryAdd(ErrorMessageKey.HeaderMissing, "Authorization header is missing");
                    _sgConnectValidationErrorList.TryAdd(ErrorMessageKey.InvalidAccessToken, "Invalid Authorization Header");
                }

                return _sgConnectValidationErrorList;
            }
        }
            


    }
}
