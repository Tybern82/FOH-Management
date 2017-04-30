using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace FOHManagerUI {
    public class DownloadHandler : IDownloadHandler {
        public event EventHandler<DownloadItem> OnBeforeDownloadFired;

        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;

        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback) {
            OnBeforeDownloadFired?.Invoke(this, downloadItem);

            if (!callback.IsDisposed) {
                using (callback) {
                    // System.Console.WriteLine("File: <" + downloadItem.SuggestedFileName + ">");
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: !MainWindow.doPrintAuto);
                }
            }
        }

        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback) {
            OnDownloadUpdatedFired?.Invoke(this, downloadItem);
        }
    }
}
