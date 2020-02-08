#include <windows.h>
#include <stdio.h>
#include <mmdeviceapi.h>
#include <endpointvolume.h>

int main(int argc, char *argv[])
{
	double newVolume = 0.0;
	if(argc != 2 || (newVolume = atof(argv[1])) == 0.0){
		printf("Voltrol.exe - Knox Volume Control\nUsage:\nVoltrol.exe [decimal between 0 and 100]\n");
	}
	newVolume /= 100;

	CoInitialize(NULL);
	IMMDeviceEnumerator *deviceEnumerator = NULL;
	HRESULT hr = CoCreateInstance(__uuidof(MMDeviceEnumerator), NULL, CLSCTX_INPROC_SERVER, __uuidof(IMMDeviceEnumerator), (LPVOID *)&deviceEnumerator);
	IMMDevice *defaultDevice = NULL;

	hr = deviceEnumerator->GetDefaultAudioEndpoint(eRender, eConsole, &defaultDevice);
	deviceEnumerator->Release();
	deviceEnumerator = NULL;

	IAudioEndpointVolume *endpointVolume = NULL;
	hr = defaultDevice->Activate(__uuidof(IAudioEndpointVolume), CLSCTX_INPROC_SERVER, NULL, (LPVOID *)&endpointVolume);
	defaultDevice->Release();
	defaultDevice = NULL;

	float currentVolume;
	hr = endpointVolume->GetMasterVolumeLevelScalar(&currentVolume);
	currentVolume *= 100;
	printf("The current volume is: %f%\n", currentVolume);
	hr = endpointVolume->SetMasterVolumeLevelScalar((float)newVolume, NULL); // set volume
	endpointVolume->Release();

	CoUninitialize();
	return 0;
}
