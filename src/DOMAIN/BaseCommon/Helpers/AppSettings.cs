﻿namespace MenphisSI.BaseCommon;

public class AppSettings
{
    public string Secret { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string ValidUris { get; set; } = string.Empty;
    public string UrisAniversariantes { get; set; } = string.Empty;
    public string UrisNotificadorAgenda { get; set; } = string.Empty;
}