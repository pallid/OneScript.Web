Процедура АсинхронноеЗадание() Экспорт
	
	Сообщить("Привет я выполнилось почти сразу - как только стали доступны ресурсы", СтатусСообщения.ОченьВажное);

КонецПроцедуры

Процедура АсинхронноеЗаданиеПодчиненноеОднократному() Экспорт
	
	Сообщить("Привет я выполнюсь следующим после АсинхронноеЗадание", СтатусСообщения.ОченьВажное);

КонецПроцедуры

Процедура АсинхронноеЗаданиеОтложенное() Экспорт
	
	Сообщить("Я отложенное задание - могу выполнятся с некоторой задержкой", СтатусСообщения.ОченьВажное);

КонецПроцедуры

Процедура АсинхронноеЗаданиеПодчиненноеОтложенному() Экспорт
	
	Сообщить("Привет я выполнюсь следующим после АсинхронноеЗаданиеОтложенное", СтатусСообщения.ОченьВажное);

КонецПроцедуры

Процедура ЗаданиеПоРасписанию() Экспорт
	
	Сообщить("Я работаю по расписанию - постоянно, пока не отключишь
	|или могу выполниться принудительно
	|кстати ;-)", СтатусСообщения.ОченьВажное);

КонецПроцедуры

Процедура АсинхронноеЗаданиеВыбрасывающееИсключение() Экспорт
	
	ВызватьИсключение "Я выбрасываю исключение и я фоновое задание - смотри колсоль сервера: там будет ошибка";

КонецПроцедуры