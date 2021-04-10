﻿using Desktop.Robot;
using Desktop.Robot.Extensions;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Example
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            robot.OnMouseMove().Subscribe(position => Console.WriteLine(position));
            robot.AutoDelay = 1000;
            robot.MouseMove(1000, 1000);
            robot.Click();
            robot.Type("A cat is using my PC", 25);
            robot.CombineKeys(Key.Alt, Key.Tab);
            using var screenshot = robot.CreateScreenCapture(new Rectangle(100, 100, 200, 200));
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"image-{Guid.NewGuid()}.bmp");
            screenshot.Save(path, ImageFormat.Bmp);
        }
    }
}