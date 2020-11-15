FROM node:latest as build
RUN mkdir -p /src/app/

WORKDIR /src/app
ENV PATH /src/app/node_modules/.bin:$PATH
COPY Web/fycure-web/package.json /src/app/

RUN npm install
RUN npm install react-scripts -g

COPY Web/fycure-web /src/app
RUN npm run build

# FROM nginx:1.13.12-alpine
# COPY --from=build /src/app/build /share/nginx/html
# EXPOSE 80
# CMD ["nginx", "-g", "daemon off;"]

# nginx state for serving content
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*
COPY --from=builder /src/app/build .
# Containers run nginx with global directives and daemon off
ENTRYPOINT ["nginx", "-g", "daemon off;"]