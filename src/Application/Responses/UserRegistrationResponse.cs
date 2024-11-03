using System.Text.Json.Serialization;
using instakcal_backend.Application.Enums;

namespace instakcal_backend.Application.Responses;

public class UserLoginResponse
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserLoginResponseStatus Code { get; set; }
    public string Token { get; set; }

    
    public UserLoginResponse(UserLoginResponseStatus code , string token)
    {
        Code = code;
        Token = token;  
    }
}