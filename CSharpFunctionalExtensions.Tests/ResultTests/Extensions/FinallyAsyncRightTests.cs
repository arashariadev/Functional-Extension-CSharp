﻿using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class FinallyAsyncRightTests : FinallyTestsBase
    {
        [Fact]
        public async Task Finally_RightAsync_executes_on_success_returns_K()
        {
            Result result = Result.Success();
            K output = await result.Finally(Task_Func_Result);

            AssertCalled(result, output);
        }

        [Fact]
        public async Task Finally_RightAsync_T_executes_on_success_returns_K()
        {
            Result<T> result = Result.Success(T.Value);
            K output = await result.Finally(Task_Func_Result_T);

            AssertCalled(result, output);
        }

        [Fact]
        public async Task Finally_RightAsync_T_E_executes_on_success_returns_K()
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            K output = await result.Finally(Task_Func_Result_T_E);

            AssertCalled(result, output);
        }

        [Fact]
        public async Task Finally_RightAsync_unit_result_E_executes_on_success_returns_K()
        {
            UnitResult<E> result = UnitResult.Success<E>();
            K output = await result.Finally(Task_Func_Unit_Result_E);

            AssertCalled(result, output);
        }
    }
}
