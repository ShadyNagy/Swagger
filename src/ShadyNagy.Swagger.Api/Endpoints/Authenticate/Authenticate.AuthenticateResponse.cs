﻿namespace ShadyNagy.Swagger.Api.Endpoints.Authenticate
{
  public class AuthenticateResponse
  {
    public AuthenticateResponse()
    {
    }
    public bool Result { get; set; }
    public string Token { get; set; } = string.Empty;
  }
}
