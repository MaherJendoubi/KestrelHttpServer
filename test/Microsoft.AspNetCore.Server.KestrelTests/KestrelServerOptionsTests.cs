// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Net;
using Microsoft.AspNetCore.Server.Kestrel;
using Xunit;

namespace Microsoft.AspNetCore.Server.KestrelTests
{
    public class KestrelServerOptionsTests
    {
        [Fact]
        public void NoDelayDefaultsToTrue()
        {
            var o1 = new KestrelServerOptions();
            o1.Listen(IPAddress.Loopback, 0);
            o1.Listen(IPAddress.Loopback, 0, d =>
            {
                d.NoDelay = false;
            });

            Assert.True(o1.ListenOptions[0].NoDelay);
            Assert.False(o1.ListenOptions[1].NoDelay);
        }
    }
}