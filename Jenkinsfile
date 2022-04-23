pipeline {
    agent any
    options {
        buildDiscarder(logRotator(numToKeepStr: "100"))
        skipDefaultCheckout(true)
    }
    stages {
        stage('Checkout'){
            steps{
                cleanWs()
                checkout scm
           }
        }
        stage('Restore packages'){
            steps{
               sh 'dotnet restore Futterbock.sln'
            }
        }
        stage('Clean'){
            steps{
               sh 'dotnet clean Futterbock.sln --configuration Release'
            }
        }
        stage('Build'){
            steps {
                sh 'dotnet build Futterbock.sln --configuration Release --no-restore'
            }
        }
        stage('Publish'){
            steps {
                sh 'sudo dotnet publish -c Release -r linux-x64 --no-build --self-contained=false /p:PublishSingleFile=true -o publish/'
                sh 'scp publish/* phlaym@phlaym.net:~/www/futterbock/'
                sh 'ssh phlaym@phlaym.net sudo systemctl restart kestrel-futterbock.service'
            }
        }
    }
}
