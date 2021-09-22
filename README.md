# Endre Sandbox project for backend course

name | value
--- | ---
language | C#
database | Postgres
deployed | https://aspnetsandbox.herokuapp.com/

## How to run in Docker from the commandline

Navigate into [AspNetSandbox](AspNetSandbox) directory.

cd AspNetSandbox

### Build in container
```
docker build -t web_endre .
```

to run

```
docker run -d -p 8081:80 --name web_container_endre web_endre
```

to stop container
```
docker stop web_container_endre
```

to remove container
```
docker rm web_container_endre
```

## Deploy to heroku

1. Create heroku account
2. Create application
3. Make sure application works locally in Docker


Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a aspnetsandbox web
```

Release the container
```
heroku container:release -a aspnetsandbox web
```