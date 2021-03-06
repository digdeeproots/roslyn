﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable enable

using System;
using System.Composition;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.Remote;

namespace Microsoft.VisualStudio.LanguageServices.Remote
{
    [ExportWorkspaceService(typeof(IRemoteHostClientFactory)), Shared]
    internal class RemoteHostClientFactory : IRemoteHostClientFactory
    {
        [ImportingConstructor]
        [Obsolete(MefConstruction.ImportingConstructorMessage, error: true)]
        public RemoteHostClientFactory()
        {
        }

        public async Task<RemoteHostClient?> CreateAsync(HostWorkspaceServices services, CancellationToken cancellationToken)
        {
            // this is the point where we can create different kind of remote host client in future (cloud or etc)
            return await ServiceHubRemoteHostClient.CreateAsync(services, cancellationToken).ConfigureAwait(false);
        }
    }
}
