pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:8.0' // Use .NET SDK Docker image
            args '-v /var/jenkins_home:/var/jenkins_home' // Mount Jenkins home directory
        }
    }
    
    environment {
        DOTNET_VERSION = '8' // Specify .NET version
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm // Checkout the source code
            }
        }
        
        stage('Restore') {
            steps {
                script {
                    // Restore project dependencies
                    sh "dotnet restore"
                }
            }
        }
        
        stage('Build') {
            steps {
                script {
                    // Build the project
                    sh "dotnet build -c Release"
                }
            }
        }
        
        stage('Test') {
            steps {
                script {
                    // Run tests if any
                    sh "dotnet test"
                }
            }
        }
        
        stage('Publish') {
            steps {
                script {
                    // Publish the project
                    sh "dotnet publish -c Release -o ./publish"
                }
            }
        }
    }
    
    post {
        success {
            // If the build is successful, archive the published artifacts
            archiveArtifacts artifacts: 'publish/**/*', onlyIfSuccessful: true
        }
    }
}
