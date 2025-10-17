using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KinesiaLibrary.DTOs;
using KinesiaLibrary.DTOs.ROMDTOs;
using Newtonsoft.Json;

namespace Kinesia.Assessment
{
    public class ROMCRUD
    {
        public async Task<bool> AddROM(AddROMDTO newROM)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:5001/api/");
                    var json = JsonConvert.SerializeObject(newROM);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("rom", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        // will show an error dialog if it returns a badrequest from API-side.
                        CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                                    "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                        return false;
                    }
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side.
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                            "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("Unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }
        }
        public bool IsROMDetailsComplete(AddROMDTO newROM)
        {
            // will return true if the ROM details was complete
            // will return false if the ROM details was incomplete
            if (newROM.EndROM == 0.0 || newROM.Movement.Equals("") || newROM.MotionType.Equals("") || newROM.Deviation.Equals(""))
            {
                CustomDialog.Show("ROM details was incomplete! \nPlease fill-out all details to add this ROM.", "Incomplete ROM Details",
                    CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }

            return true;
        }
    }
}
