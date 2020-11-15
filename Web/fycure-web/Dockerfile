FROM node:latest as build
RUN mkdir -p /src/app/

WORKDIR /src/app
ENV PATH /src/app/node_modules/.bin:$PATH
COPY Web/fycure-web/package.json /src/app/

RUN npm install
RUN npm install react-scripts -g

COPY Web/fycure-web /src/app
RUN npm run build

# nginx state for serving content
FROM nginx:alpine
# Set working directory to nginx asset directory
WORKDIR /usr/share/nginx/html
# Remove default nginx static assets
RUN rm -rf ./*
# Copy static assets from builder stage
COPY --from=builder /src/app/build  .
# Containers run nginx with global directives and daemon off
ENTRYPOINT ["nginx", "-g", "daemon off;"]