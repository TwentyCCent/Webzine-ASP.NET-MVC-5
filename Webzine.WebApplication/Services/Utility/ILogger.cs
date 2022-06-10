// <copyright file="ILogger.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Services.Utility
{
    /// <summary>
    /// .
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Debug.
        /// </summary>
        /// <param name="message">Contenu du message loggé.</param>
        void Debug(string message);

        /// <summary>
        /// Info.
        /// </summary>
        /// <param name="message">Contenu du message loggé.</param>
        void Info(string message);

        /// <summary>
        /// Warning.
        /// </summary>
        /// <param name="message">Contenu du message loggé.</param>
        void Warn(string message);

        /// <summary>
        /// Error.
        /// </summary>
        /// <param name="message">Contenu du message loggé.</param>
        void Error(string message);
    }
}