//-----------------------------------------------------------------------
// <copyright company="TheNucleus">
// Copyright (c) TheNucleus. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENCE.md file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------

using NUnit.Framework;

namespace Nuclei.AppDomains.Samples
{
    [TestFixture]
    public sealed class AppDomainBuilderSample
    {
        private static int MyMethod()
        {
            return 0;
        }

        [Test]
        public void RunGuarded()
        {
            // Define the base path for the AppDomain. By default the assembly resolution will look for DLLs here
            var baseDirectory = @"c:\myapplication\plugins";

            // Define any additional files that should be resolved
            var additionalFiles = new[]
                {
                    @"c:\myapplication\mylibrary.dll"
                };

            // Define any additional directories from where assemblies should be resolved
            var additionalDirectories = new[]
                {
                    @"c:\myapplication\"
                };

            var assemblyResolutionPaths = AppDomainResolutionPaths.WithFilesAndDirectories(
                baseDirectory,
                additionalFiles,
                additionalDirectories);
            var appDomain = AppDomainBuilder.Assemble("MyAppDomain", assemblyResolutionPaths);

            Assert.IsNotNull(appDomain);
        }
    }
}
