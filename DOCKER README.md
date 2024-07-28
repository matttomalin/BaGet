# Instructions to get running in Docker locally

## Using Powershell

Replace the two instances of "{PasswordHere}" with a new password (unless you already have done step 1., then just use your current password).

1. Create a Docker dev certificate using the following command:
    ```sh
    dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p {PasswordHere}
    ```

2. Go to the [src](./src) folder.

3. Build the Docker container:
    ```sh
    docker build -t baget .
    ```

4. Run the Docker container:
    ``` sh
    docker run -d --name BaGet -p 4342:8080 -p 4343:8081 -e ASPNETCORE_URLS="https://+:8081;http://+:8080" -e ASPNETCORE_HTTPS_PORTS="8081" -e ASPNETCORE_HTTP_PORTS="8080" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx -e ASPNETCORE_Kestrel__Certificates__Default__Password={PasswordHere} -v ${env:USERPROFILE}/.aspnet/https:/https:ro --restart always baget2
