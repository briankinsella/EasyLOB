﻿using System.Web.Services.Protocols;

namespace EasyLOB.Library.WebService
{
    public class AuthenticationHeader : SoapHeader
    {
        #region Properties

        public string Username { get; set; }

        public string Password { get; set; }

        #endregion Properties
    }
}