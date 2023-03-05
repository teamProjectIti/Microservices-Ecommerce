﻿
namespace Dto.Common
{
    public class AjexResult
    {
        public static string CatchError(Exception ex)
        {
#if DEBUG

            return new AjexResult(ex.Message).ToJsonNS();

#else            
            ////if (ex.Message.StartsWith("<x>"))
            if (ex.GetType() == typeof(FMSUserExeption))            
                return (new AjaxResult(ex.Message)).ToJsonNS();            
            else
                return (new AjaxResult("We are sorry, something went wrong and we are working on it now").ToJsonNS());
#endif
        }

        public static AjexResult CatchExError(Exception ex)
        {
#if DEBUG

            return new AjexResult(ex.Message);

#else            
            ////if (ex.Message.StartsWith("<x>"))
            if (ex.GetType() == typeof(FMSUserExeption))            
                return (new AjaxResult(ex.Message));            
            else
                return (new AjaxResult("We are sorry, something went wrong and we are working on it now"));
#endif
        }


        public static string CatchError(Exception ex, string ErrorKey)
        {
#if DEBUG

            return new AjexResult("Unexpected error", new ServerParam(ErrorKey, ex.Message)).ToJsonNS();

#else

            //if (ex.Message.StartsWith("<x>"))
            if (ex.GetType() == typeof(FMSUserExeption))
            {
                return (new AjaxResult("Server error", new ServerParam(ErrorKey, ex.Message)).ToJsonNS());
            }
            else
                return (new AjaxResult("Server error", new ServerParam(ErrorKey, "Server error - please try later.")).ToJsonNS());
#endif
        }

        public static void ThrowUserMessage(string strMsg)
        {
            throw new FMSUserExeption(strMsg);
        }


        public string Status { set; get; }
        public string ErrorMessage { set; get; }
        public bool IsError { set; get; }
        public Dictionary<string, object> ServerParams { set; get; }

        public AjexResult()
        {
            ServerParams = new Dictionary<string, object>();
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="ServerParams">Parameters that passes to client </param>
        public AjexResult(string ErrorMessage, params ServerParam[] ServerParams)
        {
            this.ServerParams = new Dictionary<string, object>();
            this.ErrorMessage = ErrorMessage;
            IsError = true;
            Status = "Fail";

            if (ServerParams.Length > 0)
                foreach (ServerParam par in ServerParams)
                    this.ServerParams.Add(par.Key, par.Value);
        }


        /// <summary>
        /// Use it when the result is success .
        /// it set IsError Property to false, ErrorMessage to null And Status to success 
        /// </summary>
        /// <param name="ServerParams"></param>
        public AjexResult(params ServerParam[] ServerParams)
        {
            this.ServerParams = new Dictionary<string, object>();
            IsError = false;
            Status = "Success";
            if (ServerParams.Length > 0)
                foreach (ServerParam par in ServerParams)
                    this.ServerParams.Add(par.Key, par.Value);
        }

        /// <summary>
        /// used when the result is one object and success with only one server parameter with supported name. 
        /// </summary>
        /// <param name="param"></param>
        public AjexResult(string resultKey, object resultValue)
            : this(new ServerParam(resultKey, resultValue))
        {

        }

        /// <summary>
        /// Used To Add Parameter in the AjaxResult object. 
        /// </summary>
        public void AddParameter(ServerParam param)
        {
            if (param != null && ServerParams != null)
                ServerParams.Add(param.Key, param.Value);
        }

        public void AddParameter(string Key, object Value)
        {
            if (Value != null)
                ServerParams.Add(Key, Value);
        }

        /// <summary>
        /// Used To Add Parameters in the AjaxResult object.
        /// </summary>
        public void AddParameters(IList<ServerParam> parameters)
        {
            if (parameters != null)
                foreach (ServerParam param in parameters)
                    if (param != null)
                        ServerParams.Add(param.Key, param.Value);
        }

        /// <summary>
        /// Convert This object to json 
        /// </summary>
        /// <param name="handleReferenceLooping"> To handle references that cause looping. </param>
        /// <returns></returns>
        public string ResultToJson(bool handleReferenceLooping = true)
        {
            return this.ToJsonNS(handleReferenceLooping);
        }

        public static implicit operator AjexResult(string ErrorMessage)
        {
            return new AjexResult(ErrorMessage);
        }

        public static implicit operator AjexResult(bool result)
        {
            return result ? new AjexResult() : new AjexResult("Sorry, Server Error. ");
        }


        public static AjexResult operator +(AjexResult obj, ServerParam parameter)
        {
            obj.AddParameter(parameter);
            return obj;
        }

        public static AjexResult operator -(AjexResult obj, string key)
        {
            obj.ServerParams.Remove(key);
            return obj;
        }


        public static string ReturnSingleResult<T>(T pram, bool error = false, string errorMsg = "")
        {
            if (error)
            {
                var res = new AjexResult();
                res += new ServerParam("P", pram);
                res.IsError = true;
                res.ErrorMessage = errorMsg;
                return res.ToJsonNS();
            }
            else
            {
                return new AjexResult(new ServerParam("P", pram)).ToJsonNS();
            }

        }

    }

    public class ServerParam
    {
        public string Key { set; get; }
        public object Value { set; get; }

        public ServerParam()
        {

        }

        public ServerParam(string key, object value)
        {
            Key = key;
            Value = value;
        }

    }

    public class ClientBag : Dictionary<string, object>
    {
        public ClientBag()
        {

        }

        public ClientBag(string key, object val)
        {
            Add(key, val);
        }

        public ClientBag(params ServerParam[] parameters)
        {
            foreach (ServerParam parameter in parameters)
                Add(parameter.Key, parameter.Value);
        }

        public static ClientBag operator +(ClientBag obj, ServerParam parameter)
        {
            obj.Add(parameter.Key, parameter.Value);
            return obj;
        }

        public static ClientBag operator -(ClientBag obj, string key)
        {
            obj.Remove(key);
            return obj;
        }



    }

    public class FMSUserExeption : Exception
    {
        public object ErrorList { get; set; }
        public FMSUserExeption() : base()
        {

        }

        public FMSUserExeption(string message) : base(message)
        {

        }

        public FMSUserExeption(string message, object errorList) : base(message)
        {
            ErrorList = errorList;
        }

        public FMSUserExeption(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
