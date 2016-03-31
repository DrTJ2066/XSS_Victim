using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN.Models
{
    public class RoyaSlider
    {
        public long IDSlider { get; set; }
        public string DateTimeAdded { get; set; }
        public DateTime DateTimeAddedGregorian { get; set; }
        public string SliderTitle { get; set; }
        public string PauseTime { get; set; }
        public string SliderEffect { get; set; }
        public string SelectedTheme { get; set; }
        public bool PauseOnHover { get; set; }
        public bool UseThumbnailsForNavigation { get; set; }
        public string SliderWidth { get; set; }
        public string SliderHeight { get; set; }
        public bool ShowThumbnails { get; set; }
        public bool ShowCaptions { get; set; }

        public List<RoyaSliderItems> Items { get; set; }


        public RoyaSlider() {
            this.Items = new List<RoyaSliderItems>();
            this.IDSlider = -1;
        }
    }

    public class RoyaSliderItems
    {
        public int ItemIndex { get; set; }
        /// <summary>
        /// self, new window, ?!
        /// </summary>
        public string LinkTarget { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsImageLink { get; set; }
        public string ImagePath { get; set; }
        public string ThumbnailPath { get; set; }

        public byte[] SliderImageContent { get; set; }
        public byte[] SliderThumbnailImage { get; set; }
        public bool IsPublished { get; set; }
    }
}
