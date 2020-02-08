#include <iostream>
#include "khttp.h"

using namespace std;
using namespace khttp;

int main(){

    string url;
    cout << "Please type the URL you want the page source and headers for:\n";
    getline(cin,url);

    try
    {
        KHttpRequest http;
        http.setHost(url);
        http.addHeader(Headers::UserAgent,"GetSource 1/0");

        cout << http.toString() << "\n\n";

        KHttpResponse resp = http.GetResponse();
        cout << resp.statusCode() << "\n";
        HeaderCollection hdrs = resp.getHttpHeaders();
        for(unsigned int i = 0; i < hdrs.size(); i++)
        {
            cout << hdrs[i].Name << ": " << hdrs[i].Value << "\n";
        }
        cout << "\n\n" << resp.toString();
    }
    catch (SocketException& e)
    {
        cout << "An error occured: " << e.description();
    }

    return 0;
}
