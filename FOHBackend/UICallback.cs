using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOHBackend {

    public interface FOHBackendCallback {
        string RequestString(string msg, string suggestedString);

        Settingsv3 InitialSettings(Settingsv3 defaultSettings);

        void warningMessage(string msg);
    }

    public class FOHBackendCallbackManager {
        private FOHBackendCallbackManager() {}
        public static readonly FOHBackendCallbackManager CallbackManager = new FOHBackendCallbackManager();

        public static FOHBackendCallback registerCallback(FOHBackendCallback cb) {
            FOHBackendCallback _result = CallbackManager.callback;
            CallbackManager.callback = cb;
            return _result;
        }

        public static bool unregisterCallback(FOHBackendCallback cb) {
            if (CallbackManager.callback == cb) {
                CallbackManager.callback = null;
                return true;
            }
            return false;
        }

        FOHBackendCallback callback = null;

        public string doRequestString(string msg, string suggestedString) {
            return (callback != null) ? callback.RequestString(msg, suggestedString) : suggestedString;
        }

        public Settingsv3 triggerInitialSettings(Settingsv3 s) {
            return (callback != null) ? callback.InitialSettings(s) : s;
        }

        public void warningMessage(string msg) {
            if (callback != null) callback.warningMessage(msg);
        }
    }
}
