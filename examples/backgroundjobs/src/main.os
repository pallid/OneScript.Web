﻿#Использовать "model"

Процедура ПриНачалеРаботыСистемы()
	
	ИспользоватьСтатическиеФайлы();
	ИспользоватьАвторизацию();
	ИспользоватьСессии();
	ИспользоватьФоновыеЗадания();
	//TODO:
	// Включить управление консолью, когда будет готова архитектура ролей в целом.
	//ИспользоватьКонсольЗаданий("/jobsserver");
	ИспользоватьМаршруты();

	НастроитьФоновыеЗадания();

КонецПроцедуры


Процедура НастроитьФоновыеЗадания()

	//
	ИД1 = ФоновыеЗадания.Выполнить("ОбработчикиФоновых.АсинхронноеЗадание");

	ЗадержкаВыполнения = Новый ПараметрыОжиданияФоновыхЗаданий();
	ЗадержкаВыполнения.ОжиданиеВСекундах(30);

	ИД2 = РегламентныеЗадания.ВыполнитьОтложенноеЗадание("ОбработчикиФоновых", "АсинхронноеЗаданиеОтложенное", ЗадержкаВыполнения);
	
	Раписание = Новый РасписаниеФоновыхЗаданий();
	Раписание.КаждуюМинуту();
	Сообщить(Раписание.РасписаниеСтрокой);
	РегламентныеЗадания.СоздатьПериодическоеЗаданиеПоРасписанию("ОбработчикиФоновых", "ЗаданиеПоРасписанию", Раписание);

	РегламентныеЗадания.ВыполнитьПодчиненноеЗадание(ИД1,"ОбработчикиФоновых", "АсинхронноеЗаданиеПодчиненноеОднократному");
	РегламентныеЗадания.ВыполнитьПодчиненноеЗадание(ИД2,"ОбработчикиФоновых", "АсинхронноеЗаданиеПодчиненноеОтложенному");

	ИД3 = РегламентныеЗадания.ВыполнитьЗаданиеОднократно("ОбработчикиФоновых", "АсинхронноеЗаданиеВыбрасывающееИсключение");

КонецПроцедуры
