using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

/// <summary>
/// Summary description for AuthSoapHd
/// </summary>
public class AuthSoapHd : SoapHeader
{
    public AuthSoapHd()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string strUname;
    private string strPwd;

    public string UserName
    {
        get
        {
            return strUname;
        }
        set
        {
            strUname = value;
        }
    }

    public string Password
    {
        get
        {
            return strPwd;
        }
        set
        {
            strPwd = value;
        }
    }
}