// <copyright file="AppLogger.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Services.Utility
{
    using System;
    using NLog;

    /// <inheritdoc/>
    public class AppLogger : ILogger
    {
        // Singleton pattern
        private static Logger Logger; // static variable of nlog logger
        private static AppLogger instance; // singleton design pattern

        /// <summary>
        /// .
        /// </summary>
        /// <returns></returns>
        public static AppLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new AppLogger();
            }

            return instance;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="log">Message.</param>
        /// <returns>Logger.</returns>
        private Logger GetLogger(string log)
        {
            if (Logger == null)
            {
                Logger = LogManager.GetLogger(log);
            }

            return Logger;
        }

        /// <inheritdoc/>
        public void Debug(string message)
        {
            this.GetLogger("rules").Debug(message);
        }

        /// <inheritdoc/>
        public void Error(string message)
        {
            this.GetLogger("rules").Error(message);
        }

        /// <inheritdoc/>
        public void Info(string message)
        {
            this.GetLogger("rules").Info(message);
        }

        /// <inheritdoc/>
        public void Warn(string message)
        {
            this.GetLogger("rules").Warn(message);
        }
    }
}