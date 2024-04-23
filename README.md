# Игра в жанре платформер с элементами rogue-lite "Jump & Fight" [![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/) 
Аркадный платформер с видом сбоку в сеттинге классического фентези. Жанры - platformer, rogue-lite. Главной задачей игрока является подъем по башне при помощи прыжков. Однако, помимо преодоления платформ, игроку предстоит столкнуться с врагами на отдельных аренах, что представляют собой промежуточный этап между прыжковыми секциями. Визуально игра выполнена в стиле пиксельной графики для лучшего погружения в атмосферу игр подобного жанра. Платформа, для которой разрабатывается игровой продукт - ПК.
## Основные возможности:
Игроку предоставляется возможность прочувствовать ключевые возможности двух на первый взгляд несовместимых жанров. Данная идея реализована с помощью разделения игрового процесса на две части - прыжковую и боевую. 
Прыжковая секция выполнена в стиле Doodle Jump и включает в себя неконролируемый подъем по платформам, преодоление врагов и сбор бонусов, влияющих на урон, здоровье и другие показатели персонажа. 
Боевая секция столкнет игрока с большим разнообразием противников и главным боссом, за победу над которым, можно будет получить всевозможные награды. 
Разделение на секции также обусловлено применением разных геймплейных особенностей. По мере продвижения вперед, игроку предоставится возможность разблокировать новых персонажей и получать уникальные способности, что можно будет сделать благодаря внутриигровой валюте.
## Стек технологий:
1. Godot Engine - универсальный 2D и 3D игровой движок, спроектированный для поддержки всех видов проектов. Используется для создания игр или приложений, которые можете затем выпускать на настольных или мобильных платформах, а также web.
2. Docker - программная платформа для быстрой разработки, и развертывания приложений. Docker упаковывает ПО в стандартизованные блоки - контейнеры. Каждый контейнер включает все необходимое для работы приложения: библиотеки, системные инструменты, код и среду исполнения.
3. Jenkins - сервер непрерывной интеграции (CI) с открытым исходным кодом, написанный на Java. Это веб-приложение позволяет автоматизировать различные задачи разработки программного обеспечения, такие как сборка, тестирование и развертывание.
4. Git - GitFlow — система управления версиями с распределенной архитектурой, предназначенная для отслеживания и ведения истории изменения файлов.

## Система Интеграции и развертывания 
В качестве системы CI/CD выступает Github Actions 

[![Build Godot Project for Windows](https://github.com/DmitriySkiba/Jump-Fight/actions/workflows/godotbuild.yml/badge.svg)](https://github.com/DmitriySkiba/Jump-Fight/actions/workflows/godotbuild.yml) 

## Инструкции по установке/запуску:
-
## Разработчики
- [Dmitriy Skibinskiy](https://github.com/DmitriySkiba)
- [Maksim Baturin](https://github.com/MaksimBaturin)
- [Asan Smailov](https://github.com/AsanSmailov)
- [Amet Chalbash](https://github.com/DiarrheaGiver)
- [Emir Buzhurov](https://github.com/EmirBuzhurov)
