using System;

namespace SubtitlesEditor
{
    internal class Subtitle
    {
        public int number { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string text1 { get; set; } = "";
        public string text2 { get; set; } = "";

        public Subtitle() { }

    }
}