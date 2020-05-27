﻿using System;
using System.Diagnostics;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.XImgProc;
using SampleBase;

namespace SamplesCS
{
    internal class BinarizerSample : ISample
    {
        public void Run()
        {
            using var src = Cv2.ImRead(FilePath.Image.Binarization, ImreadModes.Grayscale);
            using var niblack = new Mat();
            using var sauvola = new Mat();
            using var bernsen = new Mat();
            using var nick = new Mat();
            int kernelSize = 51;

            var sw = new Stopwatch();
            sw.Start();
            CvXImgProc.NiblackThreshold(src, niblack, 255, ThresholdTypes.Binary, kernelSize, -0.2, LocalBinarizationMethods.Niblack);
            sw.Stop();
            Console.WriteLine($"Niblack {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            CvXImgProc.NiblackThreshold(src, sauvola, 255, ThresholdTypes.Binary, kernelSize, 0.1, LocalBinarizationMethods.Sauvola);
            sw.Stop();
            Console.WriteLine($"Sauvola {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            Binarizer.Bernsen(src, bernsen, kernelSize, 50, 200);
            sw.Stop();
            Console.WriteLine($"Bernsen {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            CvXImgProc.NiblackThreshold(src, nick, 255, ThresholdTypes.Binary, kernelSize, -0.14, LocalBinarizationMethods.Nick);
            sw.Stop();
            Console.WriteLine($"Nick {sw.ElapsedMilliseconds} ms");

            using (new Window("src", WindowMode.AutoSize, src))
            using (new Window("Niblack", WindowMode.AutoSize, niblack))
            using (new Window("Sauvola", WindowMode.AutoSize, sauvola))
            using (new Window("Bernsen", WindowMode.AutoSize, bernsen))
            using (new Window("Nick", WindowMode.AutoSize, nick))
            {
                Cv2.WaitKey();
            }
        }
    }
}
