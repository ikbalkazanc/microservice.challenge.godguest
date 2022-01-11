﻿using System.IO.Enumeration;

namespace godguest.gateways.services.Version;

public static class EnvironmentSettings
{
    public static Environments Env => FindEnviroment();

    private static Environments FindEnviroment()
    {
        if (string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER")))
            return Environments.Local;
        else
            return Environments.Docker;
    }
}

public enum Environments
{
    Docker,
    Local
}