﻿using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Media.Imaging;

namespace MovieFinder2025.Models
{
    public class YoutubeItem : ObservableObject
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ChannelTitle { get; set; }
        public string URL { get; set; }
        public BitmapImage Thumbnail { get; set; }
    }
}
