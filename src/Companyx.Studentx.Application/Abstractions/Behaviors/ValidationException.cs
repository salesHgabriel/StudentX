﻿using Companyx.Companyx.Studentx.Application.Exceptions;

namespace Companyx.Companyx.Studentx.Application.Abstractions.Behaviors
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<ValidationError> Errors { get; }
    }
}