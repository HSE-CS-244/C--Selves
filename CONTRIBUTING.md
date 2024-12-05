# RTFM для работы с git и  github для начинающих

Git - система контроля версий. Можете считать, что это ваш системный Ctrl+S. 
Чтобы другие люди могли пользоваться вашей работой был создан github. 
Это удаленный сервер, на который вы можете отправить созданный проект, чтобы не потерялся,
и в который могут вносить изменения другие люди, с вашего позволения.

Гайд подразумевает, что вы знакомы с командной строкой, и у вас уже установлен git.

## Установка и работа с проектом

### Шаг 1. Копировать репозиторий
Убедитесь, что вы находитесь в папке со своими проектами. 
`git clone` создаст новую одноименную с названием проекта папку и поместит репозиторий в нее.
```sh
git clone github.com/HSE-CS-244/C--Selves
```

### Шаг 2. Запуск проекта
Запуск нужно производить из корня проекта. Вы должны находиться в той же папке, 
где находится `README.md` и `.gitignore`.
```sh
dotnet run Self-test
# Выведится: Hello from Self-test
```

### Шаг 3. Изменения
Договоренности по размещению Self'ов еще не предусмотрено. Пока предлагается следующее
1. Создать новую папку для Self'а (Например `Self-69`)
2. В ней создать новую папку с задачей (Например `SolveTesticularCancer`)
3. В ней разместить `Program.cs` и все связанные файлы

## Работа с **git** и залив изменений

Вот это уже важная часть. То что тут описано - стандартный цикл публикации изменений.
Внимательно относитесь к тому, что делаете. Пока делайте все по инструкции, через пару раз
само запомниться.

После того, как вы создадите, поменяете ваши файлы, как вам угодно, делайте следующее:

### Шаг 1. Новая ветка с **git checkout**
Здесь не стану подробно разбираться с тем что такое ветка и как она работает.
Предлагаю для начинающих относиться к этому, как к **необходимому** шагу.
Создайте новую ветку и назовите ее так, чтобы она примерно отражала ваши внесенные изменения.

```sh
git checkout -b Self69SolveTesticularCancer
```

Флаг `-b` говорит *создай новую ветку если такой не существует*. Если просто написать
`git checkout Self69SolveTesticularCancer`, то git попробует найти такую ветку и не найдя ее
выдаст ошибку.

### Шаг 2. **git add**
Git сам по себе не станет постоянно проверять, что вы там написали у себя в проекте. 
От только по комманде просмотрит все, что находится в вашей папке и запомнит все изменения,
сохранив их в папку `.git`

Чтобы внести измененные и только что созданные файлы в список отслеживаемых git'ом,
Их нужно добавить с помощью `git add`. Он принимает название папки/файла в качестве аргумента
и без него работать не станет. Чтобы добавить ВСЕ изменения, убедитесь, что находитесь в корне проекта
и запустите `git add .`. В POSIX `.` - это алиас (копия названия, так сказать) текущей папки, в которой вы находитесь.

```sh
git add .
# Ничего не должно выводиться...
```

Теперь git следит за этими файлами. Не то чтобы он постоянно что-то проверял, но теперь он будет
знать, что изменения этих файлов важны и в случае чего их тоже нужно подхватить.

### Шаг 3. **git commit**
Как и было сказано, добавленные файлы еще никуда не сохранились. Чтобы git принял изменения
нужно написать `git commit`. Пожалуйста всегда добавляйте сообщения к коммитам. Достаточно
примерно такого: "Add: Self-69 SolveTesticularCancer". Дайте другим разработчикам понять 
что содержит вам коммит без надобности пробегаться по всему проекту пытаясь понять, что вы изменили.

```sh
git commit -m "Add: Self-69 SolveTesticularCancer"
# Должно вывестись сообщение с файлами, вошедшими в коммит
```

### Шаг 4. **git status**
Не пропускайте этот шаг. Без него и так все будет работать, но скорее всего 
вы либо забыли один из шагов, либо перепутали их порядок. `git status` выведет
текущий статус проекта.  

В первой строке всегда должно быть название вашей ветки
```sh
git status
# On branch Self69SolveTesticularCancer
# ...
```
Если это не так, просто создайте новую с помощью `git checkout -b НазваниеВетки`.

Если у вас имеются `untracked files`, то вы накосячили с `git add`.
```sh
git status
# ...
# Untracked files:
#   (use "git add <file>..." to include in what will be commited)
#         Файл1
#         Файл2
#         ...
# ...
```
Перейдите в корень проекта и напишите `git add .`

Если у вас остались `changes to be commited`, то вы закоммитили не все файлы
```sh
git status
# ...
# Changes to be commited:
#   (use "git rm --cached <file>..." to unstage)
#         new file:   Файл1
#         new file:   Файл2
#         ...
# ...
```
Напишите `git commit --amend`, чтобы закоммитить файлы. 
Флаг `--amend` добавит изменения к уже имеющемуся коммиту, вместо того, чтобы создавать новый.
Если вывелось сообщение `fatal: You have nothing to amend.`, значит вы не сделали еще ни одного коммита.
Напишите `git commit -m "Message. In english, please..."` и не забудьте указать сообщение к коммиту.

В ЛУЧШЕМ СЛУЧАЕ у вас при очердном запуске `git status` дожно быть следующее

```sh
git status
# On branch Self69SolveTesticularCancer
# nothing to commit, working tree clean
```
Теперь вы готовы пушить изменения...

### Шаг 5. **git push**
Все, что вы делали до этого момента происходило только на вашем компьютере и никак не связано
с `github` и репозиторием, который в нем находиться. Чтобы ваши изменения как-то отразились на
удаленном репозитории их надо **запушить** с помощью `git push`. Так как все что вы делали
было связано с созданной вами веткой (я надеюсь), вам нужно запушить именно ее.
```sh
git push origin Self69SolveTesticularCancer
```
Готово! Теперь ваши изменения появятся на github. Но не ждите, что репозиторий измениться так просто.
Было бы неприятно, если бы каждый мог просто взять и поменять ваш репозиторий как ему угодно.
Нужно открыть `pull request`.




