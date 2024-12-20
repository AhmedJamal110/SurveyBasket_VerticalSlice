﻿using System.Diagnostics.CodeAnalysis;

namespace SurveyBasket.Abstractions
{
    public class Result
    {
        public Result(bool isSuccess , Error error)
        {
            if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
            {
                throw new InvalidOperationException("");
            }
        }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; set; } = default!;

        public static Result Success() 
            => new(true, Error.None);
        public static Result Failure(Error error) 
            => new(false, error);

        public static Result<TValue> Success<TValue>(TValue value)
              => new(value, true, Error.None);

        public static Result<TValue> Failure<TValue>(Error error)
             => new(default!, false, error);

        public static Result<TValue> Create<TValue>(TValue value)
                => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
    }

    public class Result<TValue> : Result
    {
        private readonly TValue _value;
        public Result(TValue value ,  bool isSuccess, Error error) : base(isSuccess, error)
        {
            _value = value;
        }

        [NotNull]
        public TValue Value => IsSuccess
                                        ? _value!
                                        : throw new InvalidOperationException("Failure Result Cant have Value");

        public static implicit operator Result<TValue>(TValue value)
                        => Create(value);
    
    }
}