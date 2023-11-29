namespace Labs6_7.Web.Responses;
    public record AuthResponse(string CustomerId, string UserFirstname, string AccessToken, long Expires);
