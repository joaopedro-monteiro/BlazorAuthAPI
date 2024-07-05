namespace BlazorAuth.Middleware
{
    public class CookieMiddleware
    {
        private readonly RequestDelegate _next;

        public CookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                if (context.Items.ContainsKey("authToken"))
                {
                    var token = context.Items["authToken"].ToString();
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    };
                    context.Response.Cookies.Append("authToken", token, cookieOptions);
                }
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
