// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel;
using Microsoft.AspNetCore.Server.Kestrel.Http;
using Microsoft.AspNetCore.Server.Kestrel.Infrastructure;

namespace Microsoft.AspNetCore.Server.KestrelTests
{
    class TestInput : IConnectionControl, IFrameControl, IDisposable
    {
        private MemoryPool _memoryPool;

        public TestInput()
        {
            var trace = new KestrelTrace(new TestKestrelTrace());
            var ltp = new LoggingThreadPool(trace);
            var connectionContext = new LibuvConnectionContext() { ServerAddress = new ServerAddress() };
            var context = new Frame<object>(application: null, connectionInformation: connectionContext, serviceContext: connectionContext)
            {
                //DateHeaderValueManager = new DateHeaderValueManager(),
                //ServerAddress = ServerAddress.FromUrl("http://localhost:5000"),
                //ConnectionControl = this,
                // FrameControl = this
            };
            FrameContext = context;

            _memoryPool = new MemoryPool();
            // FrameContext.InputChannel = new MemoryPoolChannel(_memoryPool, ltp);
        }

        public Frame FrameContext { get; set; }

        public void Add(string text, bool fin = false)
        {
            //var data = System.Text.Encoding.ASCII.GetBytes(text);
            //FrameContext.InputChannel.WriteAsync(data, 0, data.Length);
            //if (fin)
            //{
            //    FrameContext.InputChannel.RemoteIntakeFin = true;
            //}
        }

        public void ProduceContinue()
        {
        }

        public void Pause()
        {
        }

        public void Resume()
        {
        }

        public void Abort()
        {
        }

        public void Write(ArraySegment<byte> data, Action<Exception, object> callback, object state)
        {
        }
        public void End(ProduceEndType endType)
        {
        }

        void IFrameControl.ProduceContinue()
        {
        }

        void IFrameControl.Write(ArraySegment<byte> data)
        {
        }

        Task IFrameControl.WriteAsync(ArraySegment<byte> data, CancellationToken cancellationToken)
        {
            return TaskUtilities.CompletedTask;
        }

        void IFrameControl.Flush()
        {
        }

        Task IFrameControl.FlushAsync(CancellationToken cancellationToken)
        {
            return TaskUtilities.CompletedTask;
        }

        public void Dispose()
        {
            // FrameContext.InputChannel.Dispose();
            _memoryPool.Dispose();
        }
    }
}

