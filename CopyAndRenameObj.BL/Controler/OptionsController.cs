using CopyAndRenameObj.BL.Model;
using System;
using System.IO;
using System.Xml;

namespace CopyAndRenameObj.BL.Controler
{
    public static class OptionsController
    {
        private static string path = "";


        //Методы public

        

        /// <summary>
        /// Метод возвращающий путь к папке с составами в игре
        /// </summary>
        public static (bool, string) GetPath()
        {
            LoadConfigFile(); //Загружаем путь к RRS из конфигурационного файла
            string dir = Path.Combine(path, "TRAINS", "TRAINSET");
            if (Directory.Exists(dir)) return (true, dir); //Если такая директория существует, возвращаем путь к ней
            else return (false, "Для начала работы приложения, пожалуйста, укажите в меню каталог с установленным RTS");
        }

        /// <summary>
        /// Метод устанавливает директорию RTS в конфигурационный файл
        /// </summary>
        /// <param name="path">Путь</param>
        public static void SetPath(string path)
        {
            if (Directory.Exists(path))
            {
                SaveConfigFile(path); //Вызываем метод записывающий данные в файл конфигурации
            }        
        }



        //Методы privet

        /// <summary>
        /// Метод возвращает конфигурационный файл приложения
        /// </summary>
        private static FileInfo GetConfigFile()
        {
            return new FileInfo("config.xml");
        }

        /// <summary>
        /// Метод считывающий данные из файла конфигурации
        /// </summary>
        private static void LoadConfigFile()
        {
            var configFile = GetConfigFile(); //Получаем файл конфигурации
            if (configFile.Exists)//Проверяем существует ли конфигурационный файл
            {
                try
                {
                    XmlDocument xReader = new XmlDocument(); //Создаем поток

                    xReader.Load(configFile.FullName); //Считываем содержимое XML файла

                    XmlElement xRoot = xReader.DocumentElement; // получим корневой элемент

                    //Проверяем существует ли путь и ведет ли он к установленной игре
                    if (Directory.Exists(xRoot.InnerText))
                    {
                        path = xRoot.InnerText; //Получаем путь к установленной игре
                    }
                }
                catch (Exception)
                {

                }
            }

        }

        /// <summary>
        /// Метод записи конфигурации в XML файл
        /// </summary>
        /// <param name="configFile">Название файла конфигурации</param>
        /// <param name="pathRRS">Сохраняемый путь к игре</param>
        private static void SaveConfigFile(string path)
        {

            var xWriter = new XmlDocument();// Создаем новый Xml документ.

            var xmlDeclaration = xWriter.CreateXmlDeclaration("1.0", "UTF-8", null); // Создаем Xml заголовок.

            xWriter.AppendChild(xmlDeclaration); // Добавляем заголовок перед корневым элементом.

            var root = xWriter.CreateElement("ApplicationDirectory"); // Создаем Корневой элемент
            root.InnerText = path; // Помещаем путь в созданный элемент

            xWriter.AppendChild(root); // Добавляем новый корневой элемент в документ.

            xWriter.Save(GetConfigFile().FullName); // Сохраняем файл.
        }
    }
}
