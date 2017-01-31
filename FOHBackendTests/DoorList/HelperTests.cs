using NUnit.Framework;
using FOHBackend.DoorList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOHBackend.DoorList.Tests {
    [TestFixture()]
    public class HelperTests {
        [Test()]
        public void loadCSVTest() {
            List<DoorListEntry> list = Helper.loadCSV(@"C:\Users\jeffp\Documents\testDoorListData.csv");
            
            Helper.printDoorLists(list);

            Console.WriteLine("Door List by Name");
            Console.WriteLine();
            Console.WriteLine();
            foreach (DoorListEntry d in Helper.sortByName(list)) {
                Console.WriteLine(d);
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Door List by Seat");
            Console.WriteLine();
            Console.WriteLine();
            foreach (DoorListEntry d in Helper.sortBySeat(list)) {
                Console.WriteLine(d);
                Console.WriteLine();
            }
            Console.WriteLine();

            Assert.Pass();
        }
    }
}