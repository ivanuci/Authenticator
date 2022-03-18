using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator
{
    public static class GlobalClass
    {
        private static DataBase? _database;
        private static MainWebView? _webview;

        public static DataBase AuDataBase
        {
            get {

                if (_database == null) _database = new DataBase();

                return _database;

            }
        }

        public static MainWebView AuWebView
        {
            get
            {

                if (_webview == null) _webview = new MainWebView();

                return _webview;

            }
        }

    }
}
