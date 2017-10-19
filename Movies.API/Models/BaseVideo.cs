using System;

namespace Movies.API.Models
{
    public abstract class BaseVideo : IVideoDefinition
    {
        protected BaseVideo(string name, string description, VideoDefinitionEnum definition)
        {
            Name = name;
            Description = description;
            Definition = definition;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public TimeCode TimeCode { get; set; }
        public VideoDefinitionEnum Definition { get; set; }
        public VideoStandardEnum Standard { get; set; }

        public virtual void Display(string output)
        {
            Console.WriteLine($"Output : {output}");
        }
        
    }
}
