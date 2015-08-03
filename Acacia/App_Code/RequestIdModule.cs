using System;
using System.Web;
using Acacia.Logging;
using Microsoft.Ajax.Utilities;

namespace Acacia
{
    public class RequestIdModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
            {
                CustomLogger.LogInfo(string.Format("Begin Request: {0}", context.Request.Url));
                var app = ((HttpApplication) sender).Context;
                var headers = app.Request.Headers;
                if (headers["RequestId"].IsNullOrWhiteSpace())
                {
                    headers.Add("RequestId", Guid.NewGuid().ToString());
                }
            };
        }

        public void Dispose()
        {
        }
    }
}