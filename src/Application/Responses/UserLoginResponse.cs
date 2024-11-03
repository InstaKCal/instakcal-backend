using System.Text.Json.Serialization;
using instakcal_backend.Application.Enums;

namespace instakcal_backend.Application.Responses;

public class UserRegistrationResponse
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserRegistrationResponseStatus Code { get; set; }
    
    public UserRegistrationResponse(UserRegistrationResponseStatus code)
    {
        Code = code;
    }
}