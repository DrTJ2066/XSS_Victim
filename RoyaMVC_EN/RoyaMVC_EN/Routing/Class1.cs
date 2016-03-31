using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web;
using System.Text.RegularExpressions;

namespace RoyaMVC.Routing
{
    public class DomainRoute : Route
    {
        // ...

        public string Domain { get; set; }

        // ...

        public override RouteData GetRouteData(HttpContextBase httpContext) {
            // Build regex
            domainRegex = CreateRegex(Domain);
            pathRegex = CreateRegex(Url);

            // Request information
            string requestDomain = httpContext.Request.Headers["host"];
            if (!string.IsNullOrEmpty(requestDomain)) {
                if (requestDomain.IndexOf(":") > 0) {
                    requestDomain = requestDomain.Substring(0, requestDomain.IndexOf(":"));
                }
            }
            else {
                requestDomain = httpContext.Request.Url.Host;
            }
            string requestPath = httpContext.Request.AppRelativeCurrentExecutionFilePath.Substring(2) + httpContext.Request.PathInfo;

            // Match domain and route
            Match domainMatch = domainRegex.Match(requestDomain);
            Match pathMatch = pathRegex.Match(requestPath);

            // Route data
            RouteData data = null;
            if (domainMatch.Success && pathMatch.Success) {
                data = new RouteData(this, RouteHandler);

                // Add defaults first
                if (Defaults != null) {
                    foreach (KeyValuePair<string, object> item in Defaults) {
                        data.Values[item.Key] = item.Value;
                    }
                }

                // Iterate matching domain groups
                for (int i = 1; i < domainMatch.Groups.Count; i++) {
                    Group group = domainMatch.Groups[i];
                    if (group.Success) {
                        string key = domainRegex.GroupNameFromNumber(i);
                        if (!string.IsNullOrEmpty(key) && !char.IsNumber(key, 0)) {
                            if (!string.IsNullOrEmpty(group.Value)) {
                                data.Values[key] = group.Value;
                            }
                        }
                    }
                }

                // Iterate matching path groups
                for (int i = 1; i < pathMatch.Groups.Count; i++) {
                    Group group = pathMatch.Groups[i];
                    if (group.Success) {
                        string key = pathRegex.GroupNameFromNumber(i);
                        if (!string.IsNullOrEmpty(key) && !char.IsNumber(key, 0)) {
                            if (!string.IsNullOrEmpty(group.Value)) {
                                data.Values[key] = group.Value;
                            }
                        }
                    }
                }
            }

            return data;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values) {
            return base.GetVirtualPath(requestContext, RemoveDomainTokens(values));
        }

        public DomainData GetDomainData(RequestContext requestContext, RouteValueDictionary values) {
            // Build hostname
            string hostname = Domain;
            foreach (KeyValuePair<string, object> pair in values) {
                hostname = hostname.Replace("{" + pair.Key + "}", pair.Value.ToString());
            }

            // Return domain data
            return new DomainData {
                Protocol = "http",
                HostName = hostname,
                Fragment = ""
            };
        }

        // ...
    }
}
