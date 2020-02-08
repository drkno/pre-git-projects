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

#include "KHttp.h"

namespace khttp
{
    // #### KCookie ####
    std::string KCookie::toString()
    {
        return Name + "=" + Value;
    }

    // #### KCookieContainer ####
    void KCookieContainer::addCookie(KCookie cookie){
        for(int i = 0; i < count(); i++){
            if(cookies[i].Name == cookie.Name){
                cookies[i] = cookie;
                return;
            }
        }
        cookies.push_back(cookie);
    }
    void KCookieContainer::addCookie(std::string name, std::string value){
        KCookie cookie;
        cookie.Name = name;
        cookie.Value = value;
        addCookie(cookie);
    }

    bool KCookieContainer::removeCookie(std::string name){
        for(int i = 0; i < count(); i++){
            if(cookies[i].Name == name){
                cookies.erase(cookies.begin()+i);
                return true;
            }
        }
        return false;
    }
    bool KCookieContainer::removeCookie(KCookie cookie){
        return removeCookie(cookie.Name);
    }

    int KCookieContainer::count(){
        return cookies.size();
    }

    std::string KCookieContainer::serializeCookies(){
        std::string result = "";
        for(int i = 0; i < count(); i++){
            result += cookies[i].toString() + ((i+1==count())?"":"&");
        }
        return result;
    }

    CookieCollection KCookieContainer::getCookies() {
        return cookies;
    }

    // #### KHttpResponse ####
    KHttpResponse::KHttpResponse(){}
    KHttpResponse::KHttpResponse(std::string recv, KCookieContainer cookie)
    {
        cookies = cookie;
        parseHtml(recv);
    }

    void KHttpResponse::parseHtml(std::string recv) {
        while(recv.find("\r\n") != std::string::npos)
        {
            recv = recv.replace(recv.find("\r\n"),2,"\n");
        }
        data = recv.substr(recv.find("\n\n")+2);
        ResponseCode = recv.substr(0,recv.find("\n"));
        recv = recv.substr(ResponseCode.length()+1,recv.find("\n\n"));

        std::stringstream ss; ss << recv;
        std::string temp;
        while(!ss.eof())
        {
            temp = "";
            getline(ss, temp);
            if(temp == "")
            {
                break;
            }
            if(temp.substr(0,temp.find(":")).find("Set-Cookie") == std::string::npos)
            {
                HttpHeader hdr;
                hdr.Name = temp.substr(0,temp.find(":"));
                hdr.Value = temp.substr(temp.find(":")+2);
                Headers.push_back(hdr);
            } else {
                if(temp.substr(temp.find(":")+2) == "")
                {
                    continue;
                }
                std::stringstream s1; s1 << temp;
                while(!s1.eof())
                {
                    temp = "";
                    getline(s1,temp,';');
                    KCookie cookie;
                    cookie.Name = temp.substr(0,temp.find("="));
                    cookie.Value = temp.substr(temp.find("=")+1);
                    if (cookie.Name == "Expires") { break; }
                    cookies.addCookie(cookie);
                    if (!s1.eof()) { getline(s1,temp,' '); }
                }
            }
        }

        for (unsigned int i = 0; i < Headers.size(); i++) {
            if (Headers[i].Name == Headers::ContentLength) {
                std::stringstream ss; ss << Headers[i].Value;
                int contentLength; ss >> contentLength;
                data = data.substr(0,contentLength-1);
                break;
            }
        }
    }

    std::vector<HttpHeader> KHttpResponse::getHttpHeaders()
    {
        return Headers;
    }

    std::string KHttpResponse::statusCode()
    {
        return ResponseCode;
    }

    std::string KHttpResponse::toString()
    {
        return data;
    }

    // #### KHttpRequest #####
    std::string KHttpRequest::generatePacket()
    {
        std::string packet = "", temp = Host;

        if(temp.find("http://") != std::string::npos)
        {
            temp = temp.replace(0,7,"");
        }

        Hostname = (temp.find("/") == std::string::npos)?temp:temp.substr(0,temp.find("/"));

        packet += "Host: " + Hostname + "\r\n";
        for(unsigned int i = 0; i < Headers.size(); i++)
        {
            packet += Headers[i].Name + ": " + Headers[i].Value + "\r\n";
        }

        if(Cookies.count() > 0){
            packet += "Cookie: " + Cookies.serializeCookies() + "\r\n";
        }

        temp = (temp.find("/") == std::string::npos)?"/":temp.substr(temp.find("/"));

        packet = Method + " " + temp + " HTTP/1.0\r\n" + packet;

        if(PostData.length() > 0 && Method != "GET")
        {
            packet += "\r\n" + PostData;
        }

        packet += "\r\n";

        return packet;
    }

    void KHttpRequest::setData(std::string data)
    {
        PostData = data;
    }

    void KHttpRequest::setMethod(std::string method)
    {
        Method = method;
    }

    std::string KHttpRequest::getMethod()
    {
        return Method;
    }

    void KHttpRequest::sendPacket(TcpSocketClient& sock, std::string packet)
    {
        sock << packet;
    }

    KHttpResponse KHttpRequest::GetResponse(std::string packet)
    {
        std::string packetData = packet;
        TcpSocketClient httpSocket(Hostname.c_str(), ((port==0)?80:port));
        sendPacket(httpSocket, packetData);
        std::string data=""; packet = "";
        try{
            while(1){
                httpSocket >> packet;
                data += packet;
            }
        } catch(SocketException& e){}

        KHttpResponse rep(data, Cookies);
        return rep;
    }
    KHttpRequest::KHttpRequest() {setPort(80); setMethod("GET"); }
    KHttpRequest::KHttpRequest(std::string host)
    {
        setPort(80);
        setHost(host);
        setMethod("GET");
        setHttpVersion("1.0");
    }

    KHttpRequest::KHttpRequest(std::string host, unsigned int portnum)
    {
        setPort(portnum);
        setHost(host);
        setMethod("GET");
        setHttpVersion("1.0");
    }

    void KHttpRequest::setHost(std::string host)
    {
        Host = host;
    }

    std::string KHttpRequest::getHost()
    {
        return Host;
    }

    std::string KHttpRequest::toString()
    {
        return generatePacket();
    }

    void KHttpRequest::setPort(unsigned int portnum)
    {
        port = portnum;
    }

    unsigned int KHttpRequest::getPort()
    {
        return port;
    }

    void KHttpRequest::addHeader(std::string name, std::string value)
    {
        HttpHeader hdr;
        hdr.Name = name;
        hdr.Value = value;
        Headers.push_back(hdr);
    }

    KHttpResponse KHttpRequest::GetResponse()
    {
        return GetResponse(generatePacket());
    }

    KHttpRequest& KHttpRequest::operator << (const std::string& data)
    {
        Method = "POST";
        PostData = data;
        return *this;
    }

    void KHttpRequest::setPostData(std::string data)
    {
        PostData = data;
        addHeader(data.length());
        Method = "POST";
    }

    void KHttpRequest::setHttpVersion(std::string version)
    {
        if (version != "1.0") {
            //#warning Only HTTP 1.0 is implemented at this point
        }

        HttpVersion = version;
    }
}
