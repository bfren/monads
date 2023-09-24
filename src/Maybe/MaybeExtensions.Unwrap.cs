// Wrap: .NET monads for functional style.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2019

using System;
using System.Threading.Tasks;

namespace Wrap;

public static partial class MaybeExtensions
{
	/// <summary>
	/// Unwrap the value contained in <paramref name="this"/>.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Provides access to the value wrapped by a <see cref="Maybe{T}"/> object.
	/// </para>
	/// <para>
	/// You need to provide a default value via <paramref name="ifNone"/> in case
	/// <paramref name="this"/> is <see cref="None"/>.
	/// </para>
	/// </remarks>
	/// <seealso cref="UnwrapSingle{T, TSingle}(Maybe{T}, Func{TSingle})"/>
	/// <typeparam name="T">Some value type.</typeparam>
	/// <param name="this">Maybe object.</param>
	/// <param name="ifNone">Function to generate a value if <paramref name="this"/> is <see cref="None"/>.</param>
	/// <returns>The value of <paramref name="this"/> or generated by <paramref name="ifNone"/>.</returns>
	public static T Unwrap<T>(this Maybe<T> @this, Func<T> ifNone) =>
		M.Match(@this,
			none: ifNone,
			some: x => x
		);

	/// <inheritdoc cref="Unwrap{T}(Maybe{T}, Func{T})"/>
	public static Task<T> UnwrapAsync<T>(this Maybe<T> @this, Func<Task<T>> ifNone) =>
		M.MatchAsync(@this,
			none: ifNone,
			some: x => x
		);

	/// <inheritdoc cref="Unwrap{T}(Maybe{T}, Func{T})"/>
	public static Task<T> UnwrapAsync<T>(this Task<Maybe<T>> @this, Func<T> ifNone) =>
		M.MatchAsync(@this,
			none: ifNone,
			some: x => Task.FromResult(x)
		);

	/// <inheritdoc cref="Unwrap{T}(Maybe{T}, Func{T})"/>
	public static Task<T> UnwrapAsync<T>(this Task<Maybe<T>> @this, Func<Task<T>> ifNone) =>
		M.MatchAsync(@this,
			none: ifNone,
			some: x => Task.FromResult(x)
		);
}
