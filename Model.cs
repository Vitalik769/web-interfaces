using System;
using System.Collections.Generic;
using System.Net;


public class APIResponse<T>
{
    public string Message { get; set; }
    public List<T> Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    // Class constructor that initializes a new instance of the class and initializes the Generic List Data.
    public APIResponse()
    {
        Data = new List<T>();
    }
}

