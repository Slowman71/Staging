using System;
using System.IO;
using UnityEngine;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels;

namespace App.Scripts.Scenes.SceneFillwords.Features.ProviderLevel
{
    public class ProviderFillwordLevel : IProviderFillwordLevel
    {
        
        
        public GridFillWords LoadModel(int index)
        {
            string textFile = "C:/Users/e1/Downloads/task_project_2023/Assets/App/Resources/Fillwords/pack_0.txt";
            string Library = "C:/Users/e1/Downloads/task_project_2023/Assets/App/Resources/Fillwords/words_list.txt";
            int[] chart = { 4, 9, 16, 25, 36, 49, 64, 81, 100 };
            bool error = false;
            //напиши реализацию не меняя сигнатуру функции
            if (File.Exists(Library)) {
                string[] words = File.ReadAllLines(Library);
                if (File.Exists(textFile)) {
                    string[] pack = File.ReadAllLines(textFile);
                    foreach(string lines in pack){
                        string[] levels = lines.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string check = "";
                        int a = 0;
                        for(int i = 0; i<levels.Length; i++){  
                                                       
                            if(levels[i].Contains(";")){
                                check += levels[i] + ";";
                            }
                            else { 
                                int b = 0;
                                string[] l = levels[i+1].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);                             
                                foreach(string length in l){
                                    b++;
                                    a++; 
                                }                                           
                                if (b != words[int.Parse(levels[i])].Length)          
                                 error = true;
                            }          
                        }
                        
                        string[] elem = check.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        int p = 0;
                        string k = "";
                        foreach(string pos in elem){   
                           
                            if(int.Parse(pos)>((a-1)))              
                                error = true;
                            p++;
                            if (k.Contains(pos))
                                error = true;   
                            else k+= pos + ";";
                        }
                        bool flag = false;
                        foreach (int z in chart){
                            if (a == z){                            
                                flag = true;
                            }
                        }
                        if (!flag) 
                            error = true;

                        if(p>a)
                           error = true;                                     
                    }
                }
            }
            if (error)
                return null;
            throw new NotImplementedException();
        }
    }
}

/*я считываю файл и нахожу айди в словах , далее я сравниваю айди
и размер слова (ошибка нет данных) после чего я смотрюб на строку в пак
и проверяю создание уровня(ошибка нельзя создать уровень)
*/
