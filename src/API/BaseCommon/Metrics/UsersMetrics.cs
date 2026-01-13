// OpenTelemetry Metrics for Users controller
// copyright © 2000-2025 Menphis - Sistemas Inteligentes

using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace MenphisSI.BaseCommon.Metrics;

/// <summary>
/// OpenTelemetry metrics for the Users controller            
/// </summary>
[ExcludeFromCodeCoverage]
public static class UsersMetrics
{
    private static readonly Meter _meter = new("GerAdv.Api.Users", "1.0.0");

    /// <summary>
    /// Counter for total requests by operation and status
    /// Prometheus: users_requests_total{operacao, status}
    /// </summary>
    public static readonly Counter<long> RequestsTotal = _meter.CreateCounter<long>(
        "users_requests_total",
        unit: "{requests}",
        description: "Total requests by operation and status");

    /// <summary>
    /// Counter for total errors by operation and type
    /// Prometheus: users_errors_total{operacao, tipo}
    /// </summary>
    public static readonly Counter<long> ErrorsTotal = _meter.CreateCounter<long>(
        "users_errors_total",
        unit: "{errors}",
        description: "Total errors by operation and type");

    /// <summary>
    /// Histogram for request duration in milliseconds
    /// Prometheus: users_request_duration_ms{operacao}
    /// </summary>
    public static readonly Histogram<double> RequestDuration = _meter.CreateHistogram<double>(
        "users_request_duration_ms",
        unit: "ms",
        description: "Request duration in milliseconds");

    /// <summary>
    /// Counter for successful authentications
    /// Prometheus: users_auth_success_total
    /// </summary>
    public static readonly Counter<long> AuthSuccess = _meter.CreateCounter<long>(
        "users_auth_success_total",
        description: "Total successful authentications");

    /// <summary>
    /// Counter for failed authentications
    /// Prometheus: users_auth_failures_total
    /// </summary>
    public static readonly Counter<long> AuthFailures = _meter.CreateCounter<long>(
        "users_auth_failures_total",
        description: "Total failed authentications");

    /// <summary>
    /// Counter for password changes
    /// Prometheus: users_password_changes_total
    /// </summary>
    public static readonly Counter<long> PasswordChanges = _meter.CreateCounter<long>(
        "users_password_changes_total",
        description: "Total password changes");

    /// <summary>
    /// Counter for password resets
    /// Prometheus: users_password_resets_total
    /// </summary>
    public static readonly Counter<long> PasswordResets = _meter.CreateCounter<long>(
        "users_password_resets_total",
        description: "Total password resets");

    /// <summary>
    /// Counter for validation failures
    /// Prometheus: users_validation_failures_total
    /// </summary>
    public static readonly Counter<long> ValidationFailures = _meter.CreateCounter<long>(
        "users_validation_failures_total",
        description: "Total validation failures");

    /// <summary>
    /// Counter for unauthorized requests
    /// Prometheus: users_unauthorized_total
    /// </summary>
    public static readonly Counter<long> UnauthorizedTotal = _meter.CreateCounter<long>(
        "users_unauthorized_total",
        description: "Total unauthorized requests");

    /// <summary>
    /// Counter for circuit breaker rejections
    /// Prometheus: users_circuit_breaker_rejections_total
    /// </summary>
    public static readonly Counter<long> CircuitBreakerRejections = _meter.CreateCounter<long>(
        "users_circuit_breaker_rejections_total",
        description: "Total circuit breaker rejections");

    /// <summary>
    /// Counter for bulkhead rejections
    /// Prometheus: users_bulkhead_rejections_total
    /// </summary>
    public static readonly Counter<long> BulkheadRejections = _meter.CreateCounter<long>(
        "users_bulkhead_rejections_total",
        description: "Total bulkhead rejections");

    /// <summary>
    /// Starts a stopwatch to measure execution time
    /// </summary>
    public static Stopwatch StartTimer() => Stopwatch.StartNew();

    /// <summary>
    /// Records a successful request
    /// </summary>
    public static void RecordSuccess(string operacao, Stopwatch stopwatch)
    {
        stopwatch.Stop();
        RequestsTotal.Add(1,
            new KeyValuePair<string, object?>("operacao", operacao),
            new KeyValuePair<string, object?>("status", "success"));
        RequestDuration.Record(stopwatch.Elapsed.TotalMilliseconds,
            new KeyValuePair<string, object?>("operacao", operacao));
    }

    /// <summary>
    /// Records a request with error
    /// </summary>
    public static void RecordError(string operacao, Exception ex, Stopwatch stopwatch)
    {
        stopwatch.Stop();
        RequestsTotal.Add(1,
            new KeyValuePair<string, object?>("operacao", operacao),
            new KeyValuePair<string, object?>("status", "error"));
        ErrorsTotal.Add(1,
            new KeyValuePair<string, object?>("operacao", operacao),
            new KeyValuePair<string, object?>("tipo", ex.GetType().Name));
        RequestDuration.Record(stopwatch.Elapsed.TotalMilliseconds,
            new KeyValuePair<string, object?>("operacao", operacao));
    }

    /// <summary>
    /// Records an unauthorized request
    /// </summary>
    public static void RecordUnauthorized(string operacao, Stopwatch stopwatch)
    {
        stopwatch.Stop();
        UnauthorizedTotal.Add(1);
        RequestsTotal.Add(1,
            new KeyValuePair<string, object?>("operacao", operacao),
            new KeyValuePair<string, object?>("status", "unauthorized"));
        RequestDuration.Record(stopwatch.Elapsed.TotalMilliseconds,
            new KeyValuePair<string, object?>("operacao", operacao));
    }

    /// <summary>
    /// Records a validation failure
    /// </summary>
    public static void RecordInvalid(string operacao, Stopwatch stopwatch)
    {
        stopwatch.Stop();
        ValidationFailures.Add(1);
        RequestsTotal.Add(1,
            new KeyValuePair<string, object?>("operacao", operacao),
            new KeyValuePair<string, object?>("status", "invalid"));
        RequestDuration.Record(stopwatch.Elapsed.TotalMilliseconds,
            new KeyValuePair<string, object?>("operacao", operacao));
    }

    /// <summary>
    /// Records a circuit breaker rejection
    /// </summary>
    public static void RecordCircuitBreakerRejection(string operacao, Stopwatch stopwatch)
    {
        stopwatch.Stop();
        CircuitBreakerRejections.Add(1);
        RequestsTotal.Add(1,
            new KeyValuePair<string, object?>("operacao", operacao),
            new KeyValuePair<string, object?>("status", "circuit_breaker_rejected"));
        RequestDuration.Record(stopwatch.Elapsed.TotalMilliseconds,
            new KeyValuePair<string, object?>("operacao", operacao));
    }

    /// <summary>
    /// Records a bulkhead rejection (overload protection)
    /// </summary>
    public static void RecordBulkheadRejection(string operacao, Stopwatch stopwatch)
    {
        stopwatch.Stop();
        BulkheadRejections.Add(1);
        RequestsTotal.Add(1,
            new KeyValuePair<string, object?>("operacao", operacao),
            new KeyValuePair<string, object?>("status", "bulkhead_rejected"));
        ErrorsTotal.Add(1,
            new KeyValuePair<string, object?>("operacao", operacao),
            new KeyValuePair<string, object?>("tipo", "BulkheadRejectedException"));
        RequestDuration.Record(stopwatch.Elapsed.TotalMilliseconds,
            new KeyValuePair<string, object?>("operacao", operacao));
    }
}
