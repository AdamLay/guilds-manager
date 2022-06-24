docker build . -t guilds-manager
heroku container:push web -a guilds-manager-ag
heroku container:release web -a guilds-manager-ag