'use strict';

const Gpio = require('onoff').Gpio;
const EventEmitter = require('events');
const { exec } = require('child_process');

const run = command => {
    console.log(`Running: "${command}".`);
    return new Promise((resolve, reject) => {
        exec(command, err => {
            err ? reject(err) : resolve();
        });
    });
};

class GPIOButtons extends EventEmitter {
    constructor() {
        super();
        this.init();
        this.gpio = new Gpio(17, 'in', 'both');
        this.gpio.watch(this.listener.bind(this));
        this.lastvalue = null;
        this.playing = false;
        this.ready = false;
    }

    async init() {
        await run('mpc clear');
        await run('mpc add http://stream-ice.radionz.co.nz/national.mp3');
        this.ready = true;
    }

    async play() {
        console.log('Starting playlist');
        await run('mpc play');
    }

    async stop() {
        console.log('Stopping playlist');
        await run('mpc stop');
    }

    async toggle() {
        if (this.playing) {
            await this.stop();
        }
        else {
            await this.play();
        }
        this.playing = !this.playing;
    }

    listener(err, value) {
        if (!this.ready) {
            return;
        }

        // IF change AND high (or low?)
    	if (this.lastvalue !== value && value === 1){
            this.lastvalue = value;
    		setTimeout(() => {
    			try {
    				if (this.gpio.readSync() == value) {
    					//do thing
    					this.toggle();
    				}
    			}
    			catch (e) {
    				console.error(e);
    				console.trace(e);
    			}
    		}, 300);
    	}
        else if (this.lastvalue === 1 && value === 0) {
            this.lastvalue = 0;
            console.log('Resetting button');
        }
        else {
            console.log('Ignoring rouge input');
        }
    }
}

new GPIOButtons();

