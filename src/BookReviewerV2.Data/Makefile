CONTAINER_NAME = mysql-bookreviewerv2
IMAGE_NAME = mysql-bookreviewerv2
ROOT_PASSWORD = root_password
VOLUME_NAME = mysql-bookreviewerv2-data

.PHONY: build_and_run

build_and_run:
	docker build -t $(IMAGE_NAME) . && \
	docker run -p 3306:3306 --name $(CONTAINER_NAME) -e MYSQL_ROOT_PASSWORD=$(ROOT_PASSWORD) -v $(VOLUME_NAME):/var/lib/mysql -d $(IMAGE_NAME)
