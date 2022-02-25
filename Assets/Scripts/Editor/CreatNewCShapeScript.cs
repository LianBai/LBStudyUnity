using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace LBUnityEditor.Editor
{
    public static class CreatNewCShapeScript
    {
        /// <summary>
        /// 创建不继承MonoBehaviour脚本
        /// </summary>
        [MenuItem("Assets/Create/C# Scripts Menu/C# NoMonoBehaviourScript", false,81)]
        public static void CreatNoMonoBehaviourScript()
        {
            //参数为传递给CreateEventCSScriptAsset类action方法的参数
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
                ScriptableObject.CreateInstance<CreateNewCShapeScriptAsset>(),
                GetSelectPathOrFallback() + "/NewNoMonoBehaviourScript.cs", null,
                "CustomScriptTemplate/C# Script-NewNoMonoBehaviourScript.txt");
        }

        /// <summary>
        /// 取得要创建文件的路径
        /// </summary>
        /// <returns></returns>
        private static string GetSelectPathOrFallback()
        {
            var path = "Assets";
            //遍历选中的资源以获得路径
            //Selection.GetFiltered是过滤选择文件或文件夹下的物体，assets表示只返回选择对象本身
            foreach (var obj in Selection.GetFiltered(typeof(Object), SelectionMode.Assets))
            {
                path = AssetDatabase.GetAssetPath(obj);
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    path = Path.GetDirectoryName(path);
                    break;
                }
            }
            return path;
        }

        /// <summary>
        /// 创建脚本文件的委托类
        /// </summary>
        private class CreateNewCShapeScriptAsset : EndNameEditAction
        {
            public override void Action(int instanceId, string pathName, string resourceFile)
            {
                var obj = CreateScriptAssetFromTemplate(pathName, resourceFile);                         //创建资源
                ProjectWindowUtil.ShowCreatedAsset(obj);                                                                //高亮显示资源
            }

            private static UnityEngine.Object CreateScriptAssetFromTemplate(string pathName, string resourceFile)
            {
                var fullPath = Path.GetFullPath(pathName);                                                           //获取要创建资源的绝对路径
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);                           //获取文件名，不含扩展名
                var textAsset = EditorGUIUtility.Load(resourceFile) as TextAsset;
                var resourceFileText = textAsset!.text;
                resourceFileText = Regex.Replace(resourceFileText, "#NAMESPACE#",
                    CompilationPipeline.GetAssemblyRootNamespaceFromScriptPath(pathName));
                resourceFileText = Regex.Replace(resourceFileText, "#SCRIPTNAME#", fileNameWithoutExtension);              //将模板类中的类名替换成你创建的文件名
                const bool encoderShouldEmitUTF8Identifier = true; //参数指定是否提供 Unicode 字节顺序标记
                const bool throwOnInvalidBytes = false; //是否在检测到无效的编码时引发异常
                var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
                const bool append = false;
                var streamWriter = new StreamWriter(fullPath, append, encoding);                               //写入文件
                streamWriter.Write(resourceFileText);
                streamWriter.Close();
                AssetDatabase.ImportAsset(pathName);                                                                    //刷新资源管理器
                AssetDatabase.Refresh();
                return AssetDatabase.LoadAssetAtPath(pathName, typeof(UnityEngine.Object));
            }
        }
    }
}
