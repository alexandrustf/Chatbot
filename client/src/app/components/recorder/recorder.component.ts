import { Component, OnInit } from '@angular/core';
import { timer, interval } from 'rxjs';
import { ResponseModel } from '../response.model';
import { RecorderService } from 'src/app/recorder.service';

declare var MediaRecorder: any;
@Component({
    selector: 'app-recorder',
    templateUrl: './recorder.component.html'
})
export class RecorderComponent implements OnInit {
    public response: ResponseModel;
    constructor(private recorderService: RecorderService) {}

    public ngOnInit(): void {
        navigator.mediaDevices
            .getUserMedia({ audio: true, video: false })
            .then(stream => this.handleSuccess(stream));
    }

    private handleSuccess(stream) {
        const mediaRecorder = new MediaRecorder(stream);
        mediaRecorder.start();

        let audioChunks = [];
        mediaRecorder.addEventListener('dataavailable', event => {
            audioChunks.push(event.data);
        });

        mediaRecorder.addEventListener('stop', () => {
            const audioBlob = new Blob(audioChunks, {
                type: 'audio/wav; codecs=MS_PCM'
            });
            let cev = this.recorderService.getResponse(audioBlob).subscribe();
            console.log(cev);
            const audioUrl = URL.createObjectURL(audioBlob);
            const audio = new Audio(audioUrl);
            audio.play();
        });

        interval(5000).subscribe(() => {
            mediaRecorder.stop();
            audioChunks = [];
            mediaRecorder.start();
        });
    }
}
