using System;
using System.IO;

namespace Bible.tools
{
    class Constants
    {
        // Paths
        public static String jsonPath = Path.GetFullPath("resources\\books.json");
        public static String bookPath = Path.GetFullPath("resources\\books\\");

        // Book numbers
        public static String maxBookChapter = "150"; // Max value to chapters
        public static String maxBookVerse = "176"; // Max value to verse
        public static int maxBookName = 12; // Max value of book name
    }
}
