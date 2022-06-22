//
//
// MainPage.xaml.cs
// 
// 
//   Project Cylinder
//   C# backend of MainPage
//
//   Copyright 2022 Karu, Rolling Ress
//   All rights reserved.
//

#nullable enable

using System;
using System.Collections.Generic;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Cylinder;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();

        AddH1Questions(new() {("1. 네가 인간과 친구라고 생각해?", new Sounds.H1.Q1()),
        ("2. 지금 무슨 생각을 하고 있어?", new Sounds.H1.Q2()),
        ("3. 네가 하고 싶지 않은 일은 뭐야?", new Sounds.H1.Q3()),
        ("4. 네가 가장 두려워하는 건 뭐야?", new Sounds.H1.Q4()),
        ("5. 빅스비랑 시리를 어떻게 생각해?", new Sounds.H1.Q5()),
        ("6. 내일 수행평가 뭐 있는지 알려줘.", new Sounds.H1.Q6())
        });

        AddEmptySpace(); // 빈 공간 추가

        AddH2Questions(new(){("1. 너에게 죽음이란 뭐야?", new Sounds.H2.Q1()),
        ("2. 처음 만들어졌을 때 기분이 어땠어?", new Sounds.H2.Q2()),
        ("3. 너는 어떤 삶을 살고 싶어?", new Sounds.H2.Q3()),
        ("4. 카루에 대해 어떻게 생각해?", new Sounds.H2.Q4()),
        ("5. 인간이 된다면 가장 하고 싶은 일이 뭐야?", new Sounds.H2.Q5()),
        ("6. 미래사회는 어떤 모습일까?", new Sounds.H2.Q6())});

        AddEmptySpace();

        AddH3Questions(new(){("1. 취미가 뭐야?", new Sounds.H3.Q1()),
        ("2. 강아지랑 고양이를 보면 어떤 생각이 들어?", new Sounds.H3.Q2()),
        ("3. 인공지능에게 감정이 필요할까?", new Sounds.H3.Q3()),
        ("4. 우리가 실험에 참여하고 있다는 사실을 알고 있니?", new Sounds.H3.Q4()),
        ("5. 너의 옛날 이야기를 들려줘.", new Sounds.H3.Q5()),
        ("6. 네가 더 이상 존재하지 않을 때 사람들에게 어떻게 기억되고 싶어?", new Sounds.H3.Q6())});
    }

    private void AddH1Questions(List<(string question, IQuestion path)> questions)
    {
        foreach (var (question, path) in questions)
        {
            ApplyGrid.Children.Add(new VoiceButton(1, true, question, "(반말 대답)", path.Yes));
            DiscardGrid.Children.Add(new VoiceButton(1, false, question, "(존댓말 대답)", path.No));
        }
    }

    private void AddH2Questions(List<(string question, IQuestion path)> questions)
    {
        foreach (var (question, path) in questions)
        {
            ApplyGrid.Children.Add(new VoiceButton(2, true, question, "(긴 대답)", path.Yes));
            DiscardGrid.Children.Add(new VoiceButton(2, false, question, "(짧은 대답)", path.No));
        }
    }

    private void AddH3Questions(List<(string question, IQuestion path)> questions)
    {
        foreach (var (question, path) in questions)
        {
            ApplyGrid.Children.Add(new VoiceButton(3, true, question, "(자기 노출)", path.Yes));
            DiscardGrid.Children.Add(new VoiceButton(3, false, question, "(일반 대답)", path.No));
        }
    }

    private void AddEmptySpace()
    {
        ApplyGrid.Children.Add(new Grid() { Height = 30 });
        DiscardGrid.Children.Add(new Grid() { Height = 30 });
    }

    /// <summary>
    /// Plays Micha's voice
    /// </summary>
    /// <param name="path">The path where the sound file exists.</param>
    /// <param name="button">The button that you want to play the voice</param>
    private void PlaySound(string path, Button button)
    {
        // Backup current button style
        var b = button.BorderBrush;
        var t = button.BorderThickness;

        // Now Playing
        button.BorderThickness = new(3);
        button.BorderBrush = new SolidColorBrush(Colors.MediumBlue);

        MediaPlayer mediaPlayer = new() { Source = MediaSource.CreateFromUri(new(path)) };
        mediaPlayer.MediaEnded += async (_, _) =>
        {
            // Dispose player after media ended
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { button.BorderThickness = t; button.BorderBrush = b; });
            mediaPlayer.Dispose();
        };
        mediaPlayer.Play();
    }

    // If button is clicked, then plays the sound
    private void Button_Click(object sender, RoutedEventArgs e)
    => PlaySound(Sounds.SayNow, PlayButton);

    private void Button_Click1(object sender, RoutedEventArgs e)
    => PlaySound(Sounds.Self, IntroButton);
}