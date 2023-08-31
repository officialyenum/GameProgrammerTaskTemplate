using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Gpt4All.Samples
{
    public class ChatSample : MonoBehaviour
    {
        public LlmManager manager;

        [Header("UI")]
        public InputField input;
        public Text output;
        public Button submit;

        private string _previousText;

        private void Awake()
        {
            input.onEndEdit.AddListener(OnSubmit);
            submit.onClick.AddListener(OnSubmitPressed);
            manager.OnResponseUpdated += OnResponseHandler;
        }


        private void OnSubmit(string prompt)
        {
            if (!Input.GetKey(KeyCode.Return))
                return;
            SendToChat(input.text);
        }

        private void OnSubmitPressed()
        {
            SendToChat(input.text);
        }

        private async void SendToChat(string prompt)
        {
            if (string.IsNullOrEmpty(prompt))
                return;

            input.text = "";
            output.text += $"<b>Action:</b> {prompt}\n<b>Result</b>: ";
            _previousText = output.text;
            Debug.Log($"{manager} @");
            await manager.Prompt(prompt);
            output.text += "\n";
        }

        private void OnResponseHandler(string response)
        {
            Debug.Log(response);
            output.text = _previousText + response;
        }

        public void UpdatePrompt(string prompt){
            if (string.IsNullOrEmpty(prompt))
                return;

            input.text = "";
            output.text += $"<b>Action:</b> {prompt}\n<b>Result</b>: ";
            _previousText = output.text;
            output.text += "\n";
        }
        public void UpdateOutputHandler(string response){
            output.text = _previousText + response;
            output.text += "\n";
        }
    }
}