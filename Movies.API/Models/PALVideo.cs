namespace Movies.API.Models
{
    public class PALVideo : BaseVideo
    {
        private const int frameRate = 25;

        public PALVideo(string name, string description, VideoDefinitionEnum definition, int hours, int minutes, int seconds, int frames) : base(name, description, definition)
        {
            Standard = VideoStandardEnum.PAL;
            TimeCode = new TimeCode(hours, minutes, seconds, frames, frameRate);
        }

        public override void Display(string output)
        {
            base.Display(Definition == VideoDefinitionEnum.High
                ? $"PAL HD - {TimeCode.ToString()}, Framerate - {frameRate}"
                : $"PAL SD - {TimeCode.ToString()}, Framerate - {frameRate}");
        }
        
    }
}
