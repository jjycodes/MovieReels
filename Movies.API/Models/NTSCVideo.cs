namespace Movies.API.Models
{
    public class NTSCVideo : BaseVideo
    {
        private const int frameRate = 30;
        
        public NTSCVideo(string name, string description, VideoDefinitionEnum definition, int hours, int minutes, int seconds, int frames) : base (name, description, definition)
        {
            Standard = VideoStandardEnum.NTSC;
            TimeCode = new TimeCode(hours, minutes, seconds, frames, frameRate);
        }

        public override void Display(string output)
        {
            base.Display(Definition == VideoDefinitionEnum.High
                ? $"NTSC HD - {TimeCode.ToString()}, Framerate - {frameRate}"
                : $"NTSC SD - {TimeCode.ToString()}, Framerate - {frameRate}");
        }
    }
}
