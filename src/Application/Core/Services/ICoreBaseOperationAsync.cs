using Application.Core.Contract;
using Application.Interfaces.Messaging;
using Core.Interfaces;
using Domain.Interfaces.Base;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Core.Services
{
    public interface ICoreBaseOperationAsync<TRequest, TResponse> : ICoreBaseServiceAsync<TRequest, TResponse>, IDisposable
        where TRequest : CoreOperationRequest
        where TResponse : CoreOperationResponse, new()
    {
        
}