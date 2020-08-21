using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using YoutubeApi.Models;
using Video = YoutubeApi.Models.Video;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace YoutubeApi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private YouTubeService youtubeService = new YouTubeService(new BaseClientService.Initializer { 
        ApiKey ="AIzaSyBiHEgO0GmNolX - B1P1Y7NYS8qjM11fYa4",ApplicationName="yotube"
        });
        List<Video> ListVideo = new List<Video>();
        private string tokennextpage = null, tokenprivpage = null;
        public MainPage()
        {
            this.InitializeComponent();
            GetVideo();
        }
        private async void GetVideo(string PageToken = null)
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    var Request = youtubeService.Search.List("snippet");
                    Request.ChannelId = "UCTF0ldaORTbCfx2ahvFfYWg";
                    Request.MaxResults = 25;
                    Request.Type = "video";
                    Request.Order = SearchResource.ListRequest.OrderEnum.Date;
                    Request.PageToken = PageToken;
                    var Result = await Request.ExecuteAsync();
                    if (Result.NextPageToken != null)
                        tokennextpage = Result.NextPageToken;
                    if (Result.PrevPageToken != null)
                        tokenprivpage = Result.PrevPageToken;
                    foreach(var item  in Result.Items)
                    {
                        ListVideo.Add(new Video
                        {
                            title = item.Snippet.Title,
                        id = item.Id.VideoId,
                            Img = item.Snippet.Thumbnails.Default__.Url
                        });
                    }
                    lv.ItemsSource = null;
                    lv.ItemsSource = ListVideo;
                }
                else
                {
                    MessageDialog msg = new MessageDialog("Kiem Tra Duong Truyen Mang");
                    await msg.ShowAsync();
                }
            }
            catch { }
        }
        private void lv_ItemClick(object sender, ItemClickEventArgs e)
        {
            Google.Apis.YouTube.v3.Data.Video video = e.ClickedItem as Google.Apis.YouTube.v3.Data.Video;
            Frame.Navigate(typeof(VideoPage), video);
        }
    }
}
