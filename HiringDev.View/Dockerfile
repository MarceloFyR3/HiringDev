#### COMANDOS PARA PUBLICAR
#
# 
# PRODUÇÃO
# docker build -t ivmnegocios/ivm:production .
# docker push ivmnegocios/ivm:production
# https://$siteivm:eWApFWpFN13H1p9ufwZl7cKZf7ekRflJXvCDrrYxRjGnzooHydwQjjSicsHZ@siteivm.scm.azurewebsites.net/docker/hook
#
# HOMOLOGAÇÃO
# docker build -t ivmnegocios/ivm:homol .
# docker push ivmnegocios/ivm:homol


FROM node
RUN npm install -g http-server
WORKDIR /app

COPY package*.json ./
COPY .env ./

RUN npm install
COPY . .
RUN npm run build

EXPOSE 8080
CMD [ "http-server", "dist" ]
