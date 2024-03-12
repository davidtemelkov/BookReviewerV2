FROM mysql:8.3.0

ENV MYSQL_ROOT_PASSWORD=root_password
ENV MYSQL_DATABASE=BookReviewerV2

VOLUME /var/lib/mysql

COPY ./init.sql /docker-entrypoint-initdb.d/

EXPOSE 3306