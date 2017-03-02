using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Core;
using System.Diagnostics;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Input;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Swell
{


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private Point initialpoint;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            //mainGrid.ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;

        }

        private void Grid_ManipulationStarted_1(object sender, ManipulationStartedRoutedEventArgs e)
        {
            initialpoint = e.Position;
        }

        private void LayoutRoot_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            
            Point currentpoint = e.Position;
            if (currentpoint.X - initialpoint.X >= 200)//200 is the threshold value, where you want to trigger the swipe right event
            {              
                Debug.WriteLine("Swipe Right");
            }
            else if (currentpoint.X - initialpoint.X <= -200)//200 is the threshold value, where you want to trigger the swipe right event
            {
                Debug.WriteLine("Swipe Left");
            }
            else if (currentpoint.Y - initialpoint.Y >= 200)//200 is the threshold value, where you want to trigger the swipe right event
            {
                Debug.WriteLine("Swipe Down");
            }

            

        }           

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        void nextSongComplete(object sender, object e)
        {

        }

        void prevSongComplete(object sender, object e)
        {

        }

        void songchangedXbox(object sender, object e)
        {

        }

        private void image_ImageOpened(object sender, RoutedEventArgs e)
        {
            coverImageLoaded.Begin();
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MediaPlayer lib = new MediaPlayer();

            var folder = Windows.Storage.KnownFolders.MusicLibrary;
            var files = await folder.GetFilesAsync();

            StorageFolder musicFolder = KnownFolders.MusicLibrary;
            IReadOnlyList<StorageFile> fileList = await musicFolder.GetFilesAsync();

            foreach (var file in fileList)
            {
                MusicProperties musicProperties = await file.Properties.GetMusicPropertiesAsync();
           
                Debug.WriteLine("url: " + file.Path);
                Debug.WriteLine("Name: " + file.Name);
                Debug.WriteLine("Name: " + file.Name);
                Debug.WriteLine("Album: " + musicProperties.Album);
                Debug.WriteLine("Rating: " + musicProperties.Rating);
                Debug.WriteLine("Producers: " + musicProperties.Publisher);
            }

            //var files = await folder.GetFilesAsync();
            //Debug.WriteLine("aye");
            //foreach (var test in folder)
            //{
             //   Debug.WriteLine(test.DisplayName);
            //}
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            smallCoverArtRemove.Begin();
        }
    }
}
