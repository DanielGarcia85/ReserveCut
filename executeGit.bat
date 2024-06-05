@echo off
chcp 65001 >NUL
setlocal enabledelayedexpansion
:: Vérifie si le script est exécuté en tant qu'administrateur
net session >nul 2>&1
if %errorLevel% == 0 (
    echo Exécution en tant qu'administrateur
) else (
    echo Ce script nécessite des privilèges administrateur.
    echo Exécutez le script en tant qu'administrateur.
    pause
    exit
)

:: Change le répertoire
cd /d C:\Users\Daniel\OneDrive\#D@niel#\#_HEG\Semestre_4\62-41_Architecture\Projet_ReserveCut

:: Vérifie si un message de commit est passé en argument; sinon, demande à l'utilisateur de le saisir
if "%~1"=="" (
    echo Veuillez entrer un message de commit:
    set /p commitMessage=Message de commit: 
    if "!commitMessage!"=="" (
        echo Aucun message de commit n'a été saisi. Le script va se terminer.
        pause
        exit /b 1
    )
) else (
    set commitMessage=%~1
)

:: Exécute les commandes git
git add *
git commit -m "!commitMessage!"
git push

echo Les commandes Git ont été exécutées.
pause
