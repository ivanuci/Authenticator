
using Microsoft.Web.WebView2.Core;
using System.Diagnostics;

namespace Authenticator
{
    public class MainWebView : Microsoft.Web.WebView2.WinForms.WebView2
    {

        bool WVInitialized = false;

        public MainWebView(): base()
        {
            Dock = DockStyle.Fill;
        }


        async public Task Init(string html) {

            string _cacheFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var webView2Environment = await CoreWebView2Environment.CreateAsync(null, _cacheFolderPath);

            await EnsureCoreWebView2Async(webView2Environment);

            CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;

            CoreWebView2.AddHostObjectToScript("NativeMethods", new NativeMethods());           
            CoreWebView2.NavigateToString(html);

            // Dummy call. Without it I couldn't get addRecords(jrecords) to execute on FormMain loading
            await CoreWebView2.ExecuteScriptAsync("console.log('test')");

            WVInitialized = true;
        }

        async public Task AddRecords(string jrecords) {

            if (WVInitialized) await CoreWebView2.ExecuteScriptAsync("addRecords(" + jrecords + ")");
        }

        async public Task RefreshRecords(string jrecords)
        {
            if (WVInitialized) await CoreWebView2.ExecuteScriptAsync("refreshRecords(" + jrecords + ")");
        }

    }
}
