﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using SamplesCore;

namespace SamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    class MatToWriteableBitmap : ISample
    {
        public void Run()
        {
            ToBitmap();
        }

        public void ToBitmap()
        {
            using var mat = new Mat(FilePath.Image.Fruits, ImreadModes.Color); // width % 4 != 0

            var wb = WriteableBitmapConverter.ToWriteableBitmap(mat);

            var image = new System.Windows.Controls.Image();
            image.Source = wb;

            var window = new System.Windows.Window();
            window.Content = image;

            var app = new Application();
            app.Run(window);
        }
    }
}