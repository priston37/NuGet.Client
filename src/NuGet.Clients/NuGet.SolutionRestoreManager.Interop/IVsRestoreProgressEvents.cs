// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NuGet.SolutionRestoreManager
{
    /// <summary>
    /// PackageReference solution restore events.
    /// </summary>
    [ComImport]
    [Guid("30CDDD0A-6901-482D-8CEF-6D798F1A99FC")]
    public interface IVsRestoreProgressEvents
    {
        /// <summary>
        /// Raised when solution restore starts with the list of projects that will be restored.
        /// This list does not have to include all projects. Some projects may have been skipped in earlier up to date check, and other projects may no-op.
        /// </summary>
        event SolutionRestoreEventHandler SolutionRestoreStarted;

        /// <summary>
        /// Raised when solution restore finishes with the list of projects that were be restored.
        /// The list may include projects that, restore succesfully, were up to date, or failed.
        /// </summary>
        event SolutionRestoreEventHandler SolutionRestoreFinished;

        /// <summary>
        /// Raised when NuGet is about to write the restore outputs for a particular project.
        /// This event is raised after restore has completed.
        /// </summary>
        event ProjectUpdateEventHandler ProjectUpdateStarted;

        /// <summary>
        /// Raised when NuGet is done writing the restore outputs for a particular project.
        /// </summary>
        event ProjectUpdateEventHandler ProjectUpdateFinished;
    }

    /// <summary>
    /// Defines an event handler delegate for PackageReference solution restore start and end.
    /// </summary>
    /// <param name="projects">List of projects that will run restore. Never <see langword="null"/>.</param>
    public delegate void SolutionRestoreEventHandler(IReadOnlyList<string> projects);

    /// <summary>
    /// Defines an event handler delegate for PackageReference project restore updates.
    /// </summary>
    /// <param name="projectUniqueName">Project full path. Never <see langword="null"/>. </param>
    /// <param name="updatedFiles">NuGet output files that may be updated. Never <see langword="null"/>.</param>
    public delegate void ProjectUpdateEventHandler(string projectUniqueName, IReadOnlyList<string> updatedFiles);
}
