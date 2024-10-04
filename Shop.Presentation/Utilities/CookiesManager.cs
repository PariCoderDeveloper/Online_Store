namespace Shop.Presentation.Utilities
{
    public class CookiesManager
    {
        public void Add(HttpContext context, string token , string value)
        {
            context.Response.Cookies.Append(token, value , getCookieOption(context));
        }

        public bool Contains(HttpContext context,string token)
        {
            return context.Request.Cookies.ContainsKey(token);
        }

        public string GetValue(HttpContext context, string token)
        {
            string Value = "";
            if (!context.Request.Cookies.TryGetValue(token, out Value))
            {
                return null;
            }
            return Value;
        }

        public void Remove(HttpContext context, string token)
        {
            if (context.Request.Cookies.ContainsKey(token))
            {
                context.Response.Cookies.Delete(token);
            }
        }
        
        public Guid GetBrowserId(HttpContext context)
        {
            string browserId = GetValue(context, "BrowserId");
            if (browserId == null)
            {
                browserId = Guid.NewGuid().ToString();
                Add(context, "BrowserId", browserId);
            }
            Guid guid;
            Guid.TryParse(browserId, out guid);
            return guid;
        }

        private CookieOptions getCookieOption(HttpContext context)
        {
            return new CookieOptions { 
                Path = context.Request.PathBase.HasValue ? context.Request.PathBase.ToString() : "/",
                Secure = context.Request.IsHttps,
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(100)
            };
        }
    }
}
