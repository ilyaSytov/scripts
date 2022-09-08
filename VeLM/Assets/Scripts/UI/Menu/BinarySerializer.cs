using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GoToApp.Serialization {

       public static class BinarySerializer {

        public static void Serialize<T>(string path, object data) {
            using (FileStream stream = new FileStream(path, FileMode.Create)) {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, data);
            }
        }

        public static T Deserialize<T>(string path) {
            using (FileStream stream = new FileStream(path, FileMode.Open)) {
                BinaryFormatter formatter = new BinaryFormatter();
                T data = (T)formatter.Deserialize(stream);
                return data;
            }
        }
    }
}
