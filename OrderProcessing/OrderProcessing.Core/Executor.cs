using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderProcessing.Core
{
    /// <summary>
    /// Mediator pattern
    /// </summary>
    public sealed class Executor
    {
        private readonly IMediator _mediator;

        public Executor(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Command executor
        /// </summary>
        public async Task<CommandResult> DispatchAsync(IRequest<CommandResult> command)
        {
            return await _mediator.Send(command, CancellationToken.None);
        }

        /// <summary>
        /// Query executer
        /// </summary>
        public async Task<T> DispatchAsync<T>(IRequest<T> query)
        {
            return await _mediator.Send(query, CancellationToken.None);
        }
    }
}
