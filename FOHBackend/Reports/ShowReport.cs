using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOHBackend.Reports {
    public class ShowReport {

        public string Production { get; set; }
        public DateTime ProductionDate { get; set; }

        public CurrencyAUD CashDoorSales { get; set; }
        public CurrencyAUD CashMainBar { get; set; }
        public CurrencyAUD CashWineBar { get; set; }
        public CurrencyAUD CashMembership { get; set; }
        public CurrencyAUD CashKitchen { get; set; }
        public CurrencyAUD CashPrograms { get; set; }

        public CurrencyAUD CashTotal {
            get {
                return CashDoorSales + CashMainBar + CashWineBar + CashMembership + CashKitchen + CashPrograms;
            }
        }

        public CurrencyAUD EFTDoorSales { get; set; }
        public CurrencyAUD EFTMainBar { get; set; }
        public CurrencyAUD EFTWineBar { get; set; }
        public CurrencyAUD EFTMembership { get; set; }
        public CurrencyAUD EFTKitchen { get; set; }
        public CurrencyAUD EFTPrograms { get; set; }

        public CurrencyAUD EFTTotal {
            get {
                return EFTDoorSales + EFTMainBar + EFTWineBar + EFTMembership + EFTKitchen + EFTPrograms;
            }
        }

        public CurrencyAUD TotalDoorSales { get { return CashDoorSales + EFTDoorSales; } }
        public CurrencyAUD TotalMainBar { get { return CashMainBar + EFTMainBar; } }
        public CurrencyAUD TotalWineBar { get { return CashWineBar + EFTWineBar; } }
        public CurrencyAUD TotalMembership { get { return CashMembership + EFTMembership; } }
        public CurrencyAUD TotalKitchen { get { return CashKitchen + EFTKitchen; } }
        public CurrencyAUD TotalPrograms { get { return CashPrograms + EFTPrograms; } }

        public CurrencyAUD GrandTotal {
            get {
                return CashTotal + EFTTotal;
            }
        }

        public CurrencyAUD OnlineTickets { get; set; }

        public CurrencyAUD FloatDoorSales { get; set; }
        public CurrencyAUD FloatMainBar { get; set; }
        public CurrencyAUD FloatWineBar { get; set; }
        public CurrencyAUD FloatKitchen { get; set; }

        public uint OnlineSalesCount { get; set; }
        public uint DoorSalesCount { get; set; }
        public uint NoShowCount { get; set; }
        public uint NewMemberCount { get; set; }
    }
}
