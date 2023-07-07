# Stage 0, "build-stage", based on Node.js, to build and compile the frontend
FROM amr-registry.caas.intel.com/caas/docker:19.03.1-dind

RUN export http_proxy=http://proxy-chain.intel.com:911
RUN export https_proxy=http://proxy-chain.intel.com:912
RUN export ftp_proxy=http://proxy-chain.intel.com:911
RUN export socks_proxy=http://proxy-chain.intel.com:1080
RUN export no_proxy=intel.com,.intel.com,localhost,127.0.0.1

WORKDIR /app
COPY intel_cert.sh ./

RUN apk add --update 
RUN apk add curl wget unzip
RUN sh /app/intel_cert.sh
RUN curl -L -o /usr/bin/kubectl https://storage.googleapis.com/kubernetes-release/release/$(curl -s https://storage.googleapis.com/kubernetes-release/release/latest.txt)/bin/linux/amd64/kubectl && chmod +x /usr/bin/kubectl && kubectl version --client
	
#install cf
#RUN npm config set proxy http://proxy-chain.intel.com:911 && npm config set https-proxy http://proxy-chain.intel.com:912 
ADD https://cli.run.pivotal.io/stable?release=linux64-binary&version=6.42.0 /tmp/cf-cli.tgz
RUN mkdir -p /usr/local/bin && tar -xzf /tmp/cf-cli.tgz -C /usr/local/bin && cf --version && rm -f /tmp/cf-cli.tgz





