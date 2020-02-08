#pragma once
#ifndef include_khttp
#define include_khttp 1.0

/*
    kHttp: KnoxHttp
    Library for HTTP server communication in OOC++
    Version 1.0
    Authour: Matthew Knox
    Copyright Matthew Knox 2011 to Present.

    You are free to distribute, modify, copy, sell
    and do whatever you like with this code as long
    as this notice remains attached to the code.

    NOTE: This is for HTTP 1.0 not 1.1 as 1.1 delivers
    trucked data which I have no idea how to handle
    in c++.
*/

#include "TcpSocketClient.h"

#define HeaderCollection std::vector<HttpHeader>
#define CookieCollection std::vector<KCookie>

using namespace Sockets;

namespace khttp
{
    struct HttpHeader
    {
        std::string Name, Value;
    };

    struct KCookie
    {
        std::string Name;
        std::string Value;
        std::string toString();
    };

    class KCookieContainer
    {
        private:
            CookieCollection cookies;
        public:
            void addCookie(KCookie cookie);
            void addCookie(std::string name, std::string value);
            bool removeCookie(std::string name);
            bool removeCookie(KCookie cookie);
            int count();
            std::string serializeCookies();
            CookieCollection getCookies();
    };

    class KHttpResponse
    {
        protected:
            std::string data, ResponseCode;
            HeaderCollection Headers;
            KCookieContainer cookies;
        public:
            KHttpResponse();
            KHttpResponse(std::string recv, KCookieContainer cookie);
            HeaderCollection getHttpHeaders();
            std::string statusCode();
            std::string toString();
            void parseHtml(std::string recv);
    };

    class KHttpRequest
    {
        protected:
            std::string Host, Hostname, Method, PostData, HttpVersion="1.1";
            HeaderCollection Headers;
            unsigned int port;
            virtual std::string generatePacket();
            void setData(std::string data);
            void setMethod(std::string method);
            std::string getMethod();
            void sendPacket(TcpSocketClient& sock, std::string packet);
            KHttpResponse GetResponse(std::string packet);

        public:
            KCookieContainer Cookies;
            KHttpRequest();
            KHttpRequest(std::string host);
            KHttpRequest(std::string host, unsigned int portnum);
            void setHost(std::string host);
            std::string getHost();
            std::string toString();
            void setPort(unsigned int portnum);
            unsigned int getPort();
            void addHeader(std::string name, std::string value);
            KHttpResponse GetResponse();
            KHttpRequest& operator << (const std::string&);
            void setPostData(std::string data);
            void setHttpVersion(std::string version);
    };

    namespace Method
    {
        static const std::string Post = "POST", Get = "GET";
    }

    namespace Headers
    {
        static const std::string Accept = "Accept",
        AcceptCharset = "Accept-Charset",
        AcceptEncoding = "Accept-Encoding",
        AcceptLanguage = "Accept-Language",
        AcceptDatetime = "Accept-Datetime",
        Authorization = "Authorization",
        AccessControlAllowOrigin = "Access-Control-Allow-Origin",
        AcceptRanges = "Accept-Ranges",
        Age = "Age",
        Allow = "Allow",
        CacheControl = "Cache-Control",
        Connection = "Connection",
        Cookie = "Cookie",
        ContentLength = "Content-Length",
        ContentMD5 = "Content-MD5",
        ContentType = "Content-Type",
        ContentEncoding = "Content-Encoding",
        ContentLanguage = "Content-Language",
        ContentLocation = "Content-Location",
        ContentDisposition = "Content-Disposition",
        ContentRange = "Content-Range",
        Date = "Date",
        DNT = "DNT",
        Expect = "Expect",
        ETag = "ETag",
        Expires = "Expires",
        From = "From",
        FrontEndHttps = "Front-End-Https",
        IfMatch = "If-Match",
        IfModifiedSince = "If-Modified-Since",
        IfNoneMatch = "If-None-Match",
        IfRange = "If-Range",
        IfUnmodifiedSince = "If-Unmodified-Since",
        LastModified = "Last-Modified",
        Link = "Link",
        Location = "Location",
        MaxForwards = "Max-Forwards",
        Origin = "Origin",
        Pragma = "Pragma",
        ProxyAuthorization = "Proxy-Authorization",
        ProxyConnection = "Proxy-Connection",
        P3P = "P3P",
        ProxyAuthenticate = "Proxy-Authenticate",
        Range = "Range",
        Referer = "Referer",
        Refresh = "Refresh",
        RetryAfter = "Retry-After",
        Server = "Server",
        SetCookie = "Set-Cookie",
        Status = "Status",
        StrictTransportSecurity = "Strict-Transport-Security",
        TE = "TE",
        Upgrade = "Upgrade",
        UserAgent = "User-Agent",
        Trailer = "Trailer",
        TransferEncoding = "Transfer-Encoding",
        Vary = "Vary",
        Via = "Via",
        Warning = "Warning",
        WWWAuthenticate = "WWW-Authenticate",
        XFrameOptions = "X-Frame-Options",
        XXSSProtection = "X-XSS-Protection",
        XContentTypeOptions = "X-Content-Type-Options",
        XPoweredBy = "X-Powered-By",
        XUACompatible = "X-UA-Compatible",
        XRequestedWith = "X-Requested-With",
        XForwardedFor = "X-Forwarded-For",
        XForwardedProto = "X-Forwarded-Proto",
        XATTDeviceId = "X-ATT-DeviceId",
        XWapProfile = "X-Wap-Profile";
    }
}
#endif
