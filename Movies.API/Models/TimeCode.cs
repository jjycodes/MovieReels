using System;

namespace Movies.API.Models
{
    public class TimeCode
    {
        public TimeCode(int hours, int minutes, int seconds, int frames, short frameRate = 25)
        {
            int totalFrames = frames;
            totalFrames += seconds * frameRate;
            totalFrames += minutes * 60 * frameRate;
            totalFrames += hours * 60 * 60 * frameRate;

            TotalFrames = totalFrames % FramesPerDay(frameRate);
            FrameRate = frameRate;

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            Frames = (int)totalFrames % frameRate;
            TimeCodeString = ToString();
        }

        public TimeCode(int totalFrames, short frameRate = 25)
        {
            if (frameRate <= 0) throw new ArgumentOutOfRangeException("frameRate");

            TotalFrames = totalFrames % FramesPerDay(frameRate);
            FrameRate = frameRate;
            Frames = (int)totalFrames % frameRate;
            Seconds = (int)TotalFrames / FrameRate % 60;
            Minutes = (int)TotalFrames / FrameRate / 60 % 60;
            Hours = (int)TotalFrames / FrameRate / 60 / 60;
        }

        /// <summary>
        /// The hours segment of the timecode.
        /// </summary>
        public int Hours { get; set; }

        /// <summary>
        /// The minutes segment of the timecode.
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// The seconds segment of the timecode.
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// The frames segment of the timecode.
        /// </summary>
        public int Frames { get; set; }

        /// <summary>
        /// The total number of frames for this timecode.
        /// </summary>
        public int TotalFrames { get; set; }

        /// <summary>
        /// The framerate of this timecode.
        /// </summary>
        public short FrameRate { get; set; }

        public string TimeCodeString { get; set; }

        /// <summary>
        /// The total number of seconds in this timecode.
        /// </summary>
        /// <returns></returns>
        public float TotalSeconds { get; private set; }

        private static int FramesPerDay(short framesPerSecond)
        {
            return framesPerSecond * 60 * 60 * 24;
        }

        private static string PadTimecodeUnit(int unit, int places = 2)
        {
            return unit.ToString().PadLeft(2, '0');
        }

        public string ToString()
        {
            return string.Format("{0}:{1}:{2}:{3}",
                PadTimecodeUnit(Hours),
                PadTimecodeUnit(Minutes),
                PadTimecodeUnit(Seconds),
                PadTimecodeUnit(Frames));
        }
    }
}
