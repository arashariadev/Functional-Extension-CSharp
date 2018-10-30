using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    /// <summary>
    ///     Extentions for async operations where the task appears in the right operand only
    /// </summary>
    public static class AsyncResultExtensionsRightOperand
    {
        public static async Task<Result<K>> OnSuccess<T, K>(this Result<T> result, Func<T, Task<K>> func, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            K value = await func(result.Value).ConfigureAwait(continueOnCapturedContext);

            return Result.Ok(value);
        }

        public static async Task<Result<K, TError>> OnSuccess<T, K, TError>(this Result<T, TError> result,
            Func<T, Task<K>> func, bool continueOnCapturedContext = true) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<K, TError>(result.Error);

            K value = await func(result.Value).ConfigureAwait(continueOnCapturedContext);

            return Result.Ok<K, TError>(value);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Result result, Func<Task<T>> func, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            T value = await func().ConfigureAwait(continueOnCapturedContext);

            return Result.Ok(value);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return await func(result.Value).ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<Result<K, TError>> OnSuccess<T, K, TError>(this Result<T, TError> result,
            Func<T, Task<Result<K, TError>>> func, bool continueOnCapturedContext = true) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<K, TError>(result.Error);

            return await func(result.Value).ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Result result, Func<Task<Result<T>>> func, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return await func().ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Result<T> result, Func<Task<Result<K>>> func, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return await func().ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<Result<K, TError>> OnSuccess<T, K, TError>(this Result<T, TError> result,
            Func<Task<Result<K, TError>>> func, bool continueOnCapturedContext = true) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<K, TError>(result.Error);

            return await func().ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<Result> OnSuccess<T>(this Result<T> result, Func<T, Task<Result>> func, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            return await func(result.Value).ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<Result> OnSuccess(this Result result, Func<Task<Result>> func, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
                return result;

            return await func().ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<Result<T>> Ensure<T>(this Result<T> result, Func<T, Task<bool>> predicate, string errorMessage, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            if (!await predicate(result.Value).ConfigureAwait(continueOnCapturedContext))
                return Result.Fail<T>(errorMessage);

            return Result.Ok(result.Value);
        }

        public static async Task<Result<T, TError>> Ensure<T, TError>(this Result<T, TError> result,
            Func<T, Task<bool>> predicate, TError error, bool continueOnCapturedContext = true) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<T, TError>(result.Error);

            if (!await predicate(result.Value).ConfigureAwait(continueOnCapturedContext))
                return Result.Fail<T, TError>(error);

            return Result.Ok<T, TError>(result.Value);
        }

        public static async Task<Result> Ensure(this Result result, Func<Task<bool>> predicate, string errorMessage, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            if (!await predicate().ConfigureAwait(continueOnCapturedContext))
                return Result.Fail(errorMessage);

            return Result.Ok();
        }

        public static async Task<Result<K>> Map<T, K>(this Result<T> result, Func<T, Task<K>> func, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            K value = await func(result.Value).ConfigureAwait(continueOnCapturedContext);

            return Result.Ok(value);
        }

        public static async Task<Result<K, TError>> Map<T, K, TError>(this Result<T, TError> result,
            Func<T, Task<K>> func, bool continueOnCapturedContext = true) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<K, TError>(result.Error);

            K value = await func(result.Value).ConfigureAwait(continueOnCapturedContext);

            return Result.Ok<K, TError>(value);
        }

        public static async Task<Result<T>> Map<T>(this Result result, Func<Task<T>> func, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            T value = await func().ConfigureAwait(continueOnCapturedContext);

            return Result.Ok(value);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Result<T> result, Func<T, Task> action, bool continueOnCapturedContext = true)
        {
            if (result.IsSuccess)
            {
                await action(result.Value).ConfigureAwait(continueOnCapturedContext);
            }

            return result;
        }

        public static async Task<Result<T, TError>> OnSuccess<T, TError>(this Result<T, TError> result,
            Func<T, Task> action, bool continueOnCapturedContext = true)
        {
            if (result.IsSuccess)
            {
                await action(result.Value).ConfigureAwait(continueOnCapturedContext);
            }

            return result;
        }

        public static async Task<Result> OnSuccess(this Result result, Func<Task> action, bool continueOnCapturedContext = true)
        {
            if (result.IsSuccess)
            {
                await action().ConfigureAwait(continueOnCapturedContext);
            }

            return result;
        }

        public static async Task<T> OnBoth<T>(this Result result, Func<Result, Task<T>> func, bool continueOnCapturedContext = true)
        {
            return await func(result).ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<K> OnBoth<T, K>(this Result<T> result, Func<Result<T>, Task<K>> func, bool continueOnCapturedContext = true)
        {
            return await func(result).ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<K> OnBoth<T, K, TError>(this Result<T, TError> result, Func<Result<T>, Task<K>> func,
            bool continueOnCapturedContext = true)
        {
            return await func(result).ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<Result<T>> OnFailure<T>(this Result<T> result, Func<Task> func, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
            {
                await func().ConfigureAwait(continueOnCapturedContext);
            }

            return result;
        }

        public static async Task<Result<T, TError>> OnFailure<T, TError>(this Result<T, TError> result, Func<Task> func,
            bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
            {
                await func().ConfigureAwait(continueOnCapturedContext);
            }

            return result;
        }

        public static async Task<Result> OnFailure(this Result result, Func<Task> func, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
            {
                await func().ConfigureAwait(continueOnCapturedContext);
            }

            return result;
        }

        public static async Task<Result<T>> OnFailure<T>(this Result<T> result, Func<string, Task> func, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
            {
                await func(result.Error).ConfigureAwait(continueOnCapturedContext);
            }

            return result;
        }

        public static async Task<Result<T, TError>> OnFailure<T, TError>(this Result<T, TError> result,
            Func<TError, Task> func, bool continueOnCapturedContext = true)
        {
            if (result.IsFailure)
            {
                await func(result.Error).ConfigureAwait(continueOnCapturedContext);
            }

            return result;
        }
    }
}
