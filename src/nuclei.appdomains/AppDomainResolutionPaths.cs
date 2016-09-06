﻿//-----------------------------------------------------------------------
// <copyright company="TheNucleus">
// Copyright (c) TheNucleus. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENCE.md file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Nuclei.AppDomains.Properties;

namespace Nuclei.AppDomains
{
    /// <summary>
    /// Holds the base path and assembly resolve paths for an <see cref="AppDomain"/>.
    /// </summary>
    [SuppressMessage(
        "Microsoft.Performance",
        "CA1812:AvoidUninstantiatedInternalClasses",
        Justification = "This class is embedded in an user assembly and called from there. Hence all methods are internal.")]
    [SuppressMessage(
        "Microsoft.Performance",
        "CA1811:AvoidUncalledPrivateCode",
        Justification = "This class is embedded in an user assembly and called from there. Hence all methods are internal.")]
    internal sealed class AppDomainResolutionPaths
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDomainResolutionPaths"/> class based on the
        /// specified set of files.
        /// </summary>
        /// <param name="basePath">The base path for the <c>AppDomain</c> path resolution.</param>
        /// <param name="files">The files that can be resolved.</param>
        /// <returns>A new instance of the <see cref="AppDomainResolutionPaths"/> class.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="basePath"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="basePath"/> is an empty string.
        /// </exception>
        [SuppressMessage(
            "Microsoft.Performance",
            "CA1811:AvoidUncalledPrivateCode",
            Justification = "This class is embedded in an user assembly and called from there. Hence all methods are internal.")]
        public static AppDomainResolutionPaths WithFiles(string basePath, IEnumerable<string> files)
        {
            return WithFilesAndDirectories(basePath, files, new List<string>());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDomainResolutionPaths"/> class based on the
        /// specified set of files and directories.
        /// </summary>
        /// <param name="basePath">The base path for the <c>AppDomain</c> path resolution.</param>
        /// <param name="files">The files that can be resolved.</param>
        /// <param name="directories">The directories in which files can be resolved.</param>
        /// <returns>A new instance of the <see cref="AppDomainResolutionPaths"/> class.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="basePath"/> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="basePath"/> is an empty string.
        /// </exception>
        [SuppressMessage(
            "Microsoft.Performance",
            "CA1811:AvoidUncalledPrivateCode",
            Justification = "This class is embedded in an user assembly and called from there. Hence all methods are internal.")]
        public static AppDomainResolutionPaths WithFilesAndDirectories(string basePath, IEnumerable<string> files, IEnumerable<string> directories)
        {
            return new AppDomainResolutionPaths(basePath, files, directories);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDomainResolutionPaths"/> class.
        /// </summary>
        /// <param name="basePath">The base path for the <c>AppDomain</c> path resolution.</param>
        /// <param name="files">The files that can be resolved.</param>
        /// <param name="directories">The directories in which files can be resolved.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="basePath"/> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="basePath"/> is an empty string.
        /// </exception>
        private AppDomainResolutionPaths(string basePath, IEnumerable<string> files, IEnumerable<string> directories)
        {
            if (basePath == null)
            {
                throw new ArgumentNullException("basePath");
            }

            if (string.IsNullOrWhiteSpace(basePath))
            {
                throw new ArgumentException(Resources.Exceptions_Messages_ParameterShouldNotBeAnEmptyString, "basePath");
            }

            BasePath = basePath;
            Files = files;
            Directories = directories;
        }

        /// <summary>
        /// Gets the <see cref="AppDomain"/> base path.
        /// </summary>
        /// <value>The base path for the <see cref="AppDomain"/>.</value>
        public string BasePath
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the files which can be loaded.
        /// </summary>
        /// <value>The collection of files.</value>
        public IEnumerable<string> Files
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the directories from which assemblies can be loaded.
        /// </summary>
        /// <value>The collection directories.</value>
        public IEnumerable<string> Directories
        {
            get;
            private set;
        }
    }
}
