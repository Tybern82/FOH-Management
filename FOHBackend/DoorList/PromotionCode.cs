using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOHBackend.DoorList {

    public class PromotionCode {
        public string promoCode { get; set; }
        public string promoName { get; set; }
        public bool hasFreeDrink { get; set; }

        public PromotionCode(string code, string name, bool freeDrink) {
            this.promoCode = code;
            this.promoName = (name == null) ? code : name;
            this.hasFreeDrink = freeDrink;
        }

        public PromotionCode(string code, string name) : this(code, name, false) {
            // TODO: Update to request free-drink status of unknown promo codes
            switch (code) {
                case "door":
                case "doorlcm":
                case "Comp1":
                case "Comp1lcm":
                case "Prepaid":
                case "Prepaidlcm":
                case "zpac100":
                case "":
                    hasFreeDrink = false;
                    break;

                default:
                    hasFreeDrink = true;
                    break;
            }
        }
    }
}
