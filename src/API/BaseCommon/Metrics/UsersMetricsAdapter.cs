// copyright © 2000-2025 Menphis - Sistemas Inteligentes
// This file is part of the Source Genesys project

using System.Diagnostics;
using MenphisSI.BaseCommon.UserController;

namespace MenphisSI.BaseCommon.Metrics;

/// <summary>
/// Adapter para UsersMetrics que implementa IUsersMetrics.
/// Permite usar as métricas estáticas através da interface para DI.
/// </summary>
[ExcludeFromCodeCoverage]
public class UsersMetricsAdapter : IUsersMetrics
{
    /// <inheritdoc />
    public Stopwatch StartTimer() => UsersMetrics.StartTimer();

    /// <inheritdoc />
    public void RecordSuccess(string operacao, Stopwatch stopwatch) =>
        UsersMetrics.RecordSuccess(operacao, stopwatch);

    /// <inheritdoc />
    public void RecordError(string operacao, Exception ex, Stopwatch stopwatch) =>
        UsersMetrics.RecordError(operacao, ex, stopwatch);

    /// <inheritdoc />
    public void RecordUnauthorized(string operacao, Stopwatch stopwatch) =>
        UsersMetrics.RecordUnauthorized(operacao, stopwatch);

    /// <inheritdoc />
    public void RecordInvalid(string operacao, Stopwatch stopwatch) =>
        UsersMetrics.RecordInvalid(operacao, stopwatch);

    /// <inheritdoc />
    public void RecordCircuitBreakerRejection(string operacao, Stopwatch stopwatch) =>
        UsersMetrics.RecordCircuitBreakerRejection(operacao, stopwatch);

    /// <inheritdoc />
    public void RecordBulkheadRejection(string operacao, Stopwatch stopwatch) =>
        UsersMetrics.RecordBulkheadRejection(operacao, stopwatch);

    /// <inheritdoc />
    public void IncrementPasswordChanges() =>
        UsersMetrics.PasswordChanges.Add(1);

    /// <inheritdoc />
    public void IncrementPasswordResets() =>
        UsersMetrics.PasswordResets.Add(1);

    /// <inheritdoc />
    public void IncrementAuthSuccess() =>
        UsersMetrics.AuthSuccess.Add(1);

    /// <inheritdoc />
    public void IncrementAuthFailures() =>
        UsersMetrics.AuthFailures.Add(1);
}
