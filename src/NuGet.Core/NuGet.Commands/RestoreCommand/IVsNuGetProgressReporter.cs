// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NuGet.Commands
{
    public interface IVsNuGetProgressReporter
    {
        event EventHandler<NuGetSolutionRestoreEventArgs> SolutionRestoreStarted;
        event EventHandler<NuGetSolutionRestoreEventArgs> SolutionRestoreFinished;
        event EventHandler<NuGetProjectEventArgs> ProjectUpdateStarted;
        event EventHandler<NuGetProjectEventArgs> ProjectUpdateFinished;
    }

    public class NuGetSolutionRestoreEventArgs : EventArgs
    {
        public IReadOnlyList<string> Projects { get; }

        public NuGetSolutionRestoreEventArgs(IReadOnlyList<string> projects)
        {
            Projects = projects ?? throw new ArgumentNullException(nameof(projects));
        }
    }

    public class NuGetProjectEventArgs : EventArgs
    {
        public string ProjectUniqueName { get; }

        public IReadOnlyList<string> UpdatedFiles { get; }

        public NuGetProjectEventArgs(string projectUniqueName, IReadOnlyList<string> updatedFiles)
        {
            ProjectUniqueName = projectUniqueName ?? throw new ArgumentNullException(nameof(projectUniqueName));
            UpdatedFiles = updatedFiles ?? throw new ArgumentNullException(nameof(updatedFiles));
        }
    }

    public interface INuGetProgressReporter
    {
        void StartProjectUpdate(string projectName);
        void EndProjectUpdate(string projectName);
    }

    public class Reporter : IVsNuGetProgressReporter, INuGetProgressReporter
    {
        public event EventHandler<NuGetProjectEventArgs> ProjectUpdateStarted;
        public event EventHandler<NuGetProjectEventArgs> ProjectUpdateFinished;
        public event EventHandler<NuGetSolutionRestoreEventArgs> SolutionRestoreStarted;
        public event EventHandler<NuGetSolutionRestoreEventArgs> SolutionRestoreFinished;

        public void StartProjectUpdate(string projectName)
        {
            ProjectUpdateStarted(this, new NuGetProjectEventArgs(projectName, new string[0]));
        }

        public void EndProjectUpdate(string projectName)
        {
            ProjectUpdateFinished(this, new NuGetProjectEventArgs(projectName, new string[0]));
        }
    }
}
