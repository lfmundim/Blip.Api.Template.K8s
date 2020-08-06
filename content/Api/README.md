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
```

3. Remember to register everything else you create and/or need @ `Startup.cs`

# Handling other exceptions with the Middleware
1. Create a new `Strategy` that inherits from `ExceptionHandlingStrategy`
    * follow the naming format `ExceptionNameHandlingStrategy`
1. Implement the `HandleAsync` method with that specific exception handling
1. Add your new exception handler strategy to the dictionary within the `ServiceCollectionExtensions` class