pipeline {
    agent any
    options {
        buildDiscarder(logRotator(numToKeepStr: "100"))
        skipDefaultCheckout(true)
    }
    triggers {
        pollSCM("H * * * *")
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
               sh 'dotnet restore Futterbock.sln -r linux-x64'
            }
        }
        stage('Clean'){
            steps{
               sh 'dotnet clean Futterbock.sln --configuration Release'
            }
        }
        stage('Build'){
            steps {
                sh 'dotnet publish -c Release -r linux-x64 --no-restore --self-contained=false /p:PublishSingleFile=true -o publish/'
            }
        }
        stage('Deploy'){
            steps {
              sshPublisher(
                 continueOnError: false, failOnError: true,
                 publishers: [
                  sshPublisherDesc(
                   configName: "phlaym",
                   verbose: true,
                   transfers: [
                    sshTransfer(
                     execCommand: "rm www/futterbock/*"
                    )
                   ])
                 ])
              sshPublisher(
               continueOnError: false, failOnError: true,
               publishers: [
                sshPublisherDesc(
                 configName: "phlaym",
                 verbose: true,
                 transfers: [
                  sshTransfer(
                   sourceFiles: "publish/*",
                   remoteDirectory: "www/futterbock/",
                   removePrefix: "publish",
                   execCommand: "sudo systemctl restart kestrel-futterbock.service && chmod +x www/futterbock/Futterbock"
                  )
                 ])
               ])
             }
        }
    }
}
