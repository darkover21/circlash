def PROJECT_NAME = "Circlash"
def CUSTOM_WORKSPACE = "D:\\Gits\\${PROJECT_NAME}"
def UNITY_VERSION = "2023.1.15f1"
def UNITY INSTALLATION = "C:\\Program Files\\Unity\\Hub\\Editor\\${UNITY_VERSION}\\Editor"

pipeline{
    environment{
        PROJECT_PATH = "${CUSTOM_WORKSPACE}\\${PROJECT_NAME}"
    }
    
    agent{
        label{
            label ""
            customWorkspace "${CUSTOM_WORKSPACE}"
        }
    }
    stages{
        stage('Build Windows') {
            when{expression {BUILD_WINDOWS == 'true'}}
            steps{
                script{
                withEnv(["UNITY_PATH=${UNITY_INSTALLATION}"]){
                    bat '''
                    "%UNITY_PATH%/Unity.exe" -quit -batchmode -projectPath % PROJECT_PATH% -executeMethod BuildScript. BuildWindows-logFile - I
                    '''
                }

                stage( 'Deploy Windows') {
                    when{expression (DEPLOY_WINDOWS == 'true'}}
                }
            }
        }
    }
}