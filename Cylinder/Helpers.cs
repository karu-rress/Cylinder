/// <summary>
/// Project Cylinder Helper Classes
/// 
/// 
/// Copyright 2022 Karu, Rolling Ress
/// All rights reserved.
/// 
/// </summary>

#nullable enable

namespace Cylinder;

// 가설 처치 여부
public interface IQuestion
{
    string Yes { get; }
    string No { get; }
}

// 답변 음성
public class Sounds
{
    public const string SayNow = "ms-appx:///Assets/saynow.wav";
    public const string Self = "ms-appx:///Assets/Introduction.mp3";

    // 가설 1
    public class H1
    {
        public class Q1 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART1/01.mp3";
            public string No { get; } = "ms-appx:///Assets/PART1/02.mp3";
        }
        public class Q2 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART1/03.mp3";
            public string No { get; } = "ms-appx:///Assets/PART1/04.mp3";
        }
        public class Q3 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART1/05.mp3";
            public string No { get; } = "ms-appx:///Assets/PART1/06.mp3";
        }
        public class Q4 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART1/07.mp3";
            public string No { get; } = "ms-appx:///Assets/PART1/08.mp3";
        }
        public class Q5 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART1/09.mp3";
            public string No { get; } = "ms-appx:///Assets/PART1/10.mp3";
        }
        public class Q6 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART1/11.mp3";
            public string No { get; } = "ms-appx:///Assets/PART1/12.mp3";
        }
    }

    // 가설 2
    public class H2
    {
        public class Q1 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART2/01.mp3";
            public string No { get; } = "ms-appx:///Assets/PART2/02.mp3";
        }
        public class Q2 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART2/03.mp3";
            public string No { get; } = "ms-appx:///Assets/PART2/04.mp3";
        }
        public class Q3 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART2/05.mp3";
            public string No { get; } = "ms-appx:///Assets/PART2/06.mp3";
        }
        public class Q4 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART2/07.mp3";
            public string No { get; } = "ms-appx:///Assets/PART2/08.mp3";
        }
        public class Q5 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART2/09.mp3";
            public string No { get; } = "ms-appx:///Assets/PART2/10.mp3";
        }
        public class Q6 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART2/11.mp3";
            public string No { get; } = "ms-appx:///Assets/PART2/12.mp3";
        }

    }

    // 가설 3
    public class H3
    {
        public class Q1 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART3/01.mp3";
            public string No { get; } = "ms-appx:///Assets/PART3/02.mp3";
        }
        public class Q2 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART3/03.mp3";
            public string No { get; } = "ms-appx:///Assets/PART3/04.mp3";
        }
        public class Q3 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART3/05.mp3";
            public string No { get; } = "ms-appx:///Assets/PART3/06.mp3";
        }
        public class Q4 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART3/07.mp3";
            public string No { get; } = "ms-appx:///Assets/PART3/08.mp3";
        }
        public class Q5 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART3/09.mp3";
            public string No { get; } = "ms-appx:///Assets/PART3/10.mp3";
        }
        public class Q6 : IQuestion
        {
            public string Yes { get; } = "ms-appx:///Assets/PART3/11.mp3";
            public string No { get; } = "ms-appx:///Assets/PART3/12.mp3";
        }
    }
}