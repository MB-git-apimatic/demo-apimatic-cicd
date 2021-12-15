$request = 'https://coreapisnew.azurewebsites.net/swagger/v1/swagger.json'
$response = Invoke-WebRequest $request
$jsonObj = ConvertFrom-Json $([String]::new($response.Content))
$jsonObj | ConvertTo-Json -depth 32| set-content '.\APIMatic\spec\spec1\coreAPIs.json'
