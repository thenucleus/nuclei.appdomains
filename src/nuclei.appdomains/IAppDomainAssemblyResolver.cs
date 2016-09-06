//-----------------------------------------------------------------------
// <copyright company="TheNucleus">
// Copyright (c) TheNucleus. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENCE.md file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------
//// GENERATED_CODE_HEADER
using System;

namespace Nuclei.AppDomains
{
    /// <summary>
    /// Defines the interface for classes which deal with assembly resolution.
    /// </summary>
    //// GENERATED_CODE_ATTRIBUTE
    internal interface IAppDomainAssemblyResolver
    {
        /// <summary>
        /// Attaches the assembly resolution method to the <see cref="AppDomain.AssemblyResolve"/>
        /// event.
        /// </summary>
        void Attach();
    }
}
