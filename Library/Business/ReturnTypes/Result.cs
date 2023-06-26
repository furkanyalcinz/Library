using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ReturnTypes
{
    public class DataResult<T>:IDataResult<T>,IResult where T : class
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public DataResult(bool success, string? message = null, T? data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }


    public interface IDataResult<T> where T : class
    {

    }

    public class Result:IResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Result(bool success, string? message = null)
        {
            Success = success;
            Message = message;
        }
    }
    public interface IResult
    {

    }
}
