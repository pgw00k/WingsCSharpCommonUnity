@echo off
setlocal enabledelayedexpansion

set src=%~dp0
set tgt=%1
set /p tgt="Target(%tgt%):"

@rem Unity6之后模板文件名和之前不一样
set obj[0].name="NewBehaviourScript.cs.txt"
set obj[0].tname="1-Scripting__MonoBehaviour Script-NewMonoBehaviourScript.cs.txt"

set objLength=1
set objIndex=0

:loopStart
if %objIndex% equ %objLength% goto end

set "currentName=!obj[%objIndex%].name!"
set "currentTname=!obj[%objIndex%].tname!"

if exist !tgt!\!currentTname! del !tgt!\!currentTname! 
mklink !tgt!\!currentTname! !src!!currentName!

set /a objIndex=%objIndex% + 1

goto loopStart

:end

pause