#nullable enable

using System;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Cylinder;

public class VoiceButton : Button
{
    private const int ButtonWidth = 2560;
    private const int ButtonHeight = 83;
    
    public int Hypothesis { get; }
    public bool IsApplied { get; }
    public string Question { get; }
    public string Answer { get; }

    private MediaPlayer? Voice;
    private Brush? defaultBorderBrush;
    private Thickness defaultBorderThickness;

    public VoiceButton(int hNumber, bool applied, string question, string answer, string voice!!)
    {
        Hypothesis = hNumber;
        IsApplied = applied;
        Question = question;
        Answer = answer;

        Loaded += (_, _) =>
        {
            defaultBorderBrush = BorderBrush;
            defaultBorderThickness = BorderThickness;
        };

        Click += async (_, _) => {
            BorderThickness = new(3);
            BorderBrush = new SolidColorBrush(Colors.MediumBlue);

            Voice = new() 
            { 
                Source = MediaSource.CreateFromUri(new(voice)),
                AudioCategory = MediaPlayerAudioCategory.Speech,
            };
            Voice.MediaEnded += async (_, _) =>
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { BorderThickness = defaultBorderThickness; BorderBrush = defaultBorderBrush; });
                Voice.Dispose(); 
            };

            await Task.Delay(1500);
            Voice.Play();
        };

        RightTapped += async (_, _) =>
        {
            Voice?.Pause();
            Voice?.Dispose();
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { BorderThickness = defaultBorderThickness; BorderBrush = defaultBorderBrush; });
            Voice = null;
        };

        Height = ButtonHeight;
        Margin = new(0, 0, 0, 5);
        CornerRadius = new(10);
        VerticalAlignment = VerticalAlignment.Top;

        CreateGrid(out Grid inner, out Grid dday, out Grid outter);
        CreateDdayTextBlock(out TextBlock tb1, out TextBlock tb2);
        dday.Children.Add(tb1);
        dday.Children.Add(tb2);
        inner.Children.Add(dday);

        CreateTaskTextBlock(out TextBlock tb3, out TextBlock tb4);
        inner.Children.Add(tb3);
        inner.Children.Add(tb4);

        CreateArrowTextBlock(out TextBlock arrow);
        outter.Children.Add(inner);
        outter.Children.Add(arrow);

        Content = outter;
    }

    private void CreateArrowTextBlock(out TextBlock arrow)
    {
        arrow = new()
        {
            Text = "\xe768",
            FontFamily = new("../Assets/segoefluent.ttf#Segoe Fluent Icons"),
            FontSize = 17,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Right,
            Margin = new(0, 0, 15, 0)
        };
    }

    private void CreateGrid(out Grid inner, out Grid dday, out Grid outter)
    {
        inner = new()
        {
            Height = 80,
            Width = 2560,
            Margin = new(-12, 0, 0, 0),
            HorizontalAlignment = HorizontalAlignment.Left
        };
        dday = new()
        {
            Width = 65,
            Margin = new(10, 0, 0, 0),
            HorizontalAlignment = HorizontalAlignment.Left
        };
        outter = new();
    }

    private void CreateDdayTextBlock(out TextBlock tb1, out TextBlock tb2)
    {
        tb1 = new()
        {
            FontSize = 19,
            Text = $"H{Hypothesis}",
            Margin = new(0, 10, 0, 46),
            HorizontalAlignment = HorizontalAlignment.Center,
            FontFamily = new("ms-appx:///Assets/ZegoeLight-U.ttf#Segoe"),
            FontWeight = FontWeights.Bold
        };

        tb2 = new()
        {
            FontSize = 15,
            Text = IsApplied ? "YES" : "NO",
            Margin = new(0, 44, 0, 12),
            HorizontalAlignment = HorizontalAlignment.Center,
            FontFamily = new("Consolas"),
            FontWeight = FontWeights.Bold
        };
    }

    private void CreateTaskTextBlock(out TextBlock tb3, out TextBlock tb4)
    {
        tb3 = new()
        {
            FontSize = 17,
            Text = Question,
            Margin = new(80, 12, 0, 44),
            Width = ButtonWidth
        };
        tb4 = new()
        {
            FontSize = 15,
            Text = Answer,
            Margin = new(80, 43, 0, 13),
            HorizontalAlignment = HorizontalAlignment.Left,
            Width = ButtonWidth,
            Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xA0, 0xA0, 0xA0))
        };
    }
}
