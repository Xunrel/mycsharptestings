// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyChecker.cs" company="busitec">
//   Copyright (c) 2013 busitec GmbH. All rights reserved.
// </copyright>
// 
// $Id$
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace AssemblyChecker
{
    public static class AssemblyChecker
    {
        public static bool IsAssemblyDebugBuild(string filepath)
        {
            return IsAssemblyDebugBuild(Assembly.LoadFile(Path.GetFullPath(filepath)));
        }

        private static bool IsAssemblyDebugBuild(Assembly assembly)
        {
            foreach (var attribute in assembly.GetCustomAttributes(false))
            {
                var debuggableAttribute = attribute as DebuggableAttribute;
                if (debuggableAttribute != null)
                {
                    return debuggableAttribute.IsJITTrackingEnabled;
                }
            }
            return false;
        }
    }
}