using System.Diagnostics;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Debug.WriteLine("hellooooooooooooooooooooo");
app.Run(async (HttpContext context) => {

context.Response.Headers.Add("Content-type","text/html");
var requestpath = context.Request.Path;
var reqHost = context.Request.Host;
var regMethod = context.Request.Method;
var reqQuery = context.Request.Query["name"];
var reqHeaders = context.Request.Headers;

if (regMethod=="GET"){
    //http://localhost:5160/user
    if(requestpath=="/user"){
        await context.Response.WriteAsync($"<div>{requestpath}</div>");
        await context.Response.WriteAsync($"<div>{regMethod}</div>");
        await context.Response.WriteAsync($"<div>request1</div>");
    }
    //http://localhost:5160/
    else if(requestpath=="/" && string.IsNullOrEmpty(reqQuery)){
        await context.Response.WriteAsync($"<div>{requestpath}</div>");
        await context.Response.WriteAsync($"<div>{regMethod}</div>");
        await context.Response.WriteAsync($"<div>request2</div>");
    }
    //http://localhost:5160/?name=hirun
     else if(!string.IsNullOrEmpty(reqQuery) && reqQuery == "hirun"){
        await context.Response.WriteAsync($"<div>{requestpath}</div>");
        await context.Response.WriteAsync($"<div>{regMethod}</div>");
        await context.Response.WriteAsync($"<div>request3</div>");
    }
    //http://localhost:5160/allheaders
    else if (requestpath=="/allheaders"){
        foreach(var header in reqHeaders){
            await context.Response.WriteAsync($"<div>{header.Key}" + $"{header.Value}</div>");
        }
    }
}
});
app.Run();
