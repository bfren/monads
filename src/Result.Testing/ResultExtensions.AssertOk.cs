// Wrap: .NET monads for functional style.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2019

namespace Wrap.Testing;

public static partial class ResultExtensions
{
	/// <summary>
	/// Assert that <paramref name="this"/> is <see cref="Ok{T}"/> and return the wrapped value.
	/// </summary>
	/// <typeparam name="T">Result value type.</typeparam>
	/// <param name="this">Result object.</param>
	public static T AssertOk<T>(this Result<T> @this) =>
		Assert.IsType<Ok<T>>(@this).Value;
}
