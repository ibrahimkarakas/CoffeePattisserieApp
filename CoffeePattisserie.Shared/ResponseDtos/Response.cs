using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeePattisserie.Shared.ResponseDtos
{
    public class Response<T>
    {
        public bool IsSucceeded { get; set; }
        public int StatusCode { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }
        public static Response<T> Success(T data, int statusCode){
            return new Response<T>{
                Data = data,
                StatusCode = statusCode,
                IsSucceeded = true
            };
        }
        public static Response<T> Success(int statusCode){
            return new Response<T>{
                StatusCode = statusCode,
                Data=default(T),
                IsSucceeded=true
            };
        }
        public static Response<T> Fail(string error, int statusCode){
            return new Response<T>{
                Error=error,
                StatusCode = statusCode,
                IsSucceeded=false
                };
        }
    }
}