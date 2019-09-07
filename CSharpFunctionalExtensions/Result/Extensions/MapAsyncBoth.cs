using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        // Overloads that construct new results by wrapping a return value from a function
        // 

        public static async Task<Result<K, E>> Map<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<K>> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            K value = await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return Result.Ok<K, E>(value);
        }

        public static async Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            K value = await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return Result.Ok(value);
        }

        public static async Task<Result<K>> Map<K>(this Task<Result> resultTask, Func<Task<K>> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            K value = await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return Result.Ok(value);
        }

        // Overloads that pass on a new Result returned by a function
        // 

        public static async Task<Result<K, E>> Map<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<Result<K, E>>> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<K>> Map<K>(this Task<Result> resultTask, Func<Task<Result<K>>> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result> Map<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail(result.Error);

            return await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result> Map(this Task<Result> resultTask, Func<Task<Result>> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return result;

            return await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }
    }
}