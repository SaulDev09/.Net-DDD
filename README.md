To add Swagger:
1. Add Swashbuckle.AspNetCore
- Install-Package Swashbuckle.AspNetCore -Version 4.0.1
- dotnet add package Swashbuckle.AspNetCore --version 4.0.1

2. Saul.Test.Services.WebAPI/Properties/launchSettings.json Change:
- from       "launchUrl": "api/values",
- to:        "launchUrl": "swagger/index.html",

3. Saul.Test.Services.WebAPI/Startup.cs
In ConfigureServices at the end, Add:

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Saul Test",
                    Description = "Studying Architecture",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Saul Chipana",
                        Email = "Saul.Dev09@gmail.com",
                        Url = ""
                    },
                    License = new License
                    {
                        Name = "Use to Study",
                        Url = ""
                    }
                });
            });

In Configure, before app.UseMvc();, Add:

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });
   
5. Verify in controller, Route:  [Route("api/[controller]/[action]")], with [] not with {}

Detail [here](https://github.com/SaulDev09/.Net-DDD/commit/9a8d5422987aad19be8a44c8ae65da707cd86e9c):


Docker:
------------

        cd C:\FOLDER
        docker image build -t saul.test:1.0.1 -f .\Saul.Test.Services.WebAPI\Dockerfile .
        docker image ls
        docker container run --name saul.test -d -p 8050:80 IMAGE_ID
        docker container ls
        docker container logs CONTAINER_ID
           
localhost:8050/swagger

Refactoring StartUp in Program:
------------

Services.WebAPI
Application > Global Usings > Check "Enable implicit global usings to be declared by the project SDK"


WatchDog
------------

ALTER TABLE WatchDog_Logs
ALTER COLUMN callingMethod VARCHAR(MAX)

ALTER TABLE WatchDog_WatchExceptionLog
ALTER COLUMN typeOf VARCHAR(300)

ALTER TABLE WatchDog_WatchExceptionLog
ALTER COLUMN path VARCHAR(MAX)

ALTER TABLE WatchDog_WatchExceptionLog
ALTER COLUMN method VARCHAR(300)

ALTER TABLE WatchDog_WatchExceptionLog
ALTER COLUMN QueryString VARCHAR(MAX)

ALTER TABLE WatchDog_WatchExceptionLog
ALTER COLUMN EncounteredAt VARCHAR(MAX)

ALTER TABLE WatchDog_WatchLog
ALTER COLUMN requestBody VARCHAR(MAX)

ALTER TABLE WatchDog_WatchLog
ALTER COLUMN queryString VARCHAR(MAX)

ALTER TABLE WatchDog_WatchLog
ALTER COLUMN path VARCHAR(MAX)

ALTER TABLE WatchDog_WatchLog
ALTER COLUMN responseHeaders VARCHAR(MAX)

ALTER TABLE WatchDog_WatchLog
ALTER COLUMN method VARCHAR(MAX)

ALTER TABLE WatchDog_WatchLog
ALTER COLUMN host VARCHAR(300)


Redis
------------

https://redis.io/docs/latest/operate/oss_and_stack/install/install-stack/docker/
docker image pull redis/redis-stack:latest
docker run -d --name redis-stack -e REDIS_ARGS="--requirepass 123456" -p 6379:6379 -p 8001:8001 redis/redis-stack:latest
    33c9f5f666f8861e8e76e962ed4361448caf435b804affcb06c11819dbd35623
docker ps
http://localhost:8001 
default / 123456

Upgrade Net Standard to .Net 7
------------

dotnet tool install -g upgrade-assistant
dotnet tool update -g upgrade-assistant
cd "application folder"
ls
upgrade-assistant upgrade .\Saul.Test.sln
