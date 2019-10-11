# Guidelines on what's left to do
### (you can delete this file after doing everything)

1. Get BLiP's configurations (AccessKey and Identifier) from the Bot @ https://portal.blip.ai/#/application/detail/BOT_IDENTIFIER/configurations/apikey
    1. You need to switch to SDK to get those. Switch back to Builder when you're done
    2. Place them on the correct properties on `appsettings.json`
    ```json
	...
    "BlipBotSettings": {
      "Identifier": "botBlipIdentifier",
      "AccessKey": "botBlipAccessKey"
    }
	...
    ```
    
2. **[If Using SEQ]** Place SEQ's url on the correct property field on `appsettings.json`
```json
    ...
          "serverUrl": "seq-url"
    ...
````

3. Replace `BotName` on the following line @ `Startup.cs` with the Bot's name
```cs
    ...
    .Enrich.WithProperty("Application", "BotName")
    ...
```

4. Replace both Swagger's placeholders `Blip.Api.Template` with your project's info
```cs
    ...
    c.SwaggerDoc("v1", new Info { Title = "Blip.Api.Template", Version = "v1" });
    ...
    c.SwaggerEndpoint("./swagger/v1/swagger.json", "Blip.Api.Template V1");
    ...
```

5. Populate `UserContext.cs` and `MySettings.cs` with whatever you need.
6. Remember to register everything else you create and/or need @ `Startup.cs`
7. If needed, install `Take.CustomerSuccess.Extensions` and register the needed services