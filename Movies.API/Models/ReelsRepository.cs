using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.API.Models
{
    public class ReelsRepository
    {
        public IEnumerable<BaseVideo> Reels { get; set; }

        public IEnumerable<BaseVideo> Retrieve()
        {
            var allVideos = new List<BaseVideo>
            {
                new PALVideo("Bud Light", "A factory is working on the new Bud Light Platinum.",
                    VideoDefinitionEnum.Standard, 0, 0, 30, 12),

                new NTSCVideo(@"M&M's", @"At a party, a brown-shelled M&M is mistaken for being naked. As
            a result, the red M & M tears off its skin and dances to 'Sexy and I Know It' by
            LMFAO.", VideoDefinitionEnum.Standard, 0, 0, 15, 27),

                new PALVideo("Audi", @"A group of vampires are having a party in the woods. The
            vampire in charge of drinks(blood types) arrives in his Audi.The bright lights
                of the car kills all of the vampires, with him wondering where everyone went
            afterwards.", VideoDefinitionEnum.Standard, 0, 1, 30, 0),

                new PALVideo("Chrysler",
                    @"Clint Eastwood recounts how the automotive industry survived the Great Recession.",
                    VideoDefinitionEnum.Standard, 0, 0, 10, 14),

                new NTSCVideo("Fiat",
                    @"A man walks through a street to discover a beautiful woman (Catrinel Menghia) standing on a parking space, who proceeds to approach and seduce him, when successfully doing so he then discovered he was about to kiss a Fiat 500 Abarth.",
                    VideoDefinitionEnum.Standard, 0, 0, 18, 11),

                new NTSCVideo("Pepsi",
                    @"People in the Middles Ages try to entertain their king (Elton John) for a Pepsi. While the first person fails, a mysterious person (Season 1 X Factor winner Melanie Amaro) wins the Pepsi by singing Aretha Franklin's 'Respect'. After she wins, she overthrows the king and gives Pepsi to all the town.",
                    VideoDefinitionEnum.Standard, 0, 0, 20, 00),

                new PALVideo("Best Buy",
                    @"An ad featuring the creators of the cameraphone, Siri, and the first text message. The creators of Words with Friends also appear parodying the incident involving Alec Baldwin playing the game on an airplane.",
                    VideoDefinitionEnum.High, 0, 0, 10, 05),

                new PALVideo("Captain America: The First Avenger",
                    @"Video Promo",
                    VideoDefinitionEnum.High, 0, 0, 20, 10),

                new NTSCVideo(@"Volkswagen 'Black Beetle'",
                    @"A computer-generated black beetle runs fast, as it is referencing the new Volkswagen model.",
                    VideoDefinitionEnum.High, 0, 0, 30, 0),
            };

            return allVideos;
        }
    }
}