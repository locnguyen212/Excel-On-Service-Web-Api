namespace CallCenter.Utils.Helpers
{
    public static class EmailBody
    {
        public static string EmailStringBody(string email, string emailToken)
        {
            return $@"
<html>
  <head>  
  </head>
  <body>
    <span class=""preheader"">This is preheader text. Some clients will show this text as a preview.</span>
    <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""body"">
      <tr>
        <td>&nbsp;</td>
        <td class=""container"">
          <div class=""content"">

            <table role=""presentation"" class=""main"">

              <tr>
                <td class=""wrapper"">
                  <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                    <tr>
                      <td>
                        <p>Hi there,</p>
                        <p>Here is your reset password mail</p>
                        <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""btn btn-primary"">
                          <tbody>
                            <tr>
                              <td align=""left"">
                                <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                  <tbody>
                                    <tr>
                                      <td> <a href=""http://localhost:4200/reset?email={email}&token={emailToken}"" target=""_blank"">Reset Password</a> </td>
                                    </tr>
                                  </tbody>
                                </table>
                              </td>
                            </tr>
                          </tbody>
                        </table>
                        <p>Click reset password to continue changing password.</p>
                        <p>Good luck!.</p>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>

            </table>      
          </div>
        </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </body>
</html>";
        }

        public static string EmailConfirmStringBody(string email, string emailToken)
        {
            return $@"
<html>
  <head>  
  </head>
  <body>
    <span class=""preheader"">This is preheader text. Some clients will show this text as a preview.</span>
    <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""body"">
      <tr>
        <td>&nbsp;</td>
        <td class=""container"">
          <div class=""content"">

            <table role=""presentation"" class=""main"">

              <tr>
                <td class=""wrapper"">
                  <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                    <tr>
                      <td>
                        <p>Hi there,</p>
                        <p>Here is your account active mail</p>
                        <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""btn btn-primary"">
                          <tbody>
                            <tr>
                              <td align=""left"">
                                <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                  <tbody>
                                    <tr>
                                      <td> <a href=""http://localhost:4200/confirm?email={email}&token={emailToken}"" target=""_blank"">Active account</a> </td>
                                    </tr>
                                  </tbody>
                                </table>
                              </td>
                            </tr>
                          </tbody>
                        </table>
                        <p>Click active account to continue.</p>
                        <p>Good luck!.</p>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>

            </table>      
          </div>
        </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </body>
</html>";
        }
    }
}



