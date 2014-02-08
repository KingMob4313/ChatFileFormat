using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    class TempStorage
    {
        public static StringBuilder fileTextContents = new StringBuilder();
        
        public static string enteredNameOne;
        public static string enteredNameTwo;
        public static string enteredNameThree;
        public static string enteredNameFour;

        public static bool? storyTellerCheckOne;
        public static bool? storyTellerCheckTwo;
        public static bool? storyTellerCheckThree;
        public static bool? storyTellerCheckFour;

        public static List<string> mainLocations = new List<string>();
        public static List<string> subLocations = new List<string>();
        public static List<string> npcList = new List<string>();
    }
}
