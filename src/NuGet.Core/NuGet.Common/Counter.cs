// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGet.Common
{
#pragma warning disable RS0016 // Add public types and members to the declared API
    public static class Counter
    {
        public static void IncrementCreateLockFileTargetLibraryCallCount(string stuff)
        {
            CreateLockFileTargetLibraryCallCount = CreateLockFileTargetLibraryCallCount + 1;
            PackagesGenerated.Add(stuff);
        }

        public static void IncrementTotalCreateLockFileTargetLibraryCallCount()
        {
            TotalCreateLockFileTargetLibraryCallCount = TotalCreateLockFileTargetLibraryCallCount + 1;
        }

        public static int CreateLockFileTargetLibraryCallCount { get; set; } = 0;
        public static List<string> PackagesGenerated { get; } = new List<string>();
        public static int TotalCreateLockFileTargetLibraryCallCount { get; set; } = 0;
    }
#pragma warning restore RS0016 // Add public types and members to the declared API

}
