FROM node:latest as build
RUN mkdir -p /src/app/

WORKDIR /src/app
ENV PATH /src/app/node_modules/.bin:$PATH
COPY Web/fycure-web/package.json /src/app/

RUN npm install
RUN npm install react-scripts -g

COPY Web/fycure-web /src/app
RUN npm run build

FROM nginx:alpine
COPY --from=build /src/app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

