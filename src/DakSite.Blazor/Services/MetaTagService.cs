using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace DakSite.Blazor.Services
{
    public class MetaTagService
    {
        private readonly IJSRuntime _jsRuntime;

        public MetaTagService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public void Set(string name, string content)
        {
            var script = $@"
                var meta = document.querySelector('meta[name=""{name}""]');

                if (meta) {{
                    meta.content = '{content}';
                }} else {{
                    meta = document.createElement('meta');
                    meta.name = '{name}';
                    meta.content = '{content}';
                    document.head.appendChild(meta);
                }}
            ";

            _jsRuntime.InvokeVoidAsync("eval", script);
        }

        public void Remove(string name)
        {
            var script = $@"
                var meta = document.querySelector('meta[name=""{name}""]');
                if (meta) {{
                    meta.remove();
                }}
            ";

            _jsRuntime.InvokeVoidAsync("eval", script);
        }
    }
}
