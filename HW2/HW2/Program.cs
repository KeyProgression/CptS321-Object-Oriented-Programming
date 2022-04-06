// <copyright file="Program.cs" company="WSU-Dr. Venera Arnaoudova">
// Copyright (c) WSU-Dr. Venera Arnaoudova. All rights reserved.
// </copyright>
// <author>Matthew Yien</author>
// <studentid>11698797</studentid>

namespace HW2
{
    /// <summary>
    /// Standard program.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
